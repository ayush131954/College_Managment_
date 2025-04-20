using College_Management_DataAccess.Repository;
using College_Management_DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using College_Managment_DataAccess.Interface;

namespace College_Management_DataAccess.Interface
{
    public interface IRepositories
    {
        IStudentMasterRepositiory StudentMasterRepository { get; }

        IDepartmentMasterRepository DepartmentMasterRepository { get; }

        ICourseMasterRepository CourseMasterRepository { get; }

        IHODMasterRepository HODMasterRepository { get; }

        ICommonMasterRepository CommonMasterRepository { get; }

        IStaffMasterRepository StaffMasterRepository { get; }

        ISubjectMasterRepository SubjectMasterRepository { get; }

        IStudentFeesMasterRepository StudentFeesMasterRepository { get; }

        IUserLoginRepository UserLoginRepository { get; }

        IProjectMasterRepository ProjectMasterRepository { get; }

        IDashboardCountRepository DashboardCountRepository { get; }

        ILibraryMasterRepository LibraryMasterRepository { get; }

        IStudentLibraryRepository StudentLibraryRepository { get; }
    }
}
