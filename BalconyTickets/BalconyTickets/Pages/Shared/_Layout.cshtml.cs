using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyTickets.mvc.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace BalconyTickets.Pages.Shared._Layout
{
    public class IndexModel : PageModel
    {


        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db) {
            _db = db;
        }


        public async Task OnGet()
        {
            
        }

    }
}
