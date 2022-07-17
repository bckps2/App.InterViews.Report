using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Library.Entities
{
    public class InterView
    {
        [Key]
        public int IdInterView { get; set; }
        public string RangeSalarial { get; set; }
        public DateTime DateCreated { get; set; }
        public int CompanyIdCompany { get; set; }
        public string ExternalCompany { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<InformationInterView> InformationInterViews { get; set; }
    }
}
