using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string subtitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Actor { get; set; }
        [Required]
        public string Writting { get; set; }
        [Required]
        public DateTime releaseDate { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int HallId { get; set; }

    }
}
