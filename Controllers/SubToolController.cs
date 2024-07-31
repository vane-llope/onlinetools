using Microsoft.AspNetCore.Mvc;
using onlinetools.Data.Repositories;
using onlinetools.DTOs;
using onlinetools.Interfaces.RepositoryInterfaces;
using onlinetools.Interfaces.RepositoryInterFaces;
using onlinetools.Models;

namespace onlinetools.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SubToolController : BaseController
    {
        private ISubToolsRepository _subToolsRepositiry { get; }
        public SubToolController(ISubToolsRepository SubToolRepositiry)
        {
            _subToolsRepositiry = SubToolRepositiry;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int toolId)
        {
            var subTools = _subToolsRepositiry.GetAll(toolId);
            return CustomOk(await subTools);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return CustomOk(await _subToolsRepositiry.GetById(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(SubToolAddDTO subTool)
        {
            await _subToolsRepositiry.Add(new SubTool
            {
                Name = subTool.Name,
                RouteName = subTool.RouteName,
                Tags = subTool.Tags,
                ToolId = subTool.ToolId
            });

            return CustomOk();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(SubToolEditDTO subTool)
        {
            await _subToolsRepositiry.Edit(new SubTool
            {
                Id = subTool.Id,
                Name = subTool.Name,
                RouteName = subTool.RouteName,
                Tags = subTool.Tags,
                ToolId = subTool.ToolId
            });
            return CustomOk();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            _subToolsRepositiry.Delete(id);
            return CustomOk();
        }

    }
}
