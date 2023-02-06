using App.InterViews.Report.Contract.Service;
using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace App.InterViews.Report.Db.Infrastructure
{
    public class ResultDefault<Tobject, TDefaultValidation> : 
        IResultDefault<Tobject, TDefaultValidation> 
        where TDefaultValidation : ValidationResult
        where Tobject : class
    {
        public Tobject ResultValue(Tobject? item, TDefaultValidation defaultValidation)
        {
            return item;
        }

        public TDefaultValidation ResultError(TDefaultValidation defaultValidation)
        {
            return defaultValidation;
        }
    }
}
