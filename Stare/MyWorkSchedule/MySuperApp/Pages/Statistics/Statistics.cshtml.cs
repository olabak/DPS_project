using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MySuperApp.Pages.Statistics
{
    public class AddStatisticsModel : PageModel
    {
        public StatisticsModel Statistics { get; set; }
        
        public void OnGet()
        {
        }
    }
}
