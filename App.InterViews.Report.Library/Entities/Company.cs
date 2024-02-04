using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.InterViews.Report.Library.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {

        }

        [Key]
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public virtual ICollection<Process>? Process { get; set; }
    }
}
