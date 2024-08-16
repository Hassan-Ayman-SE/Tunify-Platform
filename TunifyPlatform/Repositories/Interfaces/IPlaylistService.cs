namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IPlaylistService
    {
        Task AddSongToPlaylist(int playlistId, int songId);
    }
}
