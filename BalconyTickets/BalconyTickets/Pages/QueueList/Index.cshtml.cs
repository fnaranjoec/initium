using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalconyTickets.mvc.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BalconyTickets.Pages.QueueList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db) {
            _db = db;
        }
        public IEnumerable<vwQueue> Queues { get; set; }


        public async Task OnGet(string id)
        {
            Queues = await _db.vwQueue.OrderBy(p => p.general_pos).ToListAsync();
           
        }


        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {

            var Queue = await _db.Queue.FindAsync(id);

            if (Queue != null)
            {
                // _db.Queue.Remove(Queue); //Remove phisically
                Queue.queue_status ="X";
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }


    }
}
