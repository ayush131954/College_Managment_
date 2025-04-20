using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Management_DataAccess.Interface;

namespace College_Managment_Utility
{
    public class UtilityBase
    {
        protected IRepositories UnitOfWork;
        public UtilityBase(IRepositories unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
