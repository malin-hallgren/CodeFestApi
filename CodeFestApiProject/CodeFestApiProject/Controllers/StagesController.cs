using CodeFestApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CodeFestApiProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stage>>> GetAll()
        {
            return Ok(MockData._stages);
        }

        [HttpGet]
        [Route("name/{name}")]
        public async Task<ActionResult<Stage>> GetByName([FromRoute] string name)
        {
            name = name.ToLower();
            await Task.Delay(1000);
            var stage = MockData._stages.FirstOrDefault(s => s.Name == name);
            if (stage != null)
            {
                return Ok(stage);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Stage>> UpdateStageName(string stageName, string newName)
        {
            newName = newName.ToLower();
            await Task.Delay(1000); // Simulate a delay for demonstration purposes
            var stage = MockData._stages.FirstOrDefault(a => a.Name == stageName);

            if (stage is null)
            {
                return NotFound();
            }

            stage.Name = newName;
            return Ok(stage);
        }
    }
}
