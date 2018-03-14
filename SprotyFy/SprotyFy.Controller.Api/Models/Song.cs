using System;

namespace SprotyFy.Controller.Api.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Lenth { get; set; }
    }
}
