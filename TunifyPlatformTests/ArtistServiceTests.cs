using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;
using TunifyPlatform.Repositories.Services;

namespace TunifyPlatformTests
{
    public class ArtistServiceTests
    {
        [Fact]
        public async Task AddSongToArtist_ShouldUpdateArtistIdCorrectly()
        {
            // Arrange
            var song = new Song { Id = 1, ArtistId = 1 };
            var mockRepo = new Mock<IRepository<Song>>();
            mockRepo.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(song);

            var service = new ArtistService(mockRepo.Object);

            // Act
            await service.AddSongToArtist(2, 1);

            // Assert
            Assert.Equal(2, song.ArtistId);
            mockRepo.Verify(repo => repo.Update(song), Times.Once);
        }
    }
}
