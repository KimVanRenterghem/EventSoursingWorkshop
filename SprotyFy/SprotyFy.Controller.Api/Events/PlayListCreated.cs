using System;

namespace SprotyFy.Controller.Api.Events
{
    public class PlayListCreated : IEvent
    {
        public string Uresid { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Stream()
            => "playlist-" + Id.ToString().Replace("-","");

        public string EventName()
            => "PlayListCreated";
    }
}