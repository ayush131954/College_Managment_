using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_Utility.CustomerDomain.Interface
{
    public interface IStudentLibraryMaster
    {
        DataTable GetAllStudentLibrary();

        List<StudentLibraryDataModel> GetStudentLibraryIDWise(int StudLibraryID);

        bool SaveData(StudentLibraryDataModel request);

        bool DeleteData(int StudLibraryID);
    }
}
