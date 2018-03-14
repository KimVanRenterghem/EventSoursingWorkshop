using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SprotyFy.Controller.Api.Events;
using SprotyFy.Controller.Api.Models;
using SprotyFy.Controller.Api.Repository;

namespace SprotyFy.Controller.Api.Controllers
{
    [Route("api/PlayList")]
    public class PlayListController
    {
        private EventPublisher _eventPublisher;

        public PlayListController()
        {
            _eventPublisher = new EventPublisher();
        }

        [HttpGet("user/{user}")]
        public IEnumerable<Playlist> Get(string user)
            => PlayListRepository.Playlists
            .Where(p => p.Userid == user)
            .ToArray();


        [HttpGet("id/{id}")]
        public Playlist Get(Guid id)
            => PlayListRepository.Playlists
                .FirstOrDefault(p => p.PlayListId == id);


        [HttpPost]
        public void Post([FromBody]PlayListCreated eve)
        {
            eve.Id = Guid.NewGuid();
            _eventPublisher.Publish(eve);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]SongToPlayListAdded eve)
        {
            eve.PlayListId = id;
            _eventPublisher.Publish(eve);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id, [FromBody]SongFromPlayListRemoved eve)
        {
            eve.PlayListId = id;
            _eventPublisher.Publish(eve);
        }
    }
}
