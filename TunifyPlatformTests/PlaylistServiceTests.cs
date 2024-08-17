using Moq;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;
using TunifyPlatform.Repositories.Services;

namespace TunifyPlatformTests
{
    public class PlaylistServiceTests
    {
        [Fact]
        public async Task AddSongToPlaylist_ShouldAddCorrectly()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<PlaylistSongs>>();
            var mockContext = new Mock<TunifyDbContext>();  // Assuming PlaylistService requires the context
            var mockPlaylist = new Mock<IRepository<Playlist>>();
            var mockSong = new Mock<IRepository<Song>>();

            // Instantiate PlaylistService with the required dependencies
            var service = new PlaylistService(mockPlaylist.Object, mockSong.Object, mockRepo.Object, mockContext.Object);

            // Act
            await service.AddSongToPlaylist(1, 1);

            // Assert
            mockRepo.Verify(repo => repo.Add(It.IsAny<PlaylistSongs>()), Times.Once);

        }
    }
}