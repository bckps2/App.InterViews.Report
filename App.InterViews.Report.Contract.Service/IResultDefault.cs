using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Contract.Service
{
    public interface IResultDefault<Tobject, TDefaultValidation> 
    {
        Tobject ResultValue(Tobject? item, TDefaultValidation defaultValidation);
        TDefaultValidation ResultError(TDefaultValidation defaultValidation);
    }
}
