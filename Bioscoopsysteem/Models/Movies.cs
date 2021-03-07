using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int duration { get; set; }
        //foreign key
        public Shows Shows { get; set; }

    }
}
