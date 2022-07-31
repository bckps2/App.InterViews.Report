using App.InterViews.Report.CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Contract.Service.Models
{
    public class ServiceInformationModel
    {
        [Required]
        public int InterViewIdInterView { get; set; }
        public int IdInformation { get; set; }
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
