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
    public class UserLogin : UtilityBase, IUserLogin
    {
        public UserLogin(IRepositories unitOfWork) : base(unitOfWork)
        {
        }

        public DataTable GetUserLoginTable()
        {
            throw new NotImplementedException();
        }

        public List<UserLoginDataModel> Login(string username, string password)
        {
            return UnitOfWork.UserLoginRepository.Login(username, password);
        }

        public bool SaveData(UserLoginDataModel request)
        {
            return UnitOfWork.UserLoginRepository.SaveData(request);
        }
    }
}
