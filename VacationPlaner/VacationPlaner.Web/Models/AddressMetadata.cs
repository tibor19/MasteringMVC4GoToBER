using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VacationPlaner.Web.Models
{
    public class AddressMetadata
    {
        [Display(Name="Street name")]
        public string Street { get; set; }
    }
}