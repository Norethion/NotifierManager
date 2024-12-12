using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotifierManager.Core.Models;

namespace NotifierManager.Core.Interfaces
{
    public interface ICategoryService
    {
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
