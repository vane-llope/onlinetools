using Microsoft.Extensions.Hosting;
using onlinetools.DTOs;
using onlinetools.Models;

namespace onlinetools.Interfaces.RepositoryInterFaces
{
    public interface ICommentRepository
    {
        Task<List<CommentSendDto>> GetAll(int ToolId);
        Task Add(Comment comment);
        Task Delete(int id);
    }
}
