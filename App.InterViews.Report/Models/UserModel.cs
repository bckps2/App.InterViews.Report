using App.InterViews.Report.Service.Dtos;

namespace App.InterViews.Report.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public CompanyModel Company { get; set; }
}
