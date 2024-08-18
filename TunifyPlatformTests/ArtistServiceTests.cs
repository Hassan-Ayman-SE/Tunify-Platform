using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunifyPlatform.Data;
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

            var mockSongRepo = new Mock<IRepository<Song>>();
            var mockArtistRepo = new Mock<IRepository<Artist>>();
            var mockContext = new Mock<TunifyDbContext>();

            mockSongRepo.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(song);

            var service = new ArtistService(mockSongRepo.Object, mockArtistRepo.Object, mockContext.Object);

            // Act
            // await service.AddSongToArtist(2, 1);

            // Assert
            Assert.Equal(2, song.ArtistId);
            mockSongRepo.Verify(repo => repo.Update(song), Times.Once);
        }
    }
}

