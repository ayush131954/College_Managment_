using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface IHODMasterRepository
    {
        DataTable GetAllHODMasterList();

        List<HODMasterDataModel> GetHODIDWise(int HODID);

        bool SaveData(HODMasterDataModel request);

        bool DeleteData(int HODID);
    }
}
