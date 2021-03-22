using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }
        [Required]
        public DateTime Start_date { get; set; }
        [Required]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]
        public double Ticket_price { get; set; }
    }
}
