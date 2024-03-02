namespace App.InterViews.Report.Library.Entities;

public class Process : BaseEntity
{
    public string? RangeSalarial { get; set; }
    public string? ExternalCompany { get; set; }
    public string? JobPosition { get; set; }
    public Guid IdCompany { get; set; }
    public Company? Company { get; set; }
    public IList<Interview>? Interviews { get; set; }
}
