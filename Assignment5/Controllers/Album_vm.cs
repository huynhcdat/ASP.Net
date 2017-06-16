using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment5.Controllers
{
    public class AlbumBase
    {
        public AlbumBase()
        {

        }

        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }


    }

    public class ArtistBase
    {
        public ArtistBase()
        {

        }

        [Key]
        public int ArtistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }
    }



}