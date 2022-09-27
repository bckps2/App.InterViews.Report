using App.InterViews.Report.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Models
{
    public class ProcessModel
    {
        public string? JobPosition { get; set; }
        public int IdInterView { get; set; }
        public string? ExternalCompany { get; set; }
        public int IdCompany { get; set; }
        public string? RangeSalarial { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; } = DateTime.Now;
    }
}
