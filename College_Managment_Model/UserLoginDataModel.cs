﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class UserLoginDataModel
    {
        public int LoginID { get; set; }


        public string UserName { get; set; }


        public string Password { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }
        public int  ActiveStatus { get; set; }


        
    }
}
