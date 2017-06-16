using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment5.Controllers
{
    public class TrackWithDetail : TrackBase
    {
        public TrackWithDetail()
        {

        }


        [Display(Name = "Album title")]
        public string AlbumTitle { get; set; }
        // public string ArtistName { get; set; }

        [Display(Name = "Media type")]
        public MediaTypeBase MediaType { get; set; }



    }
}