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
    public class DepartmentMaster : UtilityBase, IDepartmentMaster
    {
        public DepartmentMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public DataTable GetAllDepartmentList()
        {
            return UnitOfWork.DepartmentMasterRepository.GetAllDepartmentMasterList();
        }
        public List<DepartmentMasterDataModel> GetDepartmentIDWise(int DepartmentID)
        {
            return UnitOfWork.DepartmentMasterRepository.GetDepartmentIDWise(DepartmentID);
        }
        public bool SaveData(DepartmentMasterDataModel request)
        {
            return UnitOfWork.DepartmentMasterRepository.SaveData(request);
        }
       
        public bool DeleteData(int DepartmentID)
        {
            return UnitOfWork.DepartmentMasterRepository.DeleteData(DepartmentID);
        }

        public bool IfExists(int DepartmentID, string DepartmentName)
        {
            return UnitOfWork.DepartmentMasterRepository.IfExists(DepartmentID, DepartmentName);
        }
    }
}

//using System.Collections.Generic;
//using System.Threading.Tasks;
//using College_Management_DataAccess.Interface;
//using College_Managment_Model;
//using College_Managment_Utility.CustomerDomain.Interface;

//namespace College_Managment_Utility.CustomerDomain
//{
//    public class DepartmentMaster : UtilityBase, IDepartmentMaster
//    {
//        public DepartmentMaster(IRepositories unitOfWork) : base(unitOfWork)
//        {
//        }

//        public List<DepartmentMasterDataModel_List> GetAllDepartmentList()
//        {
//            return UnitOfWork.DepartmentMasterRepository.GetAllDepartmentMasterList();
//        }

//        public List<DepartmentMasterDataModel> GetDepartmentIDWise(int DepartmentID)
//        {
//            // Your logic to fetch departments by ID
//            return new List<DepartmentMasterDataModel>();
//        }

//        public bool SaveData(DepartmentMasterDataModel request)
//        {
//            return UnitOfWork.DepartmentMasterRepository.SaveData(request);
//        }

//        public async Task<bool> DeleteData(int DepartmentID)
//        {
//            // Your delete logic here
//            return true;
//        }

//        public async Task<bool> IfExists(int departmentID, string departmentName)
//        {
//            // Your check logic here
//            return false;
//        }

//..................................................................


//Task<bool> IDepartmentMaster.SaveData(DepartmentMasterDataModel request)
//{
//    throw new NotImplementedException();
//}

//public async Task<DepartmentMasterDataModel_List> GetAllDepartmentList()
//{
//    return await UnitOfWork.DepartmentMasterRepository.GetAllDepartmentMasterList();
//}

//public List<DepartmentMasterDataModel> GetDepartmentIDWise(int DepartmentID)
//{
//    return UnitOfWork.DepartmentMasterRepository.GetDepartmentIDWise(DepartmentID);
//}

//public bool SaveData(DepartmentMasterDataModel request)
//{
//    return UnitOfWork.DepartmentMasterRepository.SaveData(request);
//}

//public bool DeleteData(int DepartmentID)
//{
//    return UnitOfWork.DepartmentMasterRepository.DeleteData(DepartmentID);
//}

//public bool IfExists(int DepartmentID, string DepartmentName)
//{
//    return UnitOfWork.DepartmentMasterRepository.IfExists(DepartmentID, DepartmentName);
//}
//}
//}
