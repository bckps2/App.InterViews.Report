using System.Text.Json.Serialization;

namespace App.InterViews.Report.CrossCutting.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoleType
{
    None = 0,
    Administrator = 1,
    User = 2,
}
