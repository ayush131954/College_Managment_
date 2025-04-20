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
    public class CommonMasterRepository:ICommonMasterRepository
    {
        private CommonDataAccessHelper _CommonHelper;

        public CommonMasterRepository(CommonDataAccessHelper CommonHelper)
        {
            _CommonHelper = CommonHelper;
        }

        

        public DataTable GetAllGenderList()
        {
            string SqlQuery = "exec USP_DDL_Gender ";
            DataTable dataTable = new DataTable();
            dataTable = _CommonHelper.Fill_DataTable(SqlQuery, "Gender.GetAllData");


            return dataTable;
        }

        public List<CommonMasterModel> GetGenderIDWise(int CommonID)
        {
            string SqlQuery = "exec USP_DDL_Gender @CourseID='" + CommonID + "'";

            DataTable dataTable = new DataTable();
            dataTable = _CommonHelper.Fill_DataTable(SqlQuery, "CourseMaster.GetDepartmentIDWise");

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return new List<CommonMasterModel>();
            }
            List<CommonMasterModel> dataModels = CommonHelper.ConvertDataTable<List<CommonMasterModel>>(dataTable);

            return dataModels;
        }



        public DataTable GetAllfyList()
        {
            string SqlQuery = "exec USP_DDL_Fy ";
            DataTable dataTable = new DataTable();
            dataTable = _CommonHelper.Fill_DataTable(SqlQuery, "AcademicYear.GetAllData");


            return dataTable;
        }

        public List<CommonMasterModel> GetfyIDWise(int CommonID)
        {
            throw new NotImplementedException();
        }

         
    }
}
