using App.InterViews.Report.CrossCutting.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Models
{
    public class InterviewModel
    {
        public int IdInterview { get; set; }
        [Required]
        public int IdProcess { get; set; }
        [Required]
        public TypeInterview TypeInterView { get; set; }
        [Required]
        public List<string>? NameInterViewers { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateInterView { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Observations { get; set; }
        public DateTime DateCreated { get; } = DateTime.Now;
    }
}