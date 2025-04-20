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
    public class LibraryMasterRepository :ILibraryMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;

        public LibraryMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        

        public DataTable GetAllBooksList()
        {
            string Sqlquery = "exec Sp_LibraryGetDataList ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(Sqlquery, "LibrarytMaster.GetAllData");

            return dataTable;
        }

        public List<LibraryMasterDataModel> GetBookIDWise(int LibraryID)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string Sqlquery = "exec Sp_LibraryGetDataList @LibraryID =" + LibraryID;

            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(Sqlquery, "LibrarytMaster.GetAllData");

            if (dataTable == null && dataTable.Rows.Count == 0)
            {
                return new List<LibraryMasterDataModel>();
            }
            List<LibraryMasterDataModel> dataModels = CommonHelper.ConvertDataTable<List<LibraryMasterDataModel>>(dataTable);
            return dataModels;
        }

        public bool SaveData(LibraryMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            string SqlQuery = "exec USP_InsertLibraryMaster ";

            SqlQuery = SqlQuery + "@LibraryID ='" + request.LibraryID + "',";
            SqlQuery = SqlQuery + "@BookName ='" + request.BookName + "',";
            SqlQuery = SqlQuery + "@BookNumber ='" + request.BookNumber + "',";
            SqlQuery = SqlQuery + "@TypeOfBook ='" + request.TypeOfBook + "',";
            SqlQuery = SqlQuery + "@TotalBooks ='" + request.TotalBooks + "',";
            SqlQuery = SqlQuery + "@ActiveStatus ='" + request.ActiveStatus + "',";
            SqlQuery = SqlQuery + "@IPAddress ='" + request.IPAddress + "'";

            int rows = _commonHelper.NonQuerry(SqlQuery, "SaveData.LibraryData");
            if(rows>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteData(int LibraryID)
        {
            try
            {
                string sqlQuery = "UPDATE M_LibraryMaster SET ActiveStatus=0, DeleteStatus=1 WHERE LibraryID=" + LibraryID;
                int rows = _commonHelper.NonQuerry(sqlQuery, "LibraryMaster.Delete");
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
