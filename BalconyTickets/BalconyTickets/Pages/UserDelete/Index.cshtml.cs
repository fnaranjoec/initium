using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BalconyTickets.mvc.model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace BalconyTickets.Pages.BalconyDelete
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

        public async Task OnGet(string id)
        {
            Balcony = await _db.Balcony.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var BalconyFromDb = await _db.Balcony.FindAsync(Balcony.balcony_id);
                BalconyFromDb.balcony_status = "X";
                BalconyFromDb.balcony_updated = DateTime.Now;

                await _db.SaveChangesAsync();

                return RedirectToPage("/BalconyList/Index");

            }
            else
            {
                return Page();
            }

        }

    }
}
