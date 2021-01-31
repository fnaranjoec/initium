using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BalconyTickets.mvc.model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BalconyTickets.Pages.BalconyCreate
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Balcony Balcony { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() {

            Balcony.balcony_id = System.Guid.NewGuid().ToString();
            Balcony.balcony_status = "A";
            Balcony.balcony_created = DateTime.Now;

            if (ModelState.IsValid) {

                await _db.Balcony.AddAsync(Balcony);
                await _db.SaveChangesAsync();
                return RedirectToPage("/BalconyList/Index");

            }
            else {
                return Page();
            }         

        }

    }
    
}
