﻿namespace App.InterViews.Report.Library.Entities
{
    public class Company : BaseEntity
    {
        public string? CompanyName { get; set; }
        public virtual ICollection<Process>? Process { get; set; }
    }
}
