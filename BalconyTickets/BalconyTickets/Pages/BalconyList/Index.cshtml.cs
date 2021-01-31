using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyTickets.mvc.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BalconyTickets.Pages.BalconyList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db) {
            _db = db;
        }
        public IEnumerable<Balcony> Balconies { get; set; }


        public async Task OnGet()
        {
            Balconies = await _db.Balcony.Where(p=>p.balcony_status!="X").OrderBy(p => p.balcony_created).ToListAsync();
        }
    }
}
