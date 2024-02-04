using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.InterViews.Report.Library.Entities
{
    public class Process : BaseEntity
    {
        public Process()
        {

        }

        [Key]
        public Guid Id { get; set; }
        public string? RangeSalarial { get; set; }
        public string? ExternalCompany { get; set; }
        public string? JobPosition { get; set; }
        public IList<InterView>? Interviews { get; set; }

        [ForeignKey("Company")]
        public Guid IdCompany { get; set; }
        public Company? Company { get; set; }
    }
}
