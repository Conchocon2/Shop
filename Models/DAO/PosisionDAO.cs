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
        ShopDemoEntities db = null;
        public PosisionDAO()
        {
            db = new ShopDemoEntities();
        }
        public List<UserRight> ListPosision()
        {
            return db.UserRights.ToList();
        }
    }
}
