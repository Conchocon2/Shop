using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Areas.Admin.Models
{
    public class LoginModels
    {
        [Required(ErrorMessage = "Moi nhap User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Moi nhap Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}