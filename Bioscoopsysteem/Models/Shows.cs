using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Shows
    {
        [Key]
        public int ShowsId { get; set; }
        [Required]
        public DateTime Start_date { get; set; }
        [Required]
        public ICollection<Movies> Movies { get; set; }
        [Required]
        public ICollection<Halls> Halls { get; set; }
        //foreign key
        public Tickets Tickets { get; set; }

    }
}
