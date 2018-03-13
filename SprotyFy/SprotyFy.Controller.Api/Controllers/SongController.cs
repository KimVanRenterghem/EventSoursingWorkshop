using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SprotFy.Controller.Models;
using SprotFy.Controller.Repository;

namespace SprotFy.Controller.Controllers
{
    [Route("api/Song")]
    public class SongController 
    {
        [HttpGet]
        public IEnumerable<Song> Get()
            => SongsRepository.Songs;
        
        [HttpGet("{id}")]
        public Song Get(Guid id)
            => SongsRepository.Songs
            .FirstOrDefault(song => song.Id == id);
        
        [HttpPost("{id}/{user}")]
        public void Start(Guid id, string user)
        {
        }
        
        
        [HttpDelete("{id}/{user}")]
        public void Stop(int id)
        {
        }
    }
}
