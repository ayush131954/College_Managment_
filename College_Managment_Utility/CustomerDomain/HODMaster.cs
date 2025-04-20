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
    public class HODMaster :UtilityBase, IHODMaster
    {
        public HODMaster(IRepositories unitOfWork) : base(unitOfWork)
        {

        }

        public DataTable GetAllHODList()
        {
            return UnitOfWork.HODMasterRepository.GetAllHODMasterList();
        }

        public List<HODMasterDataModel> GetHODIDWise(int HODID)
        {
            return UnitOfWork.HODMasterRepository.GetHODIDWise(HODID);
        }

        public bool SaveData(HODMasterDataModel request)
        {
            return UnitOfWork.HODMasterRepository.SaveData(request);
        }

        public bool DeleteData(int HODID)
        {
            return UnitOfWork.HODMasterRepository.DeleteData(HODID);
        }

        
    }
}
