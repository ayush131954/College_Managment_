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
    public class CommonFunction : UtilityBase, ICommonFuncation
    {
        public CommonFunction(IRepositories unitOfWork) : base(unitOfWork)
        {

        }

        public DataTable GetAllfyList()
        {
            return UnitOfWork.CommonMasterRepository.GetAllfyList();
        }

        public DataTable GetAllGenderList()
        {
            return UnitOfWork.CommonMasterRepository.GetAllGenderList();
        }

        public List<CommonMasterModel> GetfyIDWise(int CommonID)
        {
            return UnitOfWork.CommonMasterRepository.GetfyIDWise(CommonID);
        }

        public List<CommonMasterModel> GetGenderIDWise(int CommonID)
        {
            return UnitOfWork.CommonMasterRepository.GetGenderIDWise(CommonID);
        }

        
    }
}
