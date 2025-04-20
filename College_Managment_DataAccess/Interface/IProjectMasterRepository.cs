using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface IProjectMasterRepository
    {
        DataTable GetAllProjectData();

        List<ProjectMasterDataModel> GetProjectIDWise(int ProjectID);

        bool SaveData(ProjectMasterDataModel request);

        bool DeleteData(int ProjectID);
    }
}
