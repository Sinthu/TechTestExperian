using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperianApi.Models
{
    public class User
    {
        public User() { }

        public int UserId { get; set; }

        public int AlbumId { get; set; }

        public int PhotoId { get; set; }

        public string AlbumTitle { get; set; }

        public string PhotoTitle { get; set; }

        public string PhotoUrl { get; set; }

        public string PhotoThumbnailUrl { get; set; }


    }
}
