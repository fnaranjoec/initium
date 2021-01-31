using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalconyTickets.mvc.model
{
    public class Queue
    {
        [Key, Column(TypeName = "varchar(36)")]
        public string queue_id { get; set; }

        [Required]
        public string balcony_id { get; set; }

        [Required]
        public string user_id { get; set; }

        public string queue_status { get; set; }

        public DateTime queue_created { get; set; }

        public DateTime? queue_released { get; set; }

        [Required]
        public int queue_average { get; set; }

    }
}
