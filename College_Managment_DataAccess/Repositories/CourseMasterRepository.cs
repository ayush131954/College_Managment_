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
    public class CourseMasterRepository : ICourseMasterRepository
    {
        private CommonDataAccessHelper _CommonHelper;

        public CourseMasterRepository (CommonDataAccessHelper CommonHelper)
        {
            _CommonHelper = CommonHelper;
        }

        public DataTable GetAllCourseList(int DepartmentID)
        {
            //string SqlQuery = "exec Sp_CourseGetDataList @DepartmentID='" + DepartmentID + "'";
            //DataTable dataTable = _CommonHelper.Fill_DataTable(SqlQuery, "Coursemaster.GetAllCourseList");
            //List<CourseMasterDataModel_list> dataModel = new List<CourseMasterDataModel_list>();

            string SqlQuery = "exec Sp_CourseGetDataList @DepartmentID='" + DepartmentID + "'";
            DataTable dataTable = new DataTable();
            dataTable = _CommonHelper.Fill_DataTable(SqlQuery, "CourseMaster.GetAllData");

           
            return dataTable;
        }

        public List<CourseMasterDataModel> GetCourseIDWise(int CourseID)
        {
            string SqlQuery = "exec Sp_CourseGetDataList @CourseID='" + CourseID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _CommonHelper.Fill_DataTable(SqlQuery, "CourseMaster.GetDepartmentIDWise");


            //DataTable dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DepartmentMaster.GetAllDepartmentList");

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return new List<CourseMasterDataModel>();
            }
            List<CourseMasterDataModel> dataModels = CommonHelper.ConvertDataTable<List<CourseMasterDataModel>>(dataTable);

            return dataModels;
        }

        public bool SaveData(CourseMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_InsertCourseMaster ";

            SqlQuery += "@DepartmentID='" + request.DepartmentID + "',";
            SqlQuery += "@CourseID='" + request.CourseID + "',";
            SqlQuery += "@CourseName='" + request.CourseName + "',";
            SqlQuery += "@ActiveStatus='" + request.ActiveStatus + "'";
            int Rows = _CommonHelper.NonQuerry(SqlQuery, "CourseMaster.SaveData");
            if (Rows > 0)
                return true;
            else
                return false;
        }

        public bool DeleteData(int CourseID)
        {
            try
            {
                string sqlQuery = "UPDATE M_CourseMaster SET ActiveStatus=0, DeleteStatus=1 WHERE CourseID=" + CourseID;
                int rows = _CommonHelper.NonQuerry(sqlQuery, "CourseMaster.Delete");
                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool IfExists(int CourseID, string CourseName)
        {
            throw new NotImplementedException();
        }
    }
}
