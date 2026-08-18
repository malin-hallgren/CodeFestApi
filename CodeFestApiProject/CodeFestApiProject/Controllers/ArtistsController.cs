using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeFestApiProject.Models;
using System.Net;

namespace CodeFestApiProject.Controllers
{
    internal class MockData
    {
        public static List<Artist> _artists { get; } = new List<Artist>
        {
            new Artist("the beatles"),
            new Artist("queen"),
            new Artist("led zeppelin"),
            new Artist("pink floyd"),
            new Artist("the rolling stones")
        };

        public static List<Stage> _stages { get; } = new List<Stage>
        {
            new Stage("main stage", 100),
            new Stage("second stage", 1200),
            new Stage("acoustic stage", 1),
            new Stage("electronic stage", 19992),
            new Stage("indie stage", 202)
        };
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetAll()
        {
            await Task.Delay(1000); // Simulate a delay for demonstration purposes
            return Ok(MockData._artists);
        }

        [HttpGet]
        [Route("name/{name}")]
        public async Task<ActionResult<Artist>> GetByName([FromRoute] string name)
        {
            name = name.ToLower();
            await Task.Delay(1000); // Simulate a delay for demonstration purposes
            var artist = MockData._artists.FirstOrDefault(a => a.Name == name);

            if (artist != null)
            {
                return Ok(artist);

            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("name/query")]
        public async Task<ActionResult<Artist>> GetByNameQ([FromQuery] string name)
        {
            name = name.ToLower();
            await Task.Delay(1000); // Simulate a delay for demonstration purposes
            var artist = MockData._artists.FirstOrDefault(a => a.Name == name);

            if (artist != null)
            {
                return Ok(artist);

            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name)
        {
            if (!MockData._artists.Exists(a => a.Name == name) )
            {
                Artist newArtist = new Artist(name.ToLower());
                MockData._artists.Add(newArtist);
                return Created();
            }

            return Conflict();
        }

        [HttpPatch]
        public async Task<ActionResult<Artist>> PatchTahtShit(string name, string newName)
        {
            name = name.ToLower();
            await Task.Delay(1000); // Simulate a delay for demonstration purposes
            var artist = MockData._artists.FirstOrDefault(a => a.Name == name);

            if (artist == null)
            {
                return NotFound();
            }

            artist.Name = newName;
            return Ok(artist);
        }

        [HttpDelete]
        public async Task<IActionResult> FuckThatShit(string name)
        {
            name = name.ToLower();
            await Task.Delay(1000); // Simulate a delay for demonstration purposes
            var artist = MockData._artists.FirstOrDefault(a => a.Name == name);

            if (artist == null)
            {
                return NotFound();
            }

            MockData._artists.Remove(artist);
            return Ok();
        }

    }
}
