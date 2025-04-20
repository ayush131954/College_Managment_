using College_Management_API.Controllers;
using College_Management_DataAccess.Common;
using College_Management_Model;
using College_Managment_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace College_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;

        public UserLoginController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login/{UserName}/{Password}")]

        public async Task<OperationResult<List<UserLoginDataModel>>> Login(string UserName, string Password)
        {
            var result = new OperationResult<List<UserLoginDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.UserLoginUtility.Login(UserName, Password));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Login successfully .!";
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Please enter valid username or password.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("UserMasterController.UserMaster", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("SaveData")]

        public async Task<OperationResult<bool>> SaveData(UserLoginDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExist = false;
                //IfExist = UtilityHelper.DepartmentMasterUtility.IfExists(request.UserName, request.Password);
                if (IfExist == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.UserLoginUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.LoginID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.LoginID, "SaveData", 0, "StaffController");
                            result.SuccessMessage = "Account Create Successfully !";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.LoginID, "SaveData", 0, "StaffController");
                            result.SuccessMessage = "Data Update Successfully !";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.LoginID == 0)
                            result.ErrorMessage = "Username Alredy Tacken.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.LoginID + "is alredy tacken";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;

        }
    }
}
