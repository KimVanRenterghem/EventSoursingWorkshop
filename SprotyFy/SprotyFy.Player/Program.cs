using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using SprotyFy.Controller.Api.Events;

namespace SprotyFy.Player
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();
            Console.WriteLine("enter username");
            var user = Console.ReadLine();
            var stream = "usersong-" + user;

            Song last = null;
            bool plaing = false;
            while (true)
            {
                var eveTask = connection.ReadEventAsync(stream, -1, true);
                eveTask.Wait();
                var eve = eveTask.Result;

                var ev = eve.Event?.Event;
                if (ev != null)
                {
                    var json = Encoding.UTF8.GetString(ev.Data);
                    if (ev.EventType == "SongPlayingStarted")
                    {
                        plaing = true;
                        var start = JsonConvert.DeserializeObject<SongPlayingStarted>(json);
                        if (start.SongId != last?.Id)
                        {
                            last = SongsRepository.Songs.FirstOrDefault(s => s.Id == start.SongId);
                            Console.WriteLine($"playing song is {last.Name} - {last.Artist}");
                        }
                    }
                    else if (ev.EventType == "SongPlayingStoped")
                    {
                        var start = JsonConvert.DeserializeObject<SongPlayingStoped>(json);
                        if (start.SongId != last.Id || plaing)
                        {
                            plaing = false;
                            last = SongsRepository.Songs.FirstOrDefault(s => s.Id == start.SongId);
                            Console.WriteLine($"last plaied song is {last.Name} - {last.Artist}");
                        }
                    }

                }

                Task.Delay(150).Wait();
            }


            connection.Dispose();
            Console.WriteLine("");
        }
    }
}
