using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprotFy.Controller.Events
{
    public class SongToPlayListAdded
    {
        public string Userid { get; set; }
        public Guid PlayListId { get; set; }
        public Guid SongId { get; set; }
    }
}
