using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public  class HODMasterDataModel
    {
       public int HODID { get; set; }

       public int DepartmentID { get; set; }

        public int CourseID { get; set; }

        public string HODFirstName { get; set; }

        public string HODLastName { get; set; }

        public string MobileNumber { get; set; }

        public string CurrentAddress { get; set; }

        public string PermentAddress { get; set; }

        public string Email { get; set; }

        public int  Gender { get; set; }

        public int  AcademicYear { get; set; }

        public int  ActiveStatus { get; set; }

        public int DeleteStatus { get; set; }

        public string IPAddress { get; set; }


    }

    //public class HODMasterDataModel_List
    //{
    //    public DataTable data { get; set; }
    //}
}
