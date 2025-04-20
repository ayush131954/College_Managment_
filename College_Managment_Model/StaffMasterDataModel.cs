using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class StaffMasterDataModel
    {
        public int StaffID { get; set; }

        public int DepartmentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string CurrentAddress { get; set; }

        public string PermentAddress { get; set; }

        public int Gender { get; set; } 

        public int AcademicYear { get; set; }

        public int ActiveStatus { get; set; }

        public int DeleteStatus  { get; set; }

        public int CreatedBy { get; set; }

        public int ModifyBy { get; set; }

        public string IPAddress { get; set; }
    }
}
