using App.InterViews.Report.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InterViews.Report.Library.Extensions
{
    public static class ExtensionInterview
    {
        public static void SetInterViewersName(this InterView interView)
        {
            if(interView.NameInterViewers != null) 
            {
                interView.InterViewersName = string.Join(", ", interView.NameInterViewers.FindAll(c => c.Length > 0));
            }
        }

        public static void SetNameInterViewers(this InterView interView)
        {
            interView.NameInterViewers = interView.InterViewersName?.Split(',').ToList();
        }
    }
}
