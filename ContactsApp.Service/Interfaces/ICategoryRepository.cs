using ContactsApp.Core.Models;

namespace ContactsApp.Service.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories(bool trackChanges);
        Task<Category> GetCategory(int categoryId, bool trackChanges);
    }
}
