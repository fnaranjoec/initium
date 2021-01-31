using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalconyTickets.mvc.model
{
    public class Balcony
    {

        [Key, Column(TypeName = "varchar(36)")]
        public string balcony_id { get; set; }

        [Required]
        public string balcony_name { get; set; }

        [Required]
        public int balcony_average { get; set; }

        public string balcony_status { get; set; }

        public DateTime balcony_created { get; set; }

        public DateTime? balcony_updated { get; set; }

    }
}
