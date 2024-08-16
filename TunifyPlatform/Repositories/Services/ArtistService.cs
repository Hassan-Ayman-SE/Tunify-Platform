using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Song> _songRepository;

        public ArtistService(IRepository<Song> songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task AddSongToArtist(int artistId, int songId)
        {
            var song = await _songRepository.GetById(songId);
            if (song != null && song.ArtistId != artistId)
            {
                song.ArtistId = artistId;
                await _songRepository.Update(song);
            }
        }
    }
}
