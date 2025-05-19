using DigitalStore.Service.Controllers.Cities.Entities;
using FluentValidation;

namespace DigitalStore.Service.Validator.Cities;

public class UpdateCityRequestValidator : AbstractValidator<UpdateCityRequest>
{
    public UpdateCityRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(50)
            .WithMessage("Name must not exceed 50 characters")
            .Matches(@"^[\sa-zA-Zа-яА-ЯёЁ-]+$")
            .WithMessage("Name is invalid");
    }
}