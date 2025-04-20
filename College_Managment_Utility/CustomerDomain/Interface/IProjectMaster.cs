using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_Utility.CustomerDomain.Interface
{
    public interface IProjectMaster
    {
        DataTable GetAllProjectData();

        List<ProjectMasterDataModel> GetProjectIDWise(int ProjectID);

        bool SaveData(ProjectMasterDataModel request);

        bool DeleteData(int ProjectID);
    }
}
