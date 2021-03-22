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
        public Customer Customer { get; set; }
        [Required]
        //foreign key
        public int ShowId { get; set; }
        public Show Show { get; set; }
        [Required]
        //foreign key
        public int SeatId { get; set; }
        public Seat Seat { get; set; }

        [Required]
        public int TariffId { get; set; }
        public Tariff Tariff { get; set; }

        public int? ArrangementId { get; set; }
        public Arrangement? Arrangement { get; set; }

        public Ticket()
        {
            Date_sold = DateTime.Now;
        }

    }
}
