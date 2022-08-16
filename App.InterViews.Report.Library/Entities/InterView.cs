using App.InterViews.Report.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Library.Entities
{
    public class InterView
    {
        [Key]
        public int IdInterview { get; set; }
        public int IdProcess { get; set; }
        [NotMapped]
        public List<string> NameInterViewers { get; set; }
        [JsonIgnore]
        public string InterViewersName { get; set; }
        public DateTime DateInterView { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public string Observations { get; set; }
        public void SetNameInterViewers()
        {
            InterViewersName = string.Join(", ", NameInterViewers.FindAll(c => c.Length > 0));
        }

        public void SetListInterViewers()
        {
            NameInterViewers = InterViewersName.Split(',').ToList();
        }

        [Column(TypeName = "nvarchar(20)")]
        public TypeInterview TypeInterView { get; set; }
    }
}
