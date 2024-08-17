using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IArtistService
    {
        Task AddSongToArtistAsync(int artistId, int songId);
        Task<IEnumerable<Song>> GetSongsByArtistAsync(int artistId);

    }
}
