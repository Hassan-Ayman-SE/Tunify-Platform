using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IRepository<PlaylistSongs> _playlistSongsRepository;
        private readonly IRepository<Playlist> _playlistRepository;
        private readonly IRepository<Song> _songRepository;
        private readonly TunifyDbContext _context;

        public PlaylistService(IRepository<Playlist> playlistRepository, IRepository<Song> songRepository, IRepository<PlaylistSongs> playlistSongsRepository, TunifyDbContext context)
        {
            _playlistRepository = playlistRepository;
            _songRepository = songRepository;
            _playlistSongsRepository = playlistSongsRepository;
            _context = context;
        }

        public async Task AddSongToPlaylist(int playlistId, int songId)
        {

            var playlist = await _playlistRepository.GetById(playlistId);
            if (playlist == null)
            {
                throw new KeyNotFoundException("Playlist not found.");
            }

            var song = await _songRepository.GetById(songId);
            if (song == null)
            {
                throw new KeyNotFoundException("Song not found.");
            }

            var playlistSong = new PlaylistSongs
            {
                PlaylistId = playlistId,
                SongId = songId
            };

            await _playlistSongsRepository.Add(playlistSong);
            await _context.SaveChangesAsync();
        }

        // Retrieves all songs by a specific artist
        public async Task<IEnumerable<Song>> GetSongsInPlaylistAsync(int playlistId)
        {

            var playlist = await _context.Playlists
                .Include(x => x.PlaylistSongs)
                .ThenInclude(p => p.Song)
                .FirstOrDefaultAsync(p => p.Id == playlistId);
            if (playlist == null)
            {
                throw new Exception("Playlist not found");
            }

            return playlist.PlaylistSongs.Select(ps => ps.Song);

        }
    }
}
