using System.ComponentModel.DataAnnotations;

namespace App.InterViews.Report.Library.Entities;

public class BaseEntity
{
    [Key]
    public virtual Guid Id { get; set; }
    public virtual DateTime DateCreated { get; set; }
}
