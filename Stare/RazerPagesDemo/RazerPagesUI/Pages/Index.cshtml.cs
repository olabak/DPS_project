using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazerPagesUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty(SupportsGet = true)] //Zmiana welcome user na ola itp
        public string City { get; set; }
        public void OnGet() //
        {
            if(string.IsNullOrWhiteSpace(City))
            {
                City = "The web";
            }
        }
        
    }
}
