using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalconyTickets.mvc.model
{
    public class User
    {

        [Key, Column(TypeName = "varchar(36)")]
        public string user_id { get; set; }

        [Required]
        public string user_name { get; set; }
        
        [Required]
        public string user_identification { get; set; }
        
        public string user_status { get; set; }

        public DateTime user_created { get; set; }

        public DateTime? user_updated { get; set; }

    }
}

