using System;
using System.Collections.Generic;

namespace SprotFy.Controller.Models
{
    public class Playlist
    {
        public string Userid { get; set; }
        public Guid PlayListId { get; set; }
        public Guid SongId { get; set; }
        public IEnumerable<Song> Songs { get; set; }
    }
}
