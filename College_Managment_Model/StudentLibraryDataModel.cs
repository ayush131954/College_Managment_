using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Managment_Model
{
    public class StudentLibraryDataModel
    {
        public int StudLibraryID { get; set; }

        public int LibraryID { get; set; }

        public string StudentName { get; set; }

        public string PhoneNumber { get; set; }

        public string Semester { get; set; }

        public string EnrollmentNo { get; set; }

        public string DepartmentName { get; set; }

        public string Email { get; set; }

        public string  BookName { get; set; }

        public int BookNumber { get; set; }

        public string IssueDate { get; set; }

        public string ReturnDate { get; set; }

        public string IssueTeacherName { get; set; }

        public int ActiveStatus { get; set; }

        public int DeleteStatus { get; set; }

        public int CreateBy { get; set; }

        public int ModifyBy { get; set; }

        public string IPAddress { get; set; }
    }
}
