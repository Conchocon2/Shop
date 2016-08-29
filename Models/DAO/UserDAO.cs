using Models.EF;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Models.DAO
{
    public class UserDAO
    {
        ShopDbContext db = null;
        public UserDAO()
        {
            db = new ShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User model)
        {
            try
            {
                var user = db.Users.Find(model.ID);
                user.Name = model.Name;
                user.Address = model.Address;
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.MaChucVu = model.MaChucVu;
                user.BirthDay = model.BirthDay;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var taikhoan = (from p in db.Users
                                where p.ID == id
                                select p).FirstOrDefault();
                var giaodich = (from a in db.Transactions
                                join b in db.Users
                                on a.UserID equals b.ID
                                where b.ID == id
                                select a).ToList();
                var hoadon = (from o in giaodich
                              join c in db.Orders
                              on o.ID equals c.Trans_ID
                              where c.Trans_ID == o.ID
                              select c).ToList();
                if (giaodich != null)
                {
                    if (hoadon != null)
                    {
                        for (int j = 1; j <= giaodich.Count; j++)
                        {
                            for (int i = 1; i <= hoadon.Count; j++)
                            {
                                db.Orders.Remove(hoadon[i]);
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in giaodich)
                        {
                            db.Transactions.Remove(item);
                        }
                    }
                }
                db.Users.Remove(taikhoan);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<User> ListAllPage(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.UserName.Contains(searchString));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }
        public User GetByString(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User GetByID(int id)
        {
            return db.Users.Find(id);
        }
        public bool Login(string userName, string password)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.Password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
