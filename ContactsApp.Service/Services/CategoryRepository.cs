using ContactsApp.Core.Models;
using ContactsApp.Repo.Data;
using ContactsApp.Repo.GenericRepository.Service;
using ContactsApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Service.Services
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        }
        public async Task<IEnumerable<Category>> GetAllCategories(bool trackChanges)
        {
            return await FindAllAsync(trackChanges).Result.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Category> GetCategory(int categoryId, bool trackChanges)
        {
            return await FindByConditionAsync(c => c.Id.Equals(categoryId), trackChanges).Result.SingleOrDefaultAsync();
        }
    }
}