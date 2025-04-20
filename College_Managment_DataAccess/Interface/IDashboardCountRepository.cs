using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface IDashboardCountRepository
    {

        List<DashboardData> GetDashboardsCount();
    }
}
