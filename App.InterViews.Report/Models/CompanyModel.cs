namespace App.InterViews.Report.Models
{
    public class CompanyModel
    {
        public string CompanyName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public InterviewModel Interview { get; set; }
    }
}
