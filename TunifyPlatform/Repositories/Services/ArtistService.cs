using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Song> _songRepository;
        private readonly IRepository<Artist> _artistRepository;
        private readonly TunifyDbContext _context;

        public ArtistService(IRepository<Song> songRepository, IRepository<Artist> artistRepository, TunifyDbContext context)
        {

            _songRepository = songRepository;
            _artistRepository = artistRepository;
            _context = context;
        }

        public async Task AddSongToArtistAsync(int artistId, int songId)
        {
            var artist = await _artistRepository.GetById(artistId);
            if (artist == null)
            {
                throw new KeyNotFoundException("Artist not found.");
            }

            var song = await _songRepository.GetById(songId);
            if (song == null)
            {
                throw new KeyNotFoundException("Song not found.");
            }

            // Associate the song with the artist
            song.ArtistId = artistId;
            song.Artist = artist;

            // Update the song in the repository
            await _songRepository.Update(song);
            await _context.SaveChangesAsync();
        }

        // Retrieves all songs by a specific artist
        public async Task<IEnumerable<Song>> GetSongsByArtistAsync(int artistId)
        {

            // Use the context to query songs with related entities
            //return await _context.Songs
            //    .Where(song => song.ArtistId == artistId)
            //    .Include(song => song.Artist)        // Include the Artist entity
            //    .Include(song => song.Album)         // Include the Album entity
            //    .Include(song => song.PlaylistSongs) // Include the PlaylistSongs relationship
            //    .ToListAsync();

            // Query the database to get an artist by their ID and include their related songs in the result.
            // This uses Entity Framework Core's Include method to eagerly load the related 'Songs' entities.
            var artist = await _context.Artists
                .Include(a => a.Songs)
                .FirstOrDefaultAsync(a => a.Id == artistId);

            if (artist == null)
            {
                throw new Exception("Artist not found");
            }

            return artist.Songs;

        }

    }
}
