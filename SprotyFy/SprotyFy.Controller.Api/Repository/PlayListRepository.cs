using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SprotyFy.Controller.Api.Models;

namespace SprotyFy.Controller.Api.Repository
{
    public static class PlayListRepository
    {
        private  static  readonly  List<Playlist> _playlists = new List<Playlist>();
        public static IEnumerable<Playlist> Playlists => _playlists;

        public static void Add(Playlist playlist)
            => _playlists.Add(playlist);
    }
}
