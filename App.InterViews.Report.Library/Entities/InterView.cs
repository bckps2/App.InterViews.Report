using App.InterViews.Report.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.InterViews.Report.Library.Entities
{
    public class InterView : BaseEntity
    {
        [Key]
        public int IdInterview { get; set; }
        public string? InterViewersName { get; set; }
        public DateTime DateInterView { get; set; }
        public string? Email { get; set; }
        public string? Observations { get; set; }
       
        [Column(TypeName = "nvarchar(20)")]
        public TypeInterview TypeInterView { get; set; }

        [ForeignKey("Process")]
        public int IdProcess { get; set; }
        public Process? Process { get; set; }
    }
}
