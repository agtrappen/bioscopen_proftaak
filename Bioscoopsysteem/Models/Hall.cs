using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Hall
    {
        [Key]
        public int HallId { get; set; }
        [Required]//not null
        public int  Capacity { get; set; }
        [Required]//not null
        public bool Wheelchair_accessable { get; set; }
        
        public ICollection<Show> Shows { get; set; }

    }
}
