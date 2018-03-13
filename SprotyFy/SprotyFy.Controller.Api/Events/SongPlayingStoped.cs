using System;

namespace SprotyFy.Controller.Api.Events
{
    public class SongPlayingStoped
    {
        public string Userid { get; set; }
        public Guid SongId { get; set; }
        public int Sec { get; set; }
    }
}
