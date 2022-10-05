using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MySuperApp.Pages.Calendar
{
    public class AddAddTypeModel : PageModel
    {
        [BindProperty]
        public AddTypeModel AddType { get; set; }
        public void OnGet()
        {

        }
    }
}
