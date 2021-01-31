using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BalconyTickets.mvc.model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;

namespace BalconyTickets.Pages.UserCreate
{
    public class IndexModel : PageModel
    {

        public readonly ApplicationDbContext _db;
        public IEnumerable<Balcony> BalconiesList { get; set; }
        public IEnumerable<Queue> QueuesList { get; set; }


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public User User { get; set; }
        public Queue Queue { get; set; }
        public string returnPage { get; set; }

        public void OnGet(string rp)
        {

            returnPage = rp;
        }

        public async Task<IActionResult> OnPost()
        {
            

            User.user_id = System.Guid.NewGuid().ToString();
            User.user_status = "A";
            User.user_created = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    // Add to User
                    await _db.User.AddAsync(User);
                    await _db.SaveChangesAsync();

                    // Add to Queue
                    await SaveQueue();

                    var previous = RouteData.Values["rp"].ToString().Replace("%2F","/");

                    return RedirectToPage(previous);

                }
                catch (SqlException e)
                {
                    throw new Exception(e.InnerException.Message);
                    // return Page();
                }
            }
            else
            {
                return Page();
            }

        }


        public async Task SaveQueue() {

            try
            {
                // Get most fast queue PROCESS
                // Get Queues
                BalconiesList = await _db.Balcony.Where(p => p.balcony_status != "X").OrderBy(p => p.balcony_created).ToListAsync();
                // Calculate Timed Queues
                var timedQueues = new Dictionary<string, int>() { };
                foreach (var balcony in BalconiesList)
                {
                    QueuesList = await _db.Queue.Where(p => ((p.queue_status != "X") && (p.balcony_id == balcony.balcony_id))).OrderBy(p => p.queue_created).ToListAsync();
                    timedQueues.Add(balcony.balcony_id, balcony.balcony_average * QueuesList.Count());

                }
                // Sort Timed Queues
                var fastQueue = timedQueues.OrderBy(p => p.Value).First();

                // Get Average time at moment
                var balconyAverage = BalconiesList.Where(p => p.balcony_id == fastQueue.Key).First().balcony_average;

                // Add user on Queue
                Queue = new Queue();
                Queue.balcony_id = fastQueue.Key;
                Queue.user_id = User.user_id;
                Queue.queue_id = System.Guid.NewGuid().ToString();
                Queue.queue_status = "A";
                Queue.queue_created = DateTime.Now;
                Queue.queue_average = balconyAverage;

                // Save user on Queue
                // Add User
                await _db.Queue.AddAsync(Queue);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }


            
        }

    }
}
