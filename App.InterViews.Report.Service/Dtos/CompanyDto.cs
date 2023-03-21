﻿
namespace App.InterViews.Report.Service.Dtos
{
    public class CompanyDto
    {
        public int IdCompany { get; set; }
        public string? CompanyName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public IList<ProcessDto>? Process { get; set; }
    }
}
