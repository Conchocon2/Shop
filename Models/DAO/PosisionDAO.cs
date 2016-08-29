using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class PosisionDAO
    {
        ShopDbContext db = null;
        public PosisionDAO()
        {
            db = new ShopDbContext();
        }
        public List<ChucVu> ListPosision()
        {
            return db.ChucVus.ToList();
        }
    }
}
