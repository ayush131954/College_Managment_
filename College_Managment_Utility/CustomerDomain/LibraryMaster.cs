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
    public class LibraryMaster : UtilityBase, ILibraryMaster
    {
        public LibraryMaster(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        

        public DataTable GetAllBooksList()
        {
            return UnitOfWork.LibraryMasterRepository.GetAllBooksList();
        }

        public List<LibraryMasterDataModel> GetBookIDWise(int LibraryID)
        {
            return UnitOfWork.LibraryMasterRepository.GetBookIDWise(LibraryID);
        }

        public bool SaveData(LibraryMasterDataModel request)
        {
            return UnitOfWork.LibraryMasterRepository.SaveData(request);
        }

        public bool DeleteData(int LibraryID)
        {
            return UnitOfWork.LibraryMasterRepository.DeleteData(LibraryID);
        }
    }
}
