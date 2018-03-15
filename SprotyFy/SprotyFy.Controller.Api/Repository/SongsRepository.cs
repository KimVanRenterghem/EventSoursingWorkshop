using System;
using System.Collections.Generic;
using SprotyFy.Controller.Api.Models;

namespace SprotyFy.Controller.Api.Repository
{
    public static class SongsRepository
    {
        private static  IEnumerable<Song> _songs = new[]
            {
                new Song
                {
                    Name = "Blue Monday",
                    Artist = "New Order",
                    Id = new Guid( "b07be609-3131-488e-8b4e-545e856bcf4d"),
                    Lenth = 30
                },
                new Song
                {
                    Name = "Mia",
                    Artist = "Gorki",
                    Id = new Guid( "7261ad49-1983-477e-8b90-20de40c48db2"),
                    Lenth = 30
                },
                new Song
                {
                    Name = "Roses",
                    Artist = "dEUS",
                    Id = new Guid( "67ab8127-0d8b-4903-af6c-252be606d732"),
                    Lenth = 30
                },
                new Song
                {
                    Name = "The Architect",
                    Artist = "dEUS",
                    Id = new Guid( "10183d60-e345-49a5-8a3b-4791d6dac93e"),
                    Lenth = 30
                },
                new Song
                {
                    Name = "You gonne want me",
                    Artist = "Tiga",
                    Id = new Guid( "c2ad2ec7-48bb-4903-93d3-d17df2f8e99b"),
                    Lenth = 30
                },
                new Song
                {
                    Name = "Emerge",
                    Artist = "Fischerspooner",
                    Id = new Guid( "9a3a885e-4a3d-4146-b6ff-999c6c07d05e"),
                    Lenth = 30
                },
                new Song
                {
                    Name = "100",
                    Artist = "Zita Swoon",
                    Id = new Guid( "e02d7509-dcd3-4406-8a94-d583206e1c3d"),
                    Lenth = 30
                },
                new Song
                {
                    Name = "The Pretender",
                    Artist = "Foo Fighters",
                    Id = new Guid( "fb16874c-d714-45f8-986f-c6e0d6f6a76c"),
                    Lenth = 30
                },
                new Song
                {
                    Name = "The Sound of C",
                    Artist = "Confetti's",
                    Id = new Guid( "6806bb5d-368c-45b9-90f0-827a28064b30"),
                    Lenth = 30
                }
            };

        public static IEnumerable<Song> Songs
            => _songs;
    }
}
