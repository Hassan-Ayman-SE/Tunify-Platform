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
        private readonly IPlaylistService _playlistService;

        public PlaylistsController(IRepository<Playlist> playlistRepository, IPlaylistService playlistService)
        {
            _playlistRepository = playlistRepository;
            _playlistService = playlistService;
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

        //Lab 13 New Routes
        // GET api/playlists/{playlistId}/songs
        [Route("{playlistId}/songs")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsForPlaylist(int playlistId)
        {
            try
            {
                var songs = await _playlistService.GetSongsInPlaylistAsync(playlistId);
                return Ok(songs);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        // POST api/playlists/{playlistId}/songs/{songId}
        [Route("{playlistId}/songs/{songId}")]
        [HttpPost]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            try
            {
                // Add the song to the specified playlist
                await _playlistService.AddSongToPlaylist(playlistId, songId);

                // Return a 204 No Content status to indicate successful operation
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                //  if the playlist or song is not found
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error status for other exceptions
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
