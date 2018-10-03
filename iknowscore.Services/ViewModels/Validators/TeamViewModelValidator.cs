using FluentValidation;

namespace iknowscore.Services.ViewModels.Validators
{
    public class TeamViewModelValidator : AbstractValidator<TeamViewModel>
    {
        public TeamViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field is required");
        }
    }
}
