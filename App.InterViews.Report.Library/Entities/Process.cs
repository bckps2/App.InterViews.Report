using App.InterViews.Report.CrossCutting.Enums;
using App.InterViews.Report.Library.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Library.Entities
{
    public class Process
    {
        public Process()
        {
            Interviews?.ToList().ForEach(c => c.SetNameInterViewers());
        }

        [Key]
        public int IdProcess { get; set; }
        public string? RangeSalarial { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ExternalCompany { get; set; }
        public string? JobPosition { get; set; }
        public ICollection<InterView>? Interviews { get; set; }

        [ForeignKey("Company")]
        public int IdCompany { get; set; }
        public Company? Company { get; set; }
    }
}
