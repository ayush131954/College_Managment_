using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface ICourseMasterRepository
    {
        DataTable GetAllCourseList(int DepartmentID);

        List<CourseMasterDataModel> GetCourseIDWise(int CourseID);

        bool SaveData(CourseMasterDataModel request);

        bool DeleteData(int CourseID);

        bool IfExists(int CourseID, string CourseName);
    }
}
