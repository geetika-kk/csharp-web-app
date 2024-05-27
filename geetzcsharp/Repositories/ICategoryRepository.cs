using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using geetzcsharp.Models;
namespace geetzcsharp.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
