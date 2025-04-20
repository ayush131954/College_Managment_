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
    public class ProjectMasterRepository:IProjectMasterRepository
    {
        private CommonDataAccessHelper _commonHelper;
        public ProjectMasterRepository(CommonDataAccessHelper commonHelper)
        {
            _commonHelper = commonHelper;
        }

        

        public DataTable GetAllProjectData()
        {
            string SqlQuery = "exec Sp_ProjectGetDataList ";
            DataTable dataTable = new DataTable();
            dataTable = _commonHelper.Fill_DataTable(SqlQuery, "GetAll project list");

            return dataTable;

        }

        public List<ProjectMasterDataModel> GetProjectIDWise(int ProjectID)
        {
            string SqlQuery = "exec Sp_ProjectGetDataList @ProjectID=' "+ProjectID+"'";

            DataTable datatable = new DataTable();
            datatable = _commonHelper.Fill_DataTable(SqlQuery, "GetDataIdWise");

            if(datatable == null && datatable.Rows.Count==0)
            {
                return new  List<ProjectMasterDataModel>();
            }
            else
            {
                List<ProjectMasterDataModel> dataModels = CommonHelper.ConvertDataTable<List<ProjectMasterDataModel>>(datatable);
                return dataModels;
            }
        }

        public bool SaveData(ProjectMasterDataModel request)
        {
            string IPAddress = CommonHelper.GetVisitorIPAddress();
            String SqlQuery = "exec USP_InserProjectMaster ";

            SqlQuery = SqlQuery + "@ProjectID= '" + request.ProjectID + "',";
            SqlQuery = SqlQuery + "@DepartmentID= '" + request.DepartmentID + "',";
            SqlQuery = SqlQuery + "@StudentName= '" + request.StudentName + "',";
            SqlQuery = SqlQuery + "@ProjectName= '" + request.ProjectName + "',";
            SqlQuery = SqlQuery + "@ProjectSpecification= '" + request.ProjectSpecification + "',";
            SqlQuery = SqlQuery + "@Semester= '" + request.Semester + "',";
            SqlQuery = SqlQuery + "@ProjectType= '" + request.ProjectType + "',";
            SqlQuery = SqlQuery + "@ActiveStatus= '" + request.ActiveStatus + "'";

            int row = _commonHelper.NonQuerry(SqlQuery, "SaveProject Data");
            if(row>0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool DeleteData(int ProjectID)
        {
            try
            {
                string sqlQuery = "UPDATE M_projectMaster SET ActiveStatus=0, DeleteStatus=1 WHERE ProjectID=" + ProjectID;
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
