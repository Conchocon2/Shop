﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Areas.Client.Models {
    public class LoginModel {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}