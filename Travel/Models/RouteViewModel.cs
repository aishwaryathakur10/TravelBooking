using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class RouteViewModel
    {
        [Required]
        [Display(Name = "R_id")]
        public int R_id { get; set; }

        [Required]
        [Display(Name = "R_name")]
        public string R_name { get; set; }

        public List<Table_route> routelist { get; set; }


    }
}