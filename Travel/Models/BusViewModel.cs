using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class BusViewModel
    {
        [Required]
        [Display(Name = "C_id")]
        public int C_id { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        public List<Table_city> citylist { get; set; }
    }
}