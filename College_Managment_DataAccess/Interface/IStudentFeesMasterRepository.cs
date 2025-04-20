using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface IStudentFeesMasterRepository
    {
        DataTable GetAllStudentFees();

        List<StudentFeesMasterDataModel> GetStudentFeesIDWise(int FeesID);

        bool SaveData(StudentFeesMasterDataModel request);

        bool DeleteData(int FeesID);
    }
}
