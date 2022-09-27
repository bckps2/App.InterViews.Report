using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Contract.Service.Models
{
    public  class ServiceCompanyModel
    {
        public string? CompanyName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
