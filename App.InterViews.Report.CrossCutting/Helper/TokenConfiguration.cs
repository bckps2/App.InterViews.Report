namespace App.InterViews.Report.CrossCutting.Helper;

public class TokenConfiguration
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public int MinutesToExpireToken { get; set; }
}
