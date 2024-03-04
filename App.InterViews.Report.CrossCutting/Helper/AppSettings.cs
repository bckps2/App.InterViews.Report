namespace App.InterViews.Report.CrossCutting.Helper;

public class AppSettings
{
    public string Secret { get; set; }
    public string[] HostsAccepted { get; set; }
    public string[] HeadersAccepted { get; set; }
    public string[] MethodsAccepted { get; set; }
    public int MinutesToExpireToken { get; set; }
}
