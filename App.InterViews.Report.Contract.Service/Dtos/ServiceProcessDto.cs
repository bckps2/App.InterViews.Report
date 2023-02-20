using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Contract.Service.Dtos
{
    public class ServiceProcessDto
    {
        public string? JobPosition { get; set; }
        public int IdCompany { get; set; }
        public string? ExternalCompany { get; set; }
        [Required]
        public string? RangeSalarial { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; } = DateTime.Now;
    }
}
