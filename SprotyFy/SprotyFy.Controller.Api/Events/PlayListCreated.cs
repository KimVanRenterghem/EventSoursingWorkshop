using System;

namespace SprotyFy.Controller.Api.Events
{
    public class PlayListCreated : IEvent
    {
        public string Uresid { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Stream()
            => "PlayList_" + Id;

        public string EventName()
            => "PlayListCreated";
    }
}