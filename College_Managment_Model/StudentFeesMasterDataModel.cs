using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class StudentFeesMasterDataModel
    {
        public int FeesID { get; set; }
        public int StudentID { get; set; }
        public int DepartmentID { get; set; }
        //public string SFirstName { get; set; }
        //public string DepartmentName { get; set; }

        public int PaymentID { get; set; }
        public int FeeAmount { get; set; }
        public int PaidAmount { get; set; }
        public string DateOfPayment { get; set; }
        public int  CreatedBy { get; set; }
        public int ActiveStatus { get; set; }
        public int DeleteStatus { get; set; }
        public string IPAddress { get; set; }
    }
}
