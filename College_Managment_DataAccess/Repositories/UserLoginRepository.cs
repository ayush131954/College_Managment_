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
    public class UserLoginRepository: IUserLoginRepository
    {
        private CommonDataAccessHelper _commonHelper;

        public UserLoginRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        public DataTable GetUserLoginTable()
        {
            throw new NotImplementedException();
        }

        public List<UserLoginDataModel> Login(string username, string password)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec Sp_GetAllLoginData @UserName='" + username + "',@Password='" + password + "'";

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "UserLogin.GetDataIDWise");

            if (dataTable.DataSet == null && dataTable.Rows.Count == 0)
            {
                return new List<UserLoginDataModel>();
            }
            List<UserLoginDataModel> dataModels = CommonHelper.ConvertDataTable<List<UserLoginDataModel>>(dataTable);
            return dataModels;

        }

        public bool SaveData(UserLoginDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_InserUserLoginData ";

            SqlQuery = SqlQuery + "@LoginID='" + request.LoginID + "',";
            SqlQuery = SqlQuery + "@UserName='" + request.UserName + "',";
            SqlQuery = SqlQuery + "@Password='" + request.Password + "',";
            SqlQuery = SqlQuery + "@FirstName='" + request.FirstName + "',";
            SqlQuery = SqlQuery + "@LastName='" + request.LastName + "',";
            SqlQuery = SqlQuery + "@Email='" + request.Email + "',";
            SqlQuery = SqlQuery + "@ActiveStatus='" + request.ActiveStatus + "'";
            int row = _commonHelper.NonQuerry(SqlQuery, "UserLoginData.SaveData");
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
