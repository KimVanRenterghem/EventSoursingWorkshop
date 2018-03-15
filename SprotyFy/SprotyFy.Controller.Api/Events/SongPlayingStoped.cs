using System;

namespace SprotyFy.Controller.Api.Events
{
    public class SongPlayingStoped : IEvent
    {
        public string Userid { get; set; }
        public Guid SongId { get; set; }
        public int Sec { get; set; }
        public string Stream()
            => "usersong-" + Userid;
        public string EventName()
            => "SongPlayingStoped";
    }
}
