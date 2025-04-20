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
    public class StudentLibraryRepository:IStudentLibraryRepository
    {
        CommonDataAccessHelper _commonHelper;

        public StudentLibraryRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

       
        public DataTable GetAllStudentLibrary()
        {
            string SqlQuery = "exec Sp_StudentBookissueGetData ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StudentMaster.GetAllStudentData");

            return dataTable;
        }

        public List<StudentLibraryDataModel> GetStudentLibraryIDWise(int StudLibraryID)
        {
            var IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec Sp_StudentBookissueGetData @StudLibraryID=" + StudLibraryID;

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "StudentLibrary.GetIDWise");

            if (dataTable == null && dataTable.Rows.Count == 0)
            {
                return new List<StudentLibraryDataModel>();
            }
            List<StudentLibraryDataModel> dataModels = CommonHelper.ConvertDataTable<List<StudentLibraryDataModel>>(dataTable);
            return dataModels;
        }

        public bool SaveData(StudentLibraryDataModel request)
        {
            var IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_InsertStudentLibraryMaster ";

            SqlQuery = SqlQuery + "@StudLibraryID='" + request.StudLibraryID + "',";
            SqlQuery = SqlQuery + "@LibraryID='" + request.LibraryID + "',";
            SqlQuery = SqlQuery + "@StudentName='" + request.StudentName + "',";
            SqlQuery = SqlQuery + "@PhoneNumber='" + request.PhoneNumber + "',";
            SqlQuery = SqlQuery + "@Semester='" + request.Semester + "',";
            SqlQuery = SqlQuery + "@EnrollmentNo='" + request.EnrollmentNo + "',";
            SqlQuery = SqlQuery + "@DepartmentName='" + request.DepartmentName + "',";
            SqlQuery = SqlQuery + "@Email='" + request.Email + "',";
            //SqlQuery = SqlQuery + "@BookName='" + request.BookName + "',";
            //SqlQuery = SqlQuery + "@BookNumber='" + request.BookNumber + "',";
            SqlQuery = SqlQuery + "@IssueDate='" + request.IssueDate + "',";
            SqlQuery = SqlQuery + "@ReturnDate='" + request.ReturnDate + "',";
            SqlQuery = SqlQuery + "@IssueTeacherName='" + request.IssueTeacherName + "',";
            SqlQuery = SqlQuery + "@ActiveStatus='" + request.ActiveStatus + "'";

            int row = _commonHelper.NonQuerry(SqlQuery, "SaveData.StudentLibraryData");
            if(row>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(int StudLibraryID)
        {
            try
            {
                string sqlQuery = "UPDATE M_StudentBookissue SET ActiveStatus=0, DeleteStatus=1 WHERE StudLibraryID=" + StudLibraryID;
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
