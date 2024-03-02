namespace App.InterViews.Report.Service.Dtos;

public class BaseDto
{
    public virtual Guid Id { get; set; }
    public virtual DateTime DateCreated { get; set; }
    public DateTime? ModifyDate { get; set; }
}
