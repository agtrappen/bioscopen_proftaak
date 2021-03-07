using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        [Required]
        public DateTime Date_sold { get; set; }
        [Required]
        //foreign key
        public ICollection<Shows> Shows { get; set; }
        [Required]
        //foreign key
        public ICollection<Seats> Seats { get; set; }
        [Required]
        //foreign key
        public ICollection<Customers> Customers { get; set; }

    }
}
