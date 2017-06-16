using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment5.Controllers
{
    public class TrackBase
    {
        public TrackBase()
        {

        }

        [Key]
        [Display(Name = "Track Id")]
        public int TrackId { get; set; }


        [Display(Name = "Track name")]
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(220)]
        [Display(Name = "Composer")]
        public string Composer { get; set; }

        [Display(Name = "Length(ms)")]
        public int Milliseconds { get; set; }

     

        [Display(Name = "Unit Price")]
        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }


    }
}