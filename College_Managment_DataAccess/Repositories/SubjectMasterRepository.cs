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
    public class SubjectMasterRepository : ISubjectMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;

        public SubjectMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }


        public DataTable GetAllSubjectList()
        {
            string Sqlquery = "exec Sp_SubjectGetDataList ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(Sqlquery, "SubjectMaster.GetAllData");

            return dataTable;
        }

        public List<SubjectMasterDataModel> GetSubjectIDWise(int SubjectID)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec Sp_SubjectGetDataList @SubjectID= '" + SubjectID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "SubjectMaster.GetDataIDWise");

            if (dataTable == null && dataTable.Rows.Count == 0)
            {
                return new List<SubjectMasterDataModel>();
            }
            List<SubjectMasterDataModel> dataModels = CommonHelper.ConvertDataTable<List<SubjectMasterDataModel>>(dataTable);
            return dataModels;
        }


        public bool SaveData(SubjectMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_InsertSubjectMaster ";

            SqlQuery = SqlQuery + "@SubjectID='" + request.SubjectID + "',";
            SqlQuery = SqlQuery + "@DepartmentID='" + request.DepartmentID + "',";
            SqlQuery = SqlQuery + "@CourseID='" + request.CourseID + "',";
            SqlQuery = SqlQuery + "@SubjectName='" + request.SubjectName + "',";
            SqlQuery = SqlQuery + "@ActiveStatus='" + request.ActiveStatus + "'";
            int row = _commonHelper.NonQuerry(SqlQuery, "SubjectMaster.SaveData");
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(int SubjectID)
        {
            try
            {
                string sqlQuery = "UPDATE M_SubjectMaster SET ActiveStatus=0, DeleteStatus=1 WHERE SubjectID=" + SubjectID;
                int rows = _commonHelper.NonQuerry(sqlQuery, "SubjectMaster.Delete");
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
