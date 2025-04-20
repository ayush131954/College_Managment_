using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class DashboardCountModel
    {
        public int DepartmentCount { get; set; }
        public int CourseCount { get; set; }
        public int SubjectCount { get; set; }
        public int StudentFeeCount { get; set; }
        public int ProjectCount { get; set; }
        public int CollegeStaffCount { get; set; }
        public int HODCount { get; set; }
        public int StudentCount { get; set; }

        public int LibraryBookCount { get; set; }
        public int StudentLibraryCount { get; set; }
    }

    public class DashboardData  
    {
        public DataSet data { get; set; }
    }
}

