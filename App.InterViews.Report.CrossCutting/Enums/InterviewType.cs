using System.Text.Json.Serialization;

namespace App.InterViews.Report.CrossCutting.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterviewType
    {
        FirstInterView = 0,
        SecondInterView = 1,
        TechnicalInterView = 2,
        FinalInterView = 3
    }
}
