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
    public class StudentMasterRepositiory:IStudentMasterRepositiory
    {
        private readonly CommonDataAccessHelper _commonHelper;

        public StudentMasterRepositiory(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public DataTable GetAllStudentList()
        {
            string SqlQuery = "exec Sp_StudentGetDataList ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StudentMaster.GetAllStudentData");

            return dataTable;
        }

        public List<StudentMasterDataModel> GetStudentIDWise(int StudentID)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec Sp_StudentGetDataList @StudentID= '" + StudentID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StudentMaster.GetDataIDWise");

            if (dataTable == null && dataTable.Rows.Count == 0)
            {
                return new List<StudentMasterDataModel>();
            }
            List<StudentMasterDataModel> dataModels = CommonHelper.ConvertDataTable<List<StudentMasterDataModel>>(dataTable);
            return dataModels;
        }

        

        public bool SaveData(StudentMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_InsertStudentMaster ";

            SqlQuery = SqlQuery + "@StudentID='" + request.StudentID + "',";
            SqlQuery = SqlQuery + "@DepartmentID='" + request.DepartmentID + "',";
            SqlQuery = SqlQuery + "@CourseID='" + request.CourseID + "',";
            SqlQuery = SqlQuery + "@SFirstName='" + request.SFirstName + "',";
            SqlQuery = SqlQuery + "@SMiddleName='" + request.SMiddleName + "',";
            SqlQuery = SqlQuery + "@SLastName='" + request.SLastName + "',";
            SqlQuery = SqlQuery + "@MobileNumber='" + request.MobileNumber + "',";
            SqlQuery = SqlQuery + "@CurrentAddress='" + request.CurrentAddress + "',";
            SqlQuery = SqlQuery + "@PermentAddress='" + request.PermentAddress + "',";
            SqlQuery = SqlQuery + "@Pincode='" + request.Pincode + "',";
            SqlQuery = SqlQuery + "@Gender='" + request.Gender + "',";
            SqlQuery = SqlQuery + "@City='" + request.City + "',";
            SqlQuery = SqlQuery + "@State='" + request.State + "',";
            SqlQuery = SqlQuery + "@Country='" + request.Country + "',";
            SqlQuery = SqlQuery + "@AcademicYear='" + request.AcademicYear + "',";
            SqlQuery = SqlQuery + "@ActiveStatus='" + request.ActiveStatus + "'";
            int row = _commonHelper.NonQuerry(SqlQuery, "StudentMaster.SaveData");
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(int StudentID)
        {
            try
            {
                string sqlQuery = "UPDATE M_StudentMaster SET ActiveStatus=0, DeleteStatus=1 WHERE StudentID=" + StudentID;
                int rows = _commonHelper.NonQuerry(sqlQuery, "StudentMaster.Delete");
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
