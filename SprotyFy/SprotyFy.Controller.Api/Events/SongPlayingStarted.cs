using System;

namespace SprotyFy.Controller.Api.Events
{
    public class SongPlayingStarted : IEvent
    {
        public string Userid { get; set; }
        public Guid SongId { get; set; }
        public int Sec { get; set; }

        public string Stream()
            => "usersong-" + Userid.Replace("-", "");
        public string EventName()
            => "SongPlayingStarted";
    }
}
