using System.Text.Json.Serialization;

namespace App.InterViews.Report.CrossCutting.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DocumentType
{
    NIF = 0,
    NIE = 1,
    PAS = 2
}
