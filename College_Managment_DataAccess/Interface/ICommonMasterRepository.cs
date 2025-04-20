using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface ICommonMasterRepository
    {
        DataTable  GetAllGenderList();
        List<CommonMasterModel> GetGenderIDWise(int CommonID);

        DataTable GetAllfyList();
        List<CommonMasterModel> GetfyIDWise(int CommonID);
    }
}
