using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface IStudentMasterRepositiory
    {
        DataTable GetAllStudentList();

        List<StudentMasterDataModel> GetStudentIDWise(int StudentID);

        bool SaveData(StudentMasterDataModel request);

        //bool SaveEditData(StudentMasterDataModel request,int StudentID);

        bool DeleteData(int StudentID);
    }
}
