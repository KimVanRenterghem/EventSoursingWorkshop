using System;

namespace SprotyFy.Controller.Api.Events
{
    public class SongFromPlayListRemoved
    {
        public string Userid { get; set; }
        public Guid PlayListId { get; set; }
        public Guid SongId { get; set; }
    }
}
