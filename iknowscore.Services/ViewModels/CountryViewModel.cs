using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using iknowscore.Services.ViewModels.Validators;

namespace iknowscore.Services.ViewModels
{
    public class CountryViewModel : IValidatableObject
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CountryViewModelValidator();
            var result = validator.Validate(this);

            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
