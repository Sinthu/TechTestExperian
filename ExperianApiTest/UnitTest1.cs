using System;
using Xunit;
using ExperianApi.Controllers;
using ExperianApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExperianApiTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestGetUserAlbumPhotosNotNull()
        {
            var user = new User()
            {
                UserId = 1,
                AlbumId = 1,
                PhotoId = 1,
                AlbumTitle = null,
                PhotoTitle = null,
                PhotoUrl = null,
                PhotoThumbnailUrl = null
            };
            var UserPhotosController = new UserPhotosController();

            //Act
            var actionResult = await UserPhotosController.GetUserAlbumPhotos(user.UserId);

            //Assert
            Assert.NotNull(actionResult);  
        }

        [Fact]
        public async Task TestUserIdFive()
        {
            var user = new User()
            {
                UserId = 5
            };

            var expectedCode = 200;
            var UserPhotosController = new UserPhotosController();         
            var result = await UserPhotosController.GetUserAlbumPhotos(user.UserId);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(expectedCode, okResult.StatusCode);
        }

        [Fact]
        public async Task TestUserIdZero()
        {
            var user = new User()
            {
                UserId = 0
            };

            var expectedCode = 404;
            var UserPhotosController = new UserPhotosController();
            var result = await UserPhotosController.GetUserAlbumPhotos(user.UserId);
            var notFoundResult = result as ObjectResult;

            Assert.Equal(expectedCode, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task TestUserIdMinusOne()
        {
            var user = new User()
            {
                UserId = -1
            };

            var expectedCode = 404;
            var UserPhotosController = new UserPhotosController();
            var result = await UserPhotosController.GetUserAlbumPhotos(user.UserId);
            var notFoundResult = result as ObjectResult;

            Assert.Equal(expectedCode, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task TestUserIdTwenty()
        {
            var user = new User()
            {
                UserId = 20
            };

            var expectedCode = 404;
            var UserPhotosController = new UserPhotosController();
            var result = await UserPhotosController.GetUserAlbumPhotos(user.UserId);
            var notFoundResult = result as ObjectResult;

            Assert.Equal(expectedCode, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task TestUserIdEight()
        {
            var user = new User()
            {
                UserId = 8
            };

            var expectedCode = 200;
            var UserPhotosController = new UserPhotosController();
            var result = await UserPhotosController.GetUserAlbumPhotos(user.UserId);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(expectedCode, okResult.StatusCode);
        }
    }
}
