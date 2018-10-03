using FluentValidation;

namespace iknowscore.Services.ViewModels.Validators
{
    public class CountryViewModelValidator : AbstractValidator<CountryViewModel>
    {
        public CountryViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field is required");
        }
    }
}
