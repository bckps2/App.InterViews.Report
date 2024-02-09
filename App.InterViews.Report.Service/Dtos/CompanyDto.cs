namespace App.InterViews.Report.Service.Dtos
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<UserDto> Users { get; set; }
        public IList<ProcessDto>? Process { get; set; }
    }
}
