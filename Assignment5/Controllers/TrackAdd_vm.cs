using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment5.Controllers
{
    public class TrackAdd : TrackBase
    {
        public TrackAdd()
        {
            
        }

        

        [Range(1, Int32.MaxValue)]
        public int AlbumId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int MediaTypeId { get; set; }

    }

    public class TrackAddForm : TrackAdd
    {
        public TrackAddForm()
        {

        }
        [Display(Name = "Album")]

        public SelectList AlbumList { get; set; }


        public String AlbumTitle;



        [Display(Name = "Media type")]

        public SelectList MediaTypeList { get; set; }
        public String MediaTypeTitle;

    }
}