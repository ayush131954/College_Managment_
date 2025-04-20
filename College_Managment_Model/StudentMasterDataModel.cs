using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class StudentMasterDataModel
    {
        public int StudentID { get; set; }
        public int DepartmentID { get; set; }
        public int CourseID { get; set; }
        public string SFirstName { get; set; }
        public string SMiddleName { get; set; }
        public string SLastName { get; set; }
        public string MobileNumber { get; set; }
        public string PermentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int  Gender { get; set; }
        //public string XMarksheet { get; set; } = string.Empty;
        //public string XIIMarksheet { get; set; }= string.Empty;
        public int  ActiveStatus { get; set; }
        public int  DeleteStatus { get; set; }
        public string IPAddress { get; set; }
        public int AcademicYear { get; set; }


    }
    
}
