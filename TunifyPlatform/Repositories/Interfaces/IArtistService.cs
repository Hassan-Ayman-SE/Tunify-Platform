namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IArtistService
    {
        Task AddSongToArtist(int artistId, int songId);
    }
}
