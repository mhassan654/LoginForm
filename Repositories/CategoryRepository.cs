using LoginForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Repositories
{
    public class CategoryRepository : RepositoryBase, ICategory
    {
        public void Add(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public CategoryModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
