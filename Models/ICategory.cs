using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Models
{
    public interface ICategory
    {
        void Add(CategoryModel categoryModel);
        void Edit(CategoryModel categoryModel);
        void Remove(int id);
        CategoryModel GetById(int id);
        IEnumerable<CategoryModel> GetByAll();
    }
}
