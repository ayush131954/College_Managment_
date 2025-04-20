using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class SubjectMasterDataModel
    {
        public int SubjectID { get; set; }

        public int DepartmentID { get; set; }

        public int CourseID { get; set; }

        public string SubjectName { get; set; }

        public int ActiveStatus { get; set; }

        public int DeleteStatus { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }

        public string IPAddress { get; set; }


    }
}
