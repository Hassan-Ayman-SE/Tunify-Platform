using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IRepository<PlaylistSongs> _playlistSongsRepository;

        public PlaylistService(IRepository<PlaylistSongs> playlistSongsRepository)
        {
            _playlistSongsRepository = playlistSongsRepository;
        }

        public async Task AddSongToPlaylist(int playlistId, int songId)
        {

            var playlistSong = new PlaylistSongs { PlaylistId = playlistId, SongId = songId };
            await _playlistSongsRepository.Add(playlistSong);
        }
    }
}
