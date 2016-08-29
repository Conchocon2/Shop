using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ViewUser
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string TenChucVu { get; set; }
    }
}
