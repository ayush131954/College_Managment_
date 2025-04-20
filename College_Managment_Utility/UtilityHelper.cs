using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Management_DataAccess.Interface;
using College_Management_DataAccess.Repository;
using College_Managment_DataAccess.Interface;
using College_Managment_Utility.CustomerDomain;
using College_Managment_Utility.CustomerDomain.Interface;
using Microsoft.Extensions.Configuration;

namespace College_Managment_Utility
{
    public class UtilityHelper : IUtilityHelper
    {
        public IRepositories UnitOfWork;
        
        public IDepartmentMaster DepartmentMasterUtility { get;  set; }
        public ICourseMaster CourseMasterUtility { get; set; }

        public IHODMaster HODMasterUtility {  get; set; }

        public ICommonFuncation CommonUtility { get; set; }

        public IStaffMaster StaffMasterUtility {  get; set; }

        public ISubjectMaster SubjectMasterUtility { get; set; }

        public IStudentMaster StudentMasterUtility { get; set; }

        public IStudentFessMaster StudentFessMasterUtility { get; set; }

        public IUserLogin UserLoginUtility { get; set; }

        public IProjectMaster ProjectMasterUtility { get; set; }

        public IDashboardCount DashboardCountUtility { get; set; }

        public ILibraryMaster LibraryMasterUtility { get; set; }

        public IStudentLibraryMaster StudentLibraryMasterUtility { get; set; }


        public UtilityHelper(IConfiguration configuration)
        {
            UnitOfWork = new CoreRepositories(configuration);
            InitializeUtilities();
        }        

        public void InitializeUtilities()
        {
            //StudentMasterUtility = new StudentMaster(UnitOfWork);
            //DepartmentMasterUtility = new DepartmentMaster(UnitOfWork);

            DepartmentMasterUtility = new DepartmentMaster(UnitOfWork);

            CourseMasterUtility = new CourseMaster(UnitOfWork);

            HODMasterUtility = new HODMaster(UnitOfWork);

            CommonUtility = new CommonFunction(UnitOfWork);

            StaffMasterUtility = new StaffMaster(UnitOfWork);

            SubjectMasterUtility = new SubjectMaster(UnitOfWork);

            StudentMasterUtility = new StudentMaster(UnitOfWork);

            StudentFessMasterUtility = new StudentFessMaster(UnitOfWork);

            UserLoginUtility = new UserLogin(UnitOfWork);

            ProjectMasterUtility = new ProjectMaster(UnitOfWork);

            DashboardCountUtility = new DashboardCount(UnitOfWork);

            LibraryMasterUtility = new LibraryMaster(UnitOfWork);

            StudentLibraryMasterUtility = new StudentLibraryMaster(UnitOfWork);
        }
    }
    
}

