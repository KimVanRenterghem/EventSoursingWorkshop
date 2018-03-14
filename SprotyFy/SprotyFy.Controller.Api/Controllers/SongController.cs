using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SprotFy.Controller.Models;
using SprotFy.Controller.Repository;
using SprotyFy.Controller.Api;
using SprotyFy.Controller.Api.Events;

namespace SprotFy.Controller.Controllers
{
    [Route("api/Song")]
    public class SongController 
    {
        private EventPublisher _eventPublisher;

        public SongController()
        {
            _eventPublisher = new EventPublisher();
        }
        [HttpGet]
        public IEnumerable<Song> Get()
            => SongsRepository.Songs;
        
        [HttpGet("{id}")]
        public Song Get(Guid id)
            => SongsRepository.Songs
            .FirstOrDefault(song => song.Id == id);
        
        [HttpPost("{id}/{user}/{sec}")]
        public void Start(Guid id, string user, int sec = 0)
        {
            var eve = new SongPlayingStarted()
            {
                Userid = user,
                SongId = id,
                Sec = sec
            };
            _eventPublisher.Publish(eve);
        }
        
        
        [HttpDelete("{id}/{user}/{sec}")]
        public void Stop(Guid id, string user, int sec = 0)
        {
            var eve = new SongPlayingStoped()
            {
                Userid = user,
                SongId = id,
                Sec = sec
            };
            _eventPublisher.Publish(eve);
        }
    }
}
