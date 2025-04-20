using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Management_DataAccess.Interface;
using College_Managment_Model;
using College_Managment_Utility.CustomerDomain.Interface;

namespace College_Managment_Utility.CustomerDomain
{
    public class SubjectMaster : UtilityBase, ISubjectMaster
    {
        public SubjectMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public DataTable GetAllSubjectList()
        {
            return UnitOfWork.SubjectMasterRepository.GetAllSubjectList();
        }

        public List<SubjectMasterDataModel> GetSubjectIDWise(int SubjectID)
        {
            return UnitOfWork.SubjectMasterRepository.GetSubjectIDWise(SubjectID);
        }

       

        public bool SaveData(SubjectMasterDataModel request)
        {
            return UnitOfWork.SubjectMasterRepository.SaveData(request);
        }
        public bool DeleteData(int SubjectID)
        {
            return UnitOfWork.SubjectMasterRepository.DeleteData(SubjectID);
        }
    }
}
