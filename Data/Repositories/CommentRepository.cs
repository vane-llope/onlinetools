using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlinetools.DTOs;
using onlinetools.Interfaces.RepositoryInterFaces;
using onlinetools.Models;

namespace onlinetools.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public OnlineToolsDbContext _DbContext { get; }

        public CommentRepository(OnlineToolsDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<List<CommentSendDto>> GetAll(int subToolId)
        {
            var commentsWithUsers = await _DbContext.Comments
      .Where(c => c.SubToolId == subToolId)
      .OrderByDescending(c => c.CreatedDate)
      .Select(c => new CommentSendDto
      {
          Id = c.Id,
          Content = c.Content,
          SubToolId = c.SubToolId,
          UserId = c.UserId,
          CreatedDate = c.CreatedDate,
          UserName = c.User.Name,
          UserEmail = c.User.Email
      })
      .ToListAsync();

            return commentsWithUsers;
        }

        public async Task Add(Comment comment)
        {
            await _DbContext.AddAsync(comment);
            _DbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var CommentModel = FindComment(id);
             _DbContext.Comments.Remove(CommentModel);
            _DbContext.SaveChanges();
        }

        private Comment FindComment(int id)
        {
            var item = _DbContext.Comments.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }
    }
}
