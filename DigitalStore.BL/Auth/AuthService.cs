using System.Security.Authentication;
using AutoMapper;
using DigitalStore.BL.Auth.Entities;
using DigitalStore.BL.Exceptions.UsersExceptions;
using DigitalStore.DataAccess;
using DigitalStore.DataAccess.Entities;
using Duende.IdentityModel.Client;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace DigitalStore.BL.Auth;

public class AuthService : IAuthService
{
    private readonly DigitalStoreDbContext _context;
    private readonly SignInManager<UsersEntity> _signInManager;
    private readonly UserManager<UsersEntity> _userManager;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;
    private readonly string _identityServerUri;
    private readonly string _clientId;
    private readonly string _clientSecret;

    public AuthService(DigitalStoreDbContext context, SignInManager<UsersEntity> signInManager, 
        UserManager<UsersEntity> userManager, IHttpClientFactory httpClientFactory, IMapper mapper, 
        string identityServerUri, string clientId, string clientSecret)
    {
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
        _httpClientFactory = httpClientFactory;
        _mapper = mapper;
        _identityServerUri = identityServerUri;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }

    public async Task<TokenResponce> RegisterUserAsync(RegisterUserModel model)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                throw new UserAlreadyExistsException("User already exists.");
            }

            user = _mapper.Map<UsersEntity>(model);

            var createResult = await _userManager.CreateAsync(user, model.Password);
            if (!createResult.Succeeded)
            {
                throw new AuthenticationFailureException(
                    string.Join(Environment.NewLine, createResult.Errors.Select(e => e.Description)) );
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "user");
            if (!roleResult.Succeeded)
            {
                throw new AuthenticationFailureException(
                    string.Join(Environment.NewLine, roleResult.Errors.Select(e => e.Description)));
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            
            var client = _httpClientFactory.CreateClient();
            var discoveryDocument = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _identityServerUri,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });
            if (discoveryDocument.IsError)
            {
                throw new AuthenticationFailureException("Identity server error");
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                GrantType = GrantType.ResourceOwnerPassword,
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                UserName = user.UserName,
                Password = model.Password,
                Scope = "api offline_access"
            });
            
            if (tokenResponse.IsError)
            {
                throw new AuthenticationFailureException("Identity server error");
            }
        
            return new TokenResponce
            {
                AccessToken = tokenResponse.AccessToken,
                RefreshToken = tokenResponse.RefreshToken
            };
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<TokenResponce> LoginUserAsync(LoginUserModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user is null)
        {
            throw new UserNotFoundException("User not found");
        }
        
        var verificationResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!verificationResult.Succeeded)
        {
            throw new AuthenticationFailureException("Email or password is incorrect");
        }
        
        var client = _httpClientFactory.CreateClient();
        var discoveryDocument = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _identityServerUri,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });
        if (discoveryDocument.IsError)
        {
            throw new AuthenticationFailureException("Identity server error");
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = discoveryDocument.TokenEndpoint,
            GrantType = GrantType.ResourceOwnerPassword,
            ClientId = _clientId,
            ClientSecret = _clientSecret,
            UserName = user.UserName,
            Password = model.Password,
            Scope = "api offline_access"
        });

        if (tokenResponse.IsError)
        {
            throw new AuthenticationFailureException("Identity server error");
        }
        
        return new TokenResponce
        {
            AccessToken = tokenResponse.AccessToken,
            RefreshToken = tokenResponse.RefreshToken
        };
    }
}