using App.InterViews.Report.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Library.Entities
{
    public class InterView
    {
        public InterView()
        {
        }

        [Key]
        public int IdInterview { get; set; }
        [NotMapped]
        public List<string>? NameInterViewers { get; set; }
        [JsonIgnore]
        public string? InterViewersName { get; set; }
        public DateTime DateInterView { get; set; }
        public string? Email { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Observations { get; set; }
       
        [Column(TypeName = "nvarchar(20)")]
        public TypeInterview TypeInterView { get; set; }


        [ForeignKey("Process")]
        public int IdProcess { get; set; }
        public Process? Process { get; set; }
    }
}
