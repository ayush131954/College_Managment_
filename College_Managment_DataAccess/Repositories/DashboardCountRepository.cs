using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Management_DataAccess.Common;
using College_Managment_DataAccess.Interface;
using College_Managment_Model;

namespace College_Managment_DataAccess.Repositories
{
    public class DashboardCountRepository:IDashboardCountRepository
    {
        private CommonDataAccessHelper _commonHelper;

        public DashboardCountRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public List<DashboardData> GetDashboardsCount()
        {
            //string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec GetDashboardCounts ";
            DataSet dataSet = new DataSet();
            dataSet = _commonHelper.Fill_DataSet(SqlQuery, "Dashboard.GetAllDepartmentList");
            List<DashboardData> dataModels = new List<DashboardData>();
            DashboardData dataModel = new DashboardData();
            dataModel.data = dataSet;
            dataModels.Add(dataModel);
            return dataModels;
        }
    }
}
