using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class DepartmentMasterDataModel
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        //public int UserID { get; set; }

        public int CreatedBy { get; set; }

        public int ModifyBy { get; set; }

        public string IPAddress { get; set; }
        public int ActiveStatus { get; set; }
        public int DeleteStatus { get; set; }
    }

    //public class DepartmentMasterDataModel_List
    //{
    //   public DataTable data { get; set; }

    //    public int DepartmentID { get; set; }
    //    public string DepartmentName { get; set; }
    //    public int ActiveStatus { get; set; }
    //    //public int DepatmenetID { get; set; }
    //    //public string DepatmenetName { get; set; }
    //}
}
