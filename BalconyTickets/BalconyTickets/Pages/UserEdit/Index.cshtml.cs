using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BalconyTickets.mvc.model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BalconyTickets.Pages.UserEdit
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task OnGet(string id)
        {
            User = await _db.User.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var UserFromDb = await _db.User.FindAsync(User.user_id);
                UserFromDb.user_name = User.user_name;
                UserFromDb.user_identification = User.user_identification;
                UserFromDb.user_updated = DateTime.Now;

                await _db.SaveChangesAsync();

                return RedirectToPage("/UserList/Index");

            }
            else
            {
                return Page();
            }

        }

    }
}
