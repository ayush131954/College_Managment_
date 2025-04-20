using System.Data;
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
    public class StaffMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;
        public StaffMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetAllData")]

        public async Task<OperationResult<DataTable>> GetStaffAllData()
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StaffMasterUtility.GetAllStaffList());
                //result.State = OperationState.Success;
                if(result.Data!=null && result.Data.Rows.Count>0)
                {
                    result.State= OperationState.Success;
                    result.SuccessMessage = "Data Load Sucessfully";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No record Found";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StaffMasterController.GetAllDataList",ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        [HttpGet("GetDataIDWise/{StaffID}")]

        public async Task<OperationResult<List<StaffMasterDataModel>>> GetHODIDWise(int StaffID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(StaffID, "GetIDWise", 0, "StaffController.GetIDWise");
            var result = new OperationResult<List<StaffMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StaffMasterUtility.GetStaffIDWise(StaffID));
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StaffMasterController.GetStaffIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;
        }

        [HttpPost("SaveData")]

        public async Task<OperationResult<bool>> SaveData(StaffMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExist = false;
                if (IfExist == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.StaffMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.StaffID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StaffID, "SaveData", 0, "StaffController");
                            result.SuccessMessage = "Data Add Successfully !";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StaffID, "SaveData", 0, "StaffController");
                            result.SuccessMessage = "Data Update Successfully !";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.StaffID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.StaffID + "is alredy tacken";
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

        [HttpPost("Delete/{StaffID}")]

        public async Task<OperationResult<bool>> DeleteData(int StaffID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StaffMasterUtility.DeleteData(StaffID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", StaffID, "StaffMaster");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Delete Successfully";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "There is an error";
                }

            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StaffController.DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }
    }
}
