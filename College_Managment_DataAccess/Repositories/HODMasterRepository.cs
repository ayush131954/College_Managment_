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
    public class HODMasterRepository : IHODMasterRepository
    {
        private readonly CommonDataAccessHelper _commonHelper;

        public HODMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        

        public DataTable GetAllHODMasterList()
        {
            //string SqlQuery = "exec Sp_HODGetDataList ";
            //DataTable dataTable = new DataTable();
            //dataTable = _commonHelper.Fill_DataTable(SqlQuery, "HODMaster.GetAllData");

            //List<DataTable> dataModels = new List<DataTable>();
            //DataTable dataModel = new DataTable();
            //dataModel.data = dataTable;
            //dataModels.Add(dataModel);
            //return dataModels;
            string SqlQuery = "exec Sp_HODGetDataList ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "HODMaster.GetAllData");


            return dataTable;
        }

        public List<HODMasterDataModel> GetHODIDWise(int HODID)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec Sp_HODGetDataList @HODID= '"+HODID+"'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "HODMaster.GetDataIDWise");

            if(dataTable == null && dataTable.Rows.Count==0)
            {
                return new List<HODMasterDataModel>();
            }
            List<HODMasterDataModel> dataModels = CommonHelper.ConvertDataTable<List<HODMasterDataModel>>(dataTable);
            return dataModels;
 
        }

        public bool SaveData(HODMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_InsertHODMaster ";

            SqlQuery = SqlQuery + "@HODID='" + request.HODID + "',";
            SqlQuery = SqlQuery + "@DepartmentID='" + request.DepartmentID + "',";
            SqlQuery = SqlQuery + "@CourseID='" + request.CourseID + "',";
            SqlQuery = SqlQuery + "@HODFirstName='" + request.HODFirstName + "',";
            SqlQuery = SqlQuery + "@HODLastName='" + request.HODLastName + "',";
            SqlQuery = SqlQuery + "@MobileNumber='" + request.MobileNumber + "',";
            SqlQuery = SqlQuery + "@CurrentAddress='" + request.CurrentAddress + "',";
            SqlQuery = SqlQuery + "@PermentAddress='" + request.PermentAddress + "',";
            SqlQuery = SqlQuery + "@Gender='" + request.Gender + "',";
            SqlQuery = SqlQuery + "@Email='" + request.Email + "',";
            SqlQuery = SqlQuery + "@AcademicYear='" + request.AcademicYear + "',";
            SqlQuery = SqlQuery + "@ActiveStatus='" + request.ActiveStatus + "'";
            int row = _commonHelper.NonQuerry(SqlQuery, "HODMaster.SaveData");
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteData(int HODID)
        {
            try
            {
                string sqlQuery = "UPDATE M_HODMaster SET ActiveStatus=0, DeleteStatus=1 WHERE HODID=" + HODID;
                int rows = _commonHelper.NonQuerry(sqlQuery, "CourseMaster.Delete");
                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
