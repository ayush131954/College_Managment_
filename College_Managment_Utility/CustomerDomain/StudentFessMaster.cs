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
    public class StudentFessMaster : UtilityBase, IStudentFessMaster
    {
        public StudentFessMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

       
        public DataTable GetAllStudentFees()
        {
            return UnitOfWork.StudentFeesMasterRepository.GetAllStudentFees();
        }

        public List<StudentFeesMasterDataModel> GetStudentFeesIDWise(int FeesID)
        {
            return UnitOfWork.StudentFeesMasterRepository.GetStudentFeesIDWise(FeesID);
        }

        public bool SaveData(StudentFeesMasterDataModel request)
        {
            return UnitOfWork.StudentFeesMasterRepository.SaveData(request);
        }

        public bool DeleteData(int FeesID)
        {
            return UnitOfWork.StudentFeesMasterRepository.DeleteData(FeesID);
        }

    }
}
