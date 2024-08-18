using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IPlaylistService
    {
        Task AddSongToPlaylist(int playlistId, int songId);

        Task<IEnumerable<Song>> GetSongsInPlaylistAsync(int playlistId);
    }
}
