using LoginForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public void Add(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }

        public List<CategoryModel> GetByAll()
        {
            // try
            // {
                DataContext.Categories.ToList();
            
                List<CategoryModel> categories = [];
                if (categories == null) throw new ArgumentNullException(nameof(categories));

                var list = categories.Select(category => category).ToList();
                Console.WriteLine(string.Join(", ", list)); 
                return list;
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.ToString());
            //     // throw;
            // }
            
          
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
