using App.InterViews.Report.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.InterViews.Report.Library.Entities
{
    public class InterView : BaseEntity
    {
        public string? InterViewersName { get; set; }
        public DateTime DateInterView { get; set; }
        public string? Email { get; set; }
        public string? Observations { get; set; }
        public InterviewType TypeInterView { get; set; }
        public Guid IdProcess { get; set; }
        public Process? Process { get; set; }
    }
}
