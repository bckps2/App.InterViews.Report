using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.InterViews.Report.Library.Entities
{
    public class Company
    {
        [Key]
        [Column(Order = 1)]
        public int IdCompany { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<InterView> InterViews { get; set; }
        public string TestName { get; set; }
    }
}
