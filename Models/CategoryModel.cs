using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ParentCategory { get; set; }
        public string NumberOfProducts { get; set; }
        public int StockQuantity { get; set; }
        public string StockWorth { get; set; }
        public string ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsActive { get; set; }
    }
}
