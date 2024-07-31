using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using onlinetools.Controllers;
using onlinetools.Interfaces.RepositoryInterFaces;
using onlinetools.Models;
using static onlinetools.DTOs.ToolDTO;

namespace onlineTools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToolController : BaseController
    {
        private IToolRepository _toolRepositiry { get; }
        public ToolController(IToolRepository toolRepositiry)
        {
            _toolRepositiry = toolRepositiry;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var tools = _toolRepositiry.GetAll();
            return CustomOk(await tools);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return CustomOk(await _toolRepositiry.GetById(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ToolAddDTO tool)
        {
            await _toolRepositiry.Add(new Tool
            {
                Name = tool.Name
            });

            return CustomOk();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(ToolEditDTO tool)
        {
            await _toolRepositiry.Edit(new Tool
            {
                Id = tool.Id,
                Name = tool.Name
            });
            return CustomOk();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            _toolRepositiry.Delete(id);
            return CustomOk();
        }
    }
}
