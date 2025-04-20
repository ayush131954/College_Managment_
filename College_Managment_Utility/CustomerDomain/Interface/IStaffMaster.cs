using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_Utility.CustomerDomain.Interface
{
    public interface IStaffMaster
    {
        DataTable GetAllStaffList ();

        List<StaffMasterDataModel> GetStaffIDWise(int StaffID);

        bool SaveData (StaffMasterDataModel request);

        bool DeleteData (int StaffID);
    }
}
