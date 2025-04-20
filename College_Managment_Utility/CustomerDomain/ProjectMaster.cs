using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Management_DataAccess.Interface;
using College_Managment_Model;
using College_Managment_Utility.CustomerDomain.Interface;

namespace College_Managment_Utility.CustomerDomain
{
    public class ProjectMaster : UtilityBase, IProjectMaster
    {
        public ProjectMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        

        public DataTable GetAllProjectData()
        {
            return UnitOfWork.ProjectMasterRepository.GetAllProjectData();
        }

        public List<ProjectMasterDataModel> GetProjectIDWise(int ProjectID)
        {
            return UnitOfWork.ProjectMasterRepository.GetProjectIDWise(ProjectID);
        }

        public bool SaveData(ProjectMasterDataModel request)
        {
            return UnitOfWork.ProjectMasterRepository.SaveData(request);
        }

        public bool DeleteData(int ProjectID)
        {
            return UnitOfWork.ProjectMasterRepository.DeleteData(ProjectID);
        }
    }
}
