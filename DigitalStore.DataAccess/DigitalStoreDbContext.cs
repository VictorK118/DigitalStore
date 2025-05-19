using DigitalStore.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalStore.DataAccess;

public class DigitalStoreDbContext: IdentityDbContext<
    UsersEntity, 
    Role, 
    Guid, 
    IdentityUserClaim<Guid>, 
    UserRole, 
    IdentityUserLogin<Guid>, 
    IdentityRoleClaim<Guid>, 
    IdentityUserToken<Guid>
>
{
    public DbSet<UsersEntity> Users { get; set; }
    public DbSet<SmartphonesEntity> Smartphones { get; set; }
    public DbSet<ChipsEntity> Chips { get; set; }
    public DbSet<BrandsEntity> Brands { get; set; }
    public DbSet<CitiesEntity> Cities { get; set; }
    public DbSet<RolesEntity> Roles { get; set; }
    public DbSet<OfflineStoresEntity> OfflineStores { get; set; }
    public DbSet<OrdersEntity> Orders { get; set; }
    public DbSet<SmartphonesInOrdersEntity> SmartphonesInOrders { get; set; }
    public DbSet<SmartphonesInStoresEntity> SmartphonesInStores { get; set; }
    
    
    public DigitalStoreDbContext(DbContextOptions options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsersEntity>().HasKey(x => x.Id);
        
        modelBuilder.Entity<CitiesEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UsersEntity>()
            .HasOne(x => x.City)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.CityId);
        modelBuilder.Entity<Role>().ToTable("user_roles");
        modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        modelBuilder.Entity<IdentityUserToken<Guid>>()
            .ToTable("user_tokens")
            .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

        modelBuilder.Entity<IdentityUserLogin<Guid>>()
            .ToTable("user_logins")
            .HasKey(l => new { l.LoginProvider, l.ProviderKey });

        modelBuilder.Entity<IdentityUserClaim<Guid>>()
            .ToTable("user_claims")
            .HasKey(c => c.Id);

        modelBuilder.Entity<IdentityRoleClaim<Guid>>()
            .ToTable("user_role_claims")
            .HasKey(c => c.Id);
        /*modelBuilder.Entity<RolesEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UsersEntity>()
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);*/
        
        modelBuilder.Entity<OfflineStoresEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<OfflineStoresEntity>()
            .HasOne(x => x.City)
            .WithMany(x => x.Stores)
            .HasForeignKey(x => x.CityId);
        
        modelBuilder.Entity<UsersEntity>()
            .HasOne(x => x.Store)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.StoreId);
        
        modelBuilder.Entity<SmartphonesEntity>().HasKey(x => x.Id);
        
        modelBuilder.Entity<BrandsEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<SmartphonesEntity>()
            .HasOne(x => x.Brand)
            .WithMany(x => x.Smartphones)
            .HasForeignKey(x => x.BrandId);
        
        modelBuilder.Entity<ChipsEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<SmartphonesEntity>()
            .HasOne(x => x.Chip)
            .WithMany(x => x.Smartphones)
            .HasForeignKey(x => x.ChipId);
        
        modelBuilder.Entity<OrdersEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<OrdersEntity>()
            .HasOne(x => x.User)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<SmartphonesInOrdersEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<SmartphonesInOrdersEntity>()
            .HasOne(x => x.Smartphone)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.SmartphoneId);
        
        modelBuilder.Entity<SmartphonesInOrdersEntity>()
            .HasOne(x => x.Order)
            .WithMany(x => x.Smartphones)
            .HasForeignKey(x => x.OrderId);
        
        modelBuilder.Entity<SmartphonesInStoresEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<SmartphonesInStoresEntity>()
            .HasOne(x => x.Smartphone)
            .WithMany(x => x.Stores)
            .HasForeignKey(x => x.SmartphoneId);
        
        modelBuilder.Entity<SmartphonesInStoresEntity>()
            .HasOne(x => x.Store)
            .WithMany(x => x.Smartphones)
            .HasForeignKey(x => x.SmartphoneId);
    }
}