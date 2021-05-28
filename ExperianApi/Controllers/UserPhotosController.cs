using ExperianApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExperianApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserPhotosController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAlbumPhotos(int id) 
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var albums = JsonConvert.DeserializeObject<List<Album>>(await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/albums"));
                    var photos = JsonConvert.DeserializeObject<List<Photo>>(await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/photos"));

                    var result = from p in photos
                                 join a in albums on p.AlbumId equals a.Id
                                 where a.UserId == id //Can assign a.UserId = 1 to read the albums and photos for userId = 1
                                 select new User { UserId = a.UserId, AlbumId = a.Id, PhotoId = p.Id, AlbumTitle = a.Title, PhotoTitle = p.Title, PhotoUrl = p.Url, PhotoThumbnailUrl = p.ThumbnailUrl };
                   
                    if(result == null || !result.Any())
                    {
                        return StatusCode(404, "Not found");
                    }
                    else
                    {
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex) { return StatusCode(404, "Not found"); }       
        }
    }
}