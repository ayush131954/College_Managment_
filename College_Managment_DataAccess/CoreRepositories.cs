using System;
using System.Collections.Generic;
using System.Text;
using College_Management_DataAccess.Interface;
using Microsoft.Extensions.Configuration;
using College_Management_DataAccess.Common;
using College_Management_DataAccess.Repository;
using College_Managment_DataAccess.Repositories;
using Microsoft.IdentityModel.Tokens;
using College_Managment_DataAccess.Interface;

namespace College_Management_DataAccess.Repository
{
    public class CoreRepositories : IRepositories
    {
        protected CommonDataAccessHelper CommonHelper { get; set; }
        public CoreRepositories(IConfiguration configuration)
        {
            CommonHelper = new CommonDataAccessHelper(configuration);
            IntializeRepositories(CommonHelper);
        }

        private IStudentMasterRepositiory studentMasterRepositiory;
        public IStudentMasterRepositiory StudentMasterRepository
        {
            get { return studentMasterRepositiory; }
        }

        private IDepartmentMasterRepository departmentMasterRepository;
        public IDepartmentMasterRepository DepartmentMasterRepository

        {
            get { return departmentMasterRepository; }
        }

        private ICourseMasterRepository courseMasterRepository;

        public ICourseMasterRepository CourseMasterRepository
        {
            get { return courseMasterRepository; }
        }

        private IHODMasterRepository hodMasterRepository;

        public IHODMasterRepository HODMasterRepository
        {
            get { return hodMasterRepository; }
        }

        private ICommonMasterRepository commonMasterRepository;
        public ICommonMasterRepository CommonMasterRepository

        {
            get { return commonMasterRepository; }
        }

        private IStaffMasterRepository staffMasterRepository;
        public IStaffMasterRepository StaffMasterRepository

        {
            get { return staffMasterRepository; }
        }

        private ISubjectMasterRepository subjectMasterRepository;
        public ISubjectMasterRepository SubjectMasterRepository

        {
            get { return subjectMasterRepository; }
        }

        private IStudentFeesMasterRepository studentFeesMasterRepository;
        public IStudentFeesMasterRepository StudentFeesMasterRepository

        {
            get { return studentFeesMasterRepository; }
        }

        private IUserLoginRepository userLoginRepository;
        public IUserLoginRepository UserLoginRepository

        {
            get { return userLoginRepository; }
        }

        private IProjectMasterRepository projectMasterRepository;
        public IProjectMasterRepository ProjectMasterRepository
        {
            get { return projectMasterRepository; }
        }

        private IDashboardCountRepository dashboardCountRepository;
        public IDashboardCountRepository DashboardCountRepository
        {
            get { return dashboardCountRepository; }
        }

        private ILibraryMasterRepository libraryMasterRepository;
        public ILibraryMasterRepository LibraryMasterRepository
        {
            get { return libraryMasterRepository; }
        }

        private IStudentLibraryRepository studentLibraryRepository;

        public IStudentLibraryRepository StudentLibraryRepository
        {
            get { return studentLibraryRepository; }
        }



        public void IntializeRepositories(CommonDataAccessHelper commonHelper)
        {
            studentMasterRepositiory = new StudentMasterRepositiory(commonHelper);
            departmentMasterRepository = new DepartmentMasterRepository(commonHelper);
            courseMasterRepository = new CourseMasterRepository(commonHelper);
            hodMasterRepository = new HODMasterRepository(commonHelper);
            commonMasterRepository = new CommonMasterRepository(commonHelper);
            staffMasterRepository = new StaffMasterRepository(commonHelper);
            subjectMasterRepository = new SubjectMasterRepository(commonHelper);    
            studentFeesMasterRepository = new StudentFeesMasterRepository(commonHelper);
            userLoginRepository = new UserLoginRepository(commonHelper);  
            projectMasterRepository = new ProjectMasterRepository(commonHelper);
            dashboardCountRepository = new DashboardCountRepository(commonHelper);
            libraryMasterRepository = new LibraryMasterRepository(commonHelper);
            studentLibraryRepository = new StudentLibraryRepository(commonHelper);  
        }
    }
}
