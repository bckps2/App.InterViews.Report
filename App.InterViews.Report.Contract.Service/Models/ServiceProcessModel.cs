using App.InterViews.Report.CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.InterViews.Report.Contract.Service.Models
{
    public class ServiceProcessModel
    {
        public string JobPosition { get; set; }
        public int IdInterView { get; set; }
        public int CompanyIdCompany { get; set; }
        public string ExternalCompany { get; set; }
        //[Required]
        //public ServiceProcessModel InformationInterview { get; set; } = new ServiceProcessModel();
        [Required]
        public string RangeSalarial { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; } = DateTime.Now;
    }
}
