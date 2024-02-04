using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Models;
using FluentValidation;

namespace App.InterViews.Report.Validations
{
    public class CompanyValidator : AbstractValidator<CompanyModel>
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
