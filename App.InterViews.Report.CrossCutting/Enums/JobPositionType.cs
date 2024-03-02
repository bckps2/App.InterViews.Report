using System.Text.Json.Serialization;

namespace App.InterViews.Report.CrossCutting.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum JobPositionType
{
    None = 0,
    RRHH = 1,
    Tecnitian=2,
    CEO=3,
    PartOfTeam=4,
    TechLead=5,
    Unknown=6
}
