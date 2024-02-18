using System.Text.Json.Serialization;
using App.InterViews.Report.Service.Dtos.User;

namespace App.InterViews.Report.Service.Dtos.Company
{
    public class CompanyUserDto : BaseDto
    {
        public string? CompanyName { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<UserDto> Users { get; set; }
        public IList<ProcessDto>? Process { get; set; }
    }
}
