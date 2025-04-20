using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface ILibraryMasterRepository
    {
        DataTable GetAllBooksList();

        List<LibraryMasterDataModel> GetBookIDWise(int LibraryID);

        bool SaveData(LibraryMasterDataModel request);

        bool DeleteData(int LibraryID);
    }
}
