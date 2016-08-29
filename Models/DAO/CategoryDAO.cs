using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategoryDAO
    {
        ShopDbContext db = null;
        public CategoryDAO()
        {
            db = new ShopDbContext();
        }
        public List<Category> ListLoaiSP()
        {
            return db.Categories.ToList();
        }
    }
}
