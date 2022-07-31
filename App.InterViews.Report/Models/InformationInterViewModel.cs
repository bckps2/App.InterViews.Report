using App.InterViews.Report.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Models
{
    public class InformationInterViewModel
    {
        public int IdInformation { get; set; }
        [Required]
        public int InterViewIdInterView { get; set; }
        [Required]
        public TypeInterview TypeInterView { get; set; }
        [Required]
        public List<string> NameInterViewers { get; set; }
        public DateTime DateInterView { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Observations { get; set; }
        public DateTime DateCreated { get; } = DateTime.Now;
    }
}
