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
    public class StaffMasterRepository : IStaffMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;

        public StaffMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }
        

        public DataTable GetAllStaffList()
        {
            string SqlQuery = "exec Sp_StaffGetDataList ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "CourseMaster.GetAllData");


            return dataTable;

        }

        public List<StaffMasterDataModel> GetStaffIDWise(int StaffID)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec Sp_StaffGetDataList @StaffID= '" + StaffID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "HODMaster.GetDataIDWise");

            if (dataTable == null && dataTable.Rows.Count == 0)
            {
                return new List<StaffMasterDataModel>();
            }
            List<StaffMasterDataModel> dataModels = CommonHelper.ConvertDataTable<List<StaffMasterDataModel>>(dataTable);
            return dataModels;
        }

        public bool SaveData(StaffMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_InsertStaffMaster ";

            SqlQuery = SqlQuery + "@StaffID='" + request.StaffID + "',";
            SqlQuery = SqlQuery + "@DepartmentID='" + request.DepartmentID + "',";
            SqlQuery = SqlQuery + "@FirstName='" + request.FirstName + "',";
            SqlQuery = SqlQuery + "@LastName='" + request.LastName + "',";
            SqlQuery = SqlQuery + "@MobileNumber='" + request.MobileNumber + "',";
            SqlQuery = SqlQuery + "@CurrentAddress='" + request.CurrentAddress + "',";
            SqlQuery = SqlQuery + "@PermentAddress='" + request.PermentAddress + "',";
            SqlQuery = SqlQuery + "@Gender='" + request.Gender + "',";
            SqlQuery = SqlQuery + "@Email='" + request.Email + "',";
            SqlQuery = SqlQuery + "@AcademicYear='" + request.AcademicYear + "',";
            SqlQuery = SqlQuery + "@ActiveStatus='" + request.ActiveStatus + "'";
            int row = _commonHelper.NonQuerry(SqlQuery, "StaffMaster.SaveData");
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(int StaffID)
        {
            try
            {
                string sqlQuery = "UPDATE M_StaffMaster SET ActiveStatus=0, DeleteStatus=1 WHERE StaffID=" + StaffID;
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
