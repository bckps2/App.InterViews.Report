namespace App.InterViews.Report.Contract.Service.Dtos;

public  class ServiceCompanyDto
{
    public int IdCompany { get; set; }
    public string? CompanyName { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public ICollection<ServiceProcessDto>? Process { get; set; }
}
