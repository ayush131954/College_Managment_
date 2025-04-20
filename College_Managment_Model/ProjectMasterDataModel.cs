using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class ProjectMasterDataModel
    {
        public int ProjectID { get; set; }

        public int DepartmentID { get; set; }

        public string StudentName { get; set; }

        public string ProjectName { get; set; }

        public string ProjectSpecification { get; set; }

        public string Semester {  get; set; }

        public string ProjectType { get; set; }

        public int ActiveStatus { get; set; }

        public int DeleteStatus { get; set; }

        public string IPAddress { get; set; }

    }
}
