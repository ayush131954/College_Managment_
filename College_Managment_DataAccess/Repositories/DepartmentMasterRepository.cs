using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using College_Management_DataAccess.Common;
using College_Managment_DataAccess.Interface;
using College_Managment_Model;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace College_Managment_DataAccess.Repositories
{
    public class DepartmentMasterRepository : IDepartmentMasterRepository
    {
        private readonly CommonDataAccessHelper _commonHelper;

        public DepartmentMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public DataTable GetAllDepartmentMasterList()
        {
            string SqlQuery = "exec Sp_DepartmentGetDataList";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "HODMaster.GetAllData");


            return dataTable;
        }

        public List<DepartmentMasterDataModel> GetDepartmentIDWise(int DepartmentID)
        {
            string SqlQuery = "exec Sp_DepartmentGetDataList @DepartmentID='" + DepartmentID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DepartmentMaster.GetDepartmentIDWise");


            //DataTable dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DepartmentMaster.GetAllDepartmentList");

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return new List<DepartmentMasterDataModel>();
            }
            List<DepartmentMasterDataModel> dataModels = CommonHelper.ConvertDataTable<List<DepartmentMasterDataModel>>(dataTable);
           
                 return dataModels;
        }
        
        public bool SaveData(DepartmentMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = " USP_InsertDepartmentMaster ";

            SqlQuery += " @DepartmentID ='" + request.DepartmentID + "',";
            SqlQuery += " @DepartmentName ='" + request.DepartmentName + "',";
            //SqlQuery += " @UserID='" + request.UserID + "',";
            SqlQuery += " @ActiveStatus ='" + request.ActiveStatus + "'";
            int Rows = _commonHelper.NonQuerry(SqlQuery, "DepartmentMaster.SaveData");
            if (Rows < 0)
                return true;
            else
                return false;
        }
        

        public bool DeleteData(int DepartmentID)
        {
            try
            {
                string sqlQuery = "UPDATE M_DepartmentMaster SET ActiveStatus=0, DeleteStatus=1 WHERE DepartmentID=" + DepartmentID;
                int rows = _commonHelper.NonQuerry(sqlQuery, "DepartmentMaster.Delete");
                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool IfExists(int DepartmentID, string DepartmentName)
        {
            try
            {
                string sqlQuery = "exec USP_IfExistDepartmentMaster @DepartmentID=" + DepartmentID +
                                  ", @DepartmentName='" + DepartmentName + "'";
                DataTable dataTable = _commonHelper.Fill_DataTable(sqlQuery, "DepartmentMaster.IfExists");
                return dataTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        
    }
}
