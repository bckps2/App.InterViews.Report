using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.InterViews.Report.CrossCutting.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeInterview
    {
        FirstInterView = 0,
        SecondInterView = 1,
        TechnicalInterView = 2,
        FinalInterView = 3
    }
}
