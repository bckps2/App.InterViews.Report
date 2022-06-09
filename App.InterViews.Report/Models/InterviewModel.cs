using App.InterViews.Report.CrossCutting.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Models
{
    public class InterviewModel
    {
        public int IdInterView { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public List<InformationInterViewModel> InformationInterViews { get; set; } = new List<InformationInterViewModel>();
        public string RangeSalarial { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get;  } = DateTime.Now;
    }
}
