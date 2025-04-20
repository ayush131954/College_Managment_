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
    public class StudentFeesMasterRepository:IStudentFeesMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;

        public StudentFeesMasterRepository (CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        

        public DataTable GetAllStudentFees()
        {
            string SqlQuery = "exec Sp_StudentFeeGetDataList ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "GetAllStudentFess");
            return dataTable;
        }

        public List<StudentFeesMasterDataModel> GetStudentFeesIDWise(int FeesID)
        {
            string SqlQuery = "exec Sp_StudentFeeGetDataList @FeesID='" + FeesID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "FeesMaster.GetDepartmentIDWise");


            //DataTable dataTable = _commonHelper.Fill_DataTable(SqlQuery, "DepartmentMaster.GetAllDepartmentList");

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return new List<StudentFeesMasterDataModel>();
            }
            List<StudentFeesMasterDataModel> dataModels = CommonHelper.ConvertDataTable<List<StudentFeesMasterDataModel>>(dataTable);

            return dataModels;
        }

        public bool SaveData(StudentFeesMasterDataModel request)
        {
            
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_InsertStudentFeeMaster ";

            SqlQuery = SqlQuery + "@FeesID='" + request.FeesID + "',";
            SqlQuery = SqlQuery + "@DepartmentID='" + request.DepartmentID + "',";
            SqlQuery = SqlQuery + "@StudentID='" + request.StudentID + "',";
            SqlQuery = SqlQuery + "@PaymentID='" + request.PaymentID + "',";
            SqlQuery = SqlQuery + "@FeeAmount='" + request.FeeAmount + "',";
            SqlQuery = SqlQuery + "@PaidAmount='" + request.PaidAmount + "',";
            SqlQuery = SqlQuery + "@DateOfPayment='" + request.DateOfPayment + "',";
            SqlQuery = SqlQuery + "@ActiveStatus='" + request.ActiveStatus + "'";
            int row = _commonHelper.NonQuerry(SqlQuery, "StudentFees.SaveData");
            if(row>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteData(int FeesID)
        {
            try
            {
                string sqlQuery = "UPDATE M_StudentFessMaster SET ActiveStatus=0, DeleteStatus=1 WHERE FeesID=" + FeesID;
                int rows = _commonHelper.NonQuerry(sqlQuery, "StudentFessMaster.Delete");
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
