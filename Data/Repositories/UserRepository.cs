using Microsoft.EntityFrameworkCore;
using onlinetools.Interfaces.RepositoryInterFaces;
using onlinetools.Models;

namespace onlinetools.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public OnlineToolsDbContext _DbContext { get; }

        public UserRepository(OnlineToolsDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<User> GetById(int id)
        {
            return FindUserById(id);
        }


        public async Task<User> FindUserByIEmail(string email)
        {
            var item = _DbContext.Users.FirstOrDefault(x => x.Email == email);
            if (item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }

        public async Task<List<User>> GetAll()
        {
            return await _DbContext.Users.OrderByDescending(x => x.RegisterDate).ToListAsync();
        }

        public async Task Add(User user)
        {
            user.RegisterDate = DateTime.Now;
            await _DbContext.Users.AddAsync(user);
            _DbContext.SaveChanges();
        }

        public async Task Edit(User user)
        {
            var userModel = FindUserById(user.Id);
            userModel.Name = user.Name;
            userModel.Email = user.Email;
            userModel.RegisterDate = DateTime.Now;
            userModel.IsAdmin = user.IsAdmin;
            if (user.PasswordHash != null && user.PasswordHash.Length > 0)
            {
                 userModel.PasswordHash = user.PasswordHash;
                 userModel.PasswordSalt = user.PasswordSalt;
            }
            

            _DbContext.Users.Attach(userModel);
            _DbContext.SaveChanges();

        }

        public async Task Delete(int id)
        {
            var userModel = FindUserById(id);
            _DbContext.Users.Remove(userModel);
            _DbContext.SaveChanges();
        }


        private User FindUserById(int id)
        {
            var item = _DbContext.Users.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }


    }
}
