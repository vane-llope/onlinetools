using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onlinetools.DTOs;
using onlinetools.Interfaces.RepositoryInterFaces;
using onlinetools.Models;

namespace onlinetools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : BaseController
    {
        private ICommentRepository _commentRepositiry { get; }
        public CommentsController(ICommentRepository commentRepositiry)
        {
            _commentRepositiry = commentRepositiry;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int id)
        {
            return CustomOk(await _commentRepositiry.GetAll(id));
        }


        [HttpPost("Add")]
        [Authorize]
        public async Task<IActionResult> Add(CommentDTO comment)
        {
           await _commentRepositiry.Add(new Comment
            {
                Content = comment.Content,
                UserId = comment.UserId,
                SubToolId = comment.SubToolId
            });
            return CustomOk();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentRepositiry.Delete(id);
            return CustomOk();
        }
    }
}
