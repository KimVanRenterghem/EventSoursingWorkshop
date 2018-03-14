using System;

namespace SprotyFy.Controller.Api.Events
{
    public class SongFromPlayListRemoved : IEvent
    {
        public string Userid { get; set; }
        public Guid PlayListId { get; set; }
        public Guid SongId { get; set; }
        public string Stream()
            => "PlayList_" + PlayListId;
        public string EventName()
            => "SongFromPlayListRemoved";
    }
}
