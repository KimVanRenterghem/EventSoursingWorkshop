using System;

namespace SprotFy.Controller.Events
{
    public class PlayListCreated
    {
        public string Uresid { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}