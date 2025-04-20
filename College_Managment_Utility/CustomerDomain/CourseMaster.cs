using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using College_Management_DataAccess.Interface;
using College_Managment_Model;
using College_Managment_Utility.CustomerDomain.Interface;

namespace College_Managment_Utility.CustomerDomain
{
    public class CourseMaster : UtilityBase , ICourseMaster
    {
        public CourseMaster(IRepositories unitOfWork) : base(unitOfWork)
        {

        }
        public DataTable GetAllCourseList(int DepartmentID)
        {
            return UnitOfWork.CourseMasterRepository.GetAllCourseList(DepartmentID);
        }

        public List<CourseMasterDataModel> GetCourseIDWise(int CourseID)
        {
            return UnitOfWork.CourseMasterRepository.GetCourseIDWise(CourseID);
        }

        public bool SaveData(CourseMasterDataModel request)
        {
            return UnitOfWork.CourseMasterRepository.SaveData(request);
        }
        public bool DeleteData(int CourseID)
        {
            return UnitOfWork.CourseMasterRepository.DeleteData(CourseID);
        }
        public bool IfExists(int DepartmentID, string DepartmentName)
        {
            return UnitOfWork.CourseMasterRepository.IfExists(DepartmentID, DepartmentName);
        }
    }

}
