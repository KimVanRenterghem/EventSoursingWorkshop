using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using SprotyFy.Controller.Api.Events;
using SprotyFy.Controller.Api.Repository;

namespace SprotyFy.Controller.Api.Models
{
    public class PlayListProjector : IProjector
    {
        private readonly List<ResolvedEvent> _eves;
        private Playlist _playList;

        public PlayListProjector()
        {
            _eves = new List<ResolvedEvent>();
        }
        public void Project(IEnumerable<ResolvedEvent> eves)
        {
            _eves.AddRange(eves);

            foreach (var eve in eves)
            {
                var json = Encoding.UTF8.GetString(eve.Event.Data);
                if (eve.Event.EventType == "PlayListCreated")
                {
                    var create = JsonConvert.DeserializeObject<PlayListCreated>(json);

                    Project(create);

                }
                else if (eve.Event.EventType == "SongFromPlayListRemoved")
                {
                    var removeSong = JsonConvert.DeserializeObject<SongFromPlayListRemoved>(json);

                    Project(removeSong);
                }
                else if (eve.Event.EventType == "SongToPlayListAdded")
                {
                    var addSong = JsonConvert.DeserializeObject<SongToPlayListAdded>(json);

                    Project(addSong);

                }
            }
        }

        private void Project(SongFromPlayListRemoved removeSong)
        {
            _playList.Songs = _playList.Songs
                .Where(s => s.Id != removeSong.SongId)
                .ToList();
        }

        private void Project(SongToPlayListAdded addSong)
        {
            var song = SongsRepository.Songs.FirstOrDefault(s => s.Id == addSong.SongId);
            if (song != null)
                _playList.Songs.Append(song);
        }

        private void Project(PlayListCreated create)
        {
            _playList = new Playlist()
            {
                PlayListId = create.Id,
                Userid = create.Uresid,
                Name = create.Name,
                Songs = new List<Song>()
            };
            PlayListRepository.Add(_playList);
        }
    }
}
