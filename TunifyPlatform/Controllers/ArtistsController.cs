﻿using System;
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
    public class ArtistsController : ControllerBase
    {
        private readonly IRepository<Artist> _artistRepository;
        private readonly IArtistService _artistService;

        public ArtistsController(IRepository<Artist> artistRepository, IArtistService artistService)
        {
            _artistRepository = artistRepository;
            _artistService = artistService;
        }
        [Route("/GetAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return Ok(await _artistRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _artistRepository.GetById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            await _artistRepository.Add(artist);
            return CreatedAtAction(nameof(GetArtist), new { id = artist.Id }, artist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }
            await _artistRepository.Update(artist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _artistRepository.GetById(id);
            if (artist == null)
            {
                return NotFound();
            }
            await _artistRepository.Delete(id);
            return NoContent();
        }

        //Lab 13 New Routes

        // POST: api/Artists/{artistId}/Songs/{songId}
        [HttpPost("{artistId}/Songs/{songId}")]
        public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
        {
            try
            {
                await _artistService.AddSongToArtistAsync(artistId, songId);
                return Ok(new { Message = "Song added to artist successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Artists/{artistId}/Songs
        //[Route("{artistId}/Songs")]
        [HttpGet("{artistId}/Songs")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsByArtist(int artistId)
        {
            var songs = await _artistService.GetSongsByArtistAsync(artistId);
            if (songs == null || !songs.Any())
            {
                return NotFound("No songs found for this artist.");
            }

            return Ok(songs);
        }

    }
}
