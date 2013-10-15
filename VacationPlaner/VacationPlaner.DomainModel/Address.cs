using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace VacationPlaner.DomainModel
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Street name")]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }
        public string County { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
