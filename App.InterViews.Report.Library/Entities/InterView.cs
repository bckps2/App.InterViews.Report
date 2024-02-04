using App.InterViews.Report.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.InterViews.Report.Library.Entities
{
    public class InterView : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? InterViewersName { get; set; }
        public DateTime DateInterView { get; set; }
        public string? Email { get; set; }
        public string? Observations { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public InterviewType TypeInterView { get; set; }

        [ForeignKey("Process")]
        public Guid IdProcess { get; set; }
        public Process? Process { get; set; }
    }
}
