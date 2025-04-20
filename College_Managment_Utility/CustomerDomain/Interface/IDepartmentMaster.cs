using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_Utility.CustomerDomain.Interface
{
    public interface IDepartmentMaster
    {
        DataTable GetAllDepartmentList();  
        List<DepartmentMasterDataModel> GetDepartmentIDWise(int DepartmentID);
        bool SaveData(DepartmentMasterDataModel request);
        //bool SaveToggleData(int DepartmentID);
        //Task<bool> DeleteData(int DepartmentID);
        bool DeleteData(int DepartmentID);
        //Task<bool> IfExists(int departmentID, string departmentName); // Changed to async

        bool IfExists(int departmentID, string departmentName);
    }
}
