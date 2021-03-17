using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Arrangement
    {
        [Key]
        public int ArrangementId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]     
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
    }
}
