using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalconyTickets.mvc.model
{
    public class vwQueue
    {
        [Key, Column(TypeName = "varchar(36)")]
        public string queue_id { get; set; }
        public string user_name { get; set; }
        public string balcony_name { get; set; }
        [Column(TypeName = "bigint")]
        public int general_pos { get; set; }
        [Column(TypeName = "bigint")]
        public int queue_pos { get; set; }
        [Column(TypeName = "bigint")]
        public int avg_time { get; set; }

    }
}
