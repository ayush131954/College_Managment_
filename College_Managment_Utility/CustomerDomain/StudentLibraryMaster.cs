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
    public class StudentLibraryMaster : UtilityBase, IStudentLibraryMaster
    {
        public StudentLibraryMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

       

        public DataTable GetAllStudentLibrary()
        {
            return UnitOfWork.StudentLibraryRepository.GetAllStudentLibrary();
        }

        public List<StudentLibraryDataModel> GetStudentLibraryIDWise(int StudLibraryID)
        {
            return UnitOfWork.StudentLibraryRepository.GetStudentLibraryIDWise(StudLibraryID);
        }

        public bool SaveData(StudentLibraryDataModel request)
        {
            return UnitOfWork.StudentLibraryRepository.SaveData(request);
        }

        public bool DeleteData(int StudLibraryID)
        {
            return UnitOfWork.StudentLibraryRepository.DeleteData(StudLibraryID);
        }
    }
}
