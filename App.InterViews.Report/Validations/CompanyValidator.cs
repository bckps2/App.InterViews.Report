using FluentValidation;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Validations
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name company can't be null or empty");
        }
    }
}
