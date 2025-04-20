using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Utility.CustomerDomain.Interface;

namespace College_Managment_Utility
{
    public interface IUtilityHelper
    {
        //IStudentMaster StudentMasterUtility { get; set; }

        IDepartmentMaster DepartmentMasterUtility { get; }
        ICourseMaster CourseMasterUtility { get; }

        IHODMaster HODMasterUtility { get; }

        ICommonFuncation CommonUtility { get; }

        IStaffMaster StaffMasterUtility { get; }

        ISubjectMaster SubjectMasterUtility { get; }

        IStudentMaster StudentMasterUtility { get; }

        IStudentFessMaster StudentFessMasterUtility { get; }

        IUserLogin UserLoginUtility { get; }

        IProjectMaster ProjectMasterUtility { get; }

        IDashboardCount DashboardCountUtility { get; }

        ILibraryMaster LibraryMasterUtility { get; }

        IStudentLibraryMaster StudentLibraryMasterUtility { get; }
    }
}
