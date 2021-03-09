using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [Required]
        public DateTime Date_sold { get; set; }
        [Required]
        //foreign key
        public int CustomerId { get; set; }
        [Required]
        //foreign key
        public int ShowId { get; set; }
        [Required]
        //foreign key
        public int SeatId { get; set; }

        public Ticket()
        {
            Date_sold = DateTime.Now;
        }

    }
}
