using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyTickets.mvc.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BalconyTickets.Pages.UserList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db) {
            _db = db;
        }
        public IEnumerable<User> Users { get; set; }


        public async Task OnGet()
        {
            Users = await _db.User.Where(p=>p.user_status!="X").OrderBy(p => p.user_created).ToListAsync();
        }
    }
}
