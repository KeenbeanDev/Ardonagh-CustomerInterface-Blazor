using Ardonagh_CustomerInterface_Blazor.Components.Models;
using FluentValidation;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Ardonagh_CustomerInterface_Blazor.Components.Validators
{
    public class CustomerFluentValidator : AbstractValidator<Customer>
    {
        // Regular Expression for a UK Postcode
        public Regex postcodeRegex = new Regex(@"([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})");

        public CustomerFluentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 50);

            RuleFor(x => x.Age)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(110);

                RuleFor(x => x.Postcode)
                .NotEmpty()
                .Must(ValidatePostCode);

            RuleFor(x => x.Height)
                .NotEmpty()
                .GreaterThanOrEqualTo(0.0)
                .LessThanOrEqualTo(2.5);
        }

        public bool ValidatePostCode(string postcode) {
            if (string.IsNullOrEmpty(postcode))
                return false;

            if (postcode.Length > 8)
                return false;

            if (postcodeRegex.Match(postcode).Success)
                return true;


            return false;
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Customer>.CreateWithOptions((Customer)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
