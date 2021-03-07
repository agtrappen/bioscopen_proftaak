using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Seats
    {
        [Key]
        public int SeatId { get; set; }

        [Required]
        public int row_number { get; set; }
        [Required]
        public int seat_number { get; set; }
        public Tickets Tickets { get; set; }
        [Required]
        //foreign key
        public ICollection<Halls> Halls { get; set; }

    }
}
