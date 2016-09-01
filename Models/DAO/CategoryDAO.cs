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
        ShopDemoEntities db = null;
        public CategoryDAO()
        {
            db = new ShopDemoEntities();
        }
        public List<Category> ListLoaiSP()
        {
            return db.Categories.ToList();
        }
    }
}
