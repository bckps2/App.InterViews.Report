namespace App.InterViews.Report.CrossCutting.CommonDto;

public class TokenConfiguration
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public int MinutesToExpireToken { get; set; }
}
