using App.InterViews.Report.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.InterViews.Report.Library.Entities
{
    public class InformationInterView
    {
        [Key]
        public int IdInformation { get; set; }
        public int InterViewIdInterView { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<string> NameInterViewers { get; set; }
        public string InterViewersName { get; set; }
        public DateTime DateInterView { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public void SetNameInterViewers() 
        {
            foreach (var item in NameInterViewers)
            {
                InterViewersName += item;
            }
        }

        [Column(TypeName = "nvarchar(20)")]
        public TypeInterview TypeInterView { get; set; }
        public virtual InterView InterView { get; set; }
    }
}
