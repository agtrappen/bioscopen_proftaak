using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }
        [Required]
        public int Row_number { get; set; }
        [Required]
        public int Seat_number { get; set; }
        [Required]
        public int HallId { get; set; }
    
    }
}
