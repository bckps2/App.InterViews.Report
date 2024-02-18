using System.ComponentModel.DataAnnotations;

namespace App.InterViews.Report.Library.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? ModifyDate { get; set; }
}
