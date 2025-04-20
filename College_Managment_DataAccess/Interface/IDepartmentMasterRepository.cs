using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface IDepartmentMasterRepository
    {
        DataTable GetAllDepartmentMasterList();
        List<DepartmentMasterDataModel> GetDepartmentIDWise(int DepartmentID); // Updated method name
        bool SaveData(DepartmentMasterDataModel request);
        //bool SaveToggleData(int DepartmentID);
        bool DeleteData(int DepartmentID);
        bool IfExists(int DepartmentID, string DepartmentName);
    }
}


