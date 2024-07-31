using Microsoft.EntityFrameworkCore;
using onlinetools.Interfaces.RepositoryInterFaces;
using onlinetools.Models;

namespace onlinetools.Data.Repositories
{
    public class ToolRepository : IToolRepository
    {
        public OnlineToolsDbContext _DbContext { get; }

        public ToolRepository(OnlineToolsDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public async Task<List<Tool>> GetAll()
        {
            return await _DbContext.Tools.OrderByDescending(x => x.CreatedDate).ToListAsync();
        }

        public async Task<Tool> GetById(int id)
        {
            return FindTool(id);
        }

        public async Task Add(Tool tool)
        {
            tool.CreatedDate = DateTime.Now;
            await _DbContext.Tools.AddAsync(tool);
            _DbContext.SaveChanges();
        }

        public async Task Edit(Tool tool)
        {
            var toolModel = FindTool(tool.Id);
            toolModel.Name = tool.Name;


            _DbContext.Tools.Update(toolModel);
            _DbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var ToolModel = FindTool(id);
            _DbContext.Tools.Remove(ToolModel);
            _DbContext.SaveChanges();
        }

        private Tool FindTool(int id)
        {
            var item = _DbContext.Tools.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }
    }
}
