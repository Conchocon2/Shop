using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDAO
    {
        ShopDemoEntities db = null;
        public ProductDAO()
        {
            db = new ShopDemoEntities();
        }
        public long Insert(Product model)
        {
            db.Products.Add(model);
            db.SaveChanges();
            return model.ID;
        }
        public Product GetByID(int id)
        {
            return db.Products.Find(id);
        } 
        public IEnumerable<Product> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.CPU.Contains(searchString));
            }
            return model.OrderBy(x => x.CPU).ToPagedList(page, pageSize);
        }
        public bool Delete(int id)
        {
            try
            {
                var sp = db.Products.Find(id);
                var donhang = (from a in db.Products
                               join b in db.Orders
                               on a.ID equals b.ID
                               where a.ID == id
                               select b).ToList();
                if (donhang.Count != 0)
                {
                    foreach (var item in donhang)
                    {
                        db.Orders.Remove(item);
                    }
                }
                else
                {
                    db.Products.Remove(sp);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update(Product model)
        {
            try
            {
                var product = db.Products.Find(model.ID);
                product.CPU = model.CPU;
                product.Price = model.Price;
                product.StorageAmount = model.StorageAmount;
                product.Pin = model.Pin;
                product.ImageID = model.ImageID;
                product.CateID = model.CateID;
                product.Color = model.Color;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
