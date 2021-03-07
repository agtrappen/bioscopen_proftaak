using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Halls
    {
        [Key]
        public int HallsId { get; set; }
        [Required]//not null
        public string name { get; set; }
        [Required]//not null
        public int  capacity { get; set; }
        [Required]//not null
        public bool wheelchair_accessable { get; set; }
        //foreign key
        public Shows Shows { get; set; }
        //foreign key
        public Seats Seats { get; set; }

    }
}
