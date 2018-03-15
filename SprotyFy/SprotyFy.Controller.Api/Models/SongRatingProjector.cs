using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using SprotyFy.Controller.Api.Events;
using SprotyFy.Controller.Api.Repository;

namespace SprotyFy.Controller.Api.Models
{
    public class SongRatingProjector : IProjector
    {
        public void Project(IEnumerable<ResolvedEvent> eves)
        {
            foreach (var eve in eves)
            {
                var json = Encoding.UTF8.GetString(eve.Event.Data);
                if (eve.Event.EventType == "SongPlayingStarted")
                {
                    var start = JsonConvert.DeserializeObject<SongPlayingStarted>(json);

                    Project(start);

                }
            }
        }

        private void Project(SongPlayingStarted start)
        {
            var song = SongsRepository.Songs.FirstOrDefault(s => s.Id == start.SongId);
            if (song == null)
                return;

            song.Played++;
        }
    }
}
