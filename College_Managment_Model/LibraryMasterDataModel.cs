using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class LibraryMasterDataModel
    {
        public int LibraryID { get; set; }

        public string BookName { get; set; }

        public string BookNumber { get; set; }

        public string TypeOfBook { get; set; }

        public int TotalBooks { get; set; }

        public int ActiveStatus { get; set; }

        public int DeleteStatus { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }

        public string IPAddress { get; set; }
    }
}
