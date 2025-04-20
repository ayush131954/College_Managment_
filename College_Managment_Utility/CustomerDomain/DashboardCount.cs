using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Management_DataAccess.Interface;
using College_Managment_Model;
using College_Managment_Utility.CustomerDomain.Interface;

namespace College_Managment_Utility.CustomerDomain
{
    public class DashboardCount : UtilityBase, IDashboardCount
    {
        public DashboardCount(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public List<DashboardData> GetAllDashboardCount()
        {
            return UnitOfWork.DashboardCountRepository.GetDashboardsCount();
        }
    }
}
