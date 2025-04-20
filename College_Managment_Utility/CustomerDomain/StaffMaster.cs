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
    public class StaffMaster : UtilityBase, IStaffMaster
    {
        public StaffMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        

        public DataTable GetAllStaffList()
        {
            return UnitOfWork.StaffMasterRepository.GetAllStaffList();
        }

        public List<StaffMasterDataModel> GetStaffIDWise(int StaffID)
        {
            return UnitOfWork.StaffMasterRepository.GetStaffIDWise(StaffID);
        }

        public bool SaveData(StaffMasterDataModel request)
        {
            return UnitOfWork.StaffMasterRepository.SaveData(request);
        }
        public bool DeleteData(int StaffID)
        {
            return UnitOfWork.StaffMasterRepository.DeleteData(StaffID);
        }
    }
}
