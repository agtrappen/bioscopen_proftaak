using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Models
{
    public class Customers
    {
        [Key]
        public int CustomersId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        public Tickets Tickets { get; set; }

    }
}
