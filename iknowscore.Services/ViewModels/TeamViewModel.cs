using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using iknowscore.Services.ViewModels.Validators;

namespace iknowscore.Services.ViewModels
{
    public class TeamViewModel : IValidatableObject
    {
        public int TeamId { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public CountryViewModel Country { get; set; }
        public byte[] ImageFile { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new TeamViewModelValidator();
            var result = validator.Validate(this);

            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
