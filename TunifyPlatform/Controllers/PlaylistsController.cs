using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IRepository<Playlist> _playlistRepository;

        public PlaylistsController(IRepository<Playlist> playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return Ok(await _playlistRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
            var playlist = await _playlistRepository.GetById(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return Ok(playlist);
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            await _playlistRepository.Add(playlist);
            return CreatedAtAction(nameof(GetPlaylist), new { id = playlist.Id }, playlist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return BadRequest();
            }
            await _playlistRepository.Update(playlist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var playlist = await _playlistRepository.GetById(id);
            if (playlist is null)
            {
                return NotFound();
            }
            await _playlistRepository.Delete(id);
            return NoContent();
        }

    }
}
