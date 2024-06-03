using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Models
{
    public class CategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string CretedAt { get; set; }
        public string IsActive { get; set; }
    }
}
