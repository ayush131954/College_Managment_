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
    public class StudentMaster : UtilityBase, IStudentMaster
    {
        public StudentMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        

        public DataTable GetAllStudentList()
        {
            return UnitOfWork.StudentMasterRepository.GetAllStudentList();
        }

        public List<StudentMasterDataModel> GetStudentIDWise(int StudentID)
        {
            return UnitOfWork.StudentMasterRepository.GetStudentIDWise(StudentID);
        }

        public bool SaveData(StudentMasterDataModel request)
        {
            return UnitOfWork.StudentMasterRepository.SaveData(request);
        }

        public bool DeleteData(int StudentID)
        {
            return UnitOfWork.StudentMasterRepository.DeleteData(StudentID);
        }

        //public bool SaveEditData(StudentMasterDataModel request, int StudentID)
        //{
        //    return UnitOfWork.StudentMasterRepository.SaveEditData(request, StudentID);
        //}
    }
}
