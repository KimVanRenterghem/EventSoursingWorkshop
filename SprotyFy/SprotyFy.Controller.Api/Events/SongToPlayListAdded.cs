using System;

namespace SprotyFy.Controller.Api.Events
{
    public class SongToPlayListAdded : IEvent
    {
        public string Userid { get; set; }
        public Guid PlayListId { get; set; }
        public Guid SongId { get; set; }
        public string Stream()
            => "playlist_" + PlayListId.ToString().Replace("-", "");

        public string EventName()
            => "SongFromPlayListRemoved";
    }
}
