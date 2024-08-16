using Moq;
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
            var service = new PlaylistService(mockRepo.Object);

            // Act
            await service.AddSongToPlaylist(1, 1);

            // Assert
            mockRepo.Verify(repo => repo.Add(It.IsAny<PlaylistSongs>()), Times.Once);
        }
    }
}