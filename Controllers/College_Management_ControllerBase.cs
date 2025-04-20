using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using College_Managment_Utility;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace College_Management_API.Controllers
{
    public class College_Management_ControllerBase : ControllerBase
    {
        protected IUtilityHelper UtilityHelper;
        private IConfiguration _configuration;
        public College_Management_ControllerBase(IConfiguration configuration)
        {
            _configuration = configuration;
            UtilityHelper = new UtilityHelper(configuration);
        }
    }
}
