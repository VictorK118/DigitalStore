using DigitalStore.Service.Controllers.Cities.Entities;
using FluentValidation;

namespace DigitalStore.Service.Validator.Cities;

public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
{
    public CreateCityRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(50)
            .WithMessage("Name must not exceed 50 characters")
            .Matches(@"^[\sa-zA-Zа-яА-ЯёЁ-]+$")
            .WithMessage("Name is invalid");
    }
}