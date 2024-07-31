using Microsoft.EntityFrameworkCore;
using onlinetools.Interfaces.RepositoryInterfaces;
using onlinetools.Models;

namespace onlinetools.Data.Repositories
{
    public class SubToolRepository : ISubToolsRepository
    {
        public OnlineToolsDbContext _DbContext { get; }

        public SubToolRepository(OnlineToolsDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        
        public async Task<List<SubTool>> GetAll(int toolId)
        {
            var filteredSubTools = await _DbContext.SubTools.Where(x => x.ToolId == toolId) 
                 .OrderByDescending(x => x.CreatedDate).ToListAsync();

            return filteredSubTools;
        }

        public async Task Add(SubTool subTool)
        {
            subTool.CreatedDate = DateTime.Now;
            await _DbContext.SubTools.AddAsync(subTool);
            _DbContext.SaveChanges();
        }

        public async Task Edit(SubTool subTool)
        {
            var SubToolModel = FindSubTool(subTool.Id);
            SubToolModel.Tags = subTool.Tags;
            SubToolModel.Name = subTool.Name;
            SubToolModel.ToolId = subTool.ToolId;
            SubToolModel.RouteName = subTool.RouteName;



            _DbContext.SubTools.Update(SubToolModel);
            _DbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var ToolModel = FindSubTool(id);
            _DbContext.SubTools.Remove(ToolModel);
            _DbContext.SaveChanges();
        }

        public async Task<SubTool> GetById(int id)
        {
            return FindSubTool(id);
        }

        private SubTool FindSubTool(int id)
        {
            var item = _DbContext.SubTools.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }

      
    }
}
