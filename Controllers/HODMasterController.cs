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
    public class HODMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;

        public HODMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetHODList")]

        public async Task<OperationResult<DataTable>> GetAllHODList()
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HODMasterUtility.GetAllHODList());
                result.State = OperationState.Success;
                if (result.Data != null && result.Data.Rows.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load Successfully";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "NO Record Found";
                }

            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("HODMasterController.GetAllHODLIst", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        [HttpGet("GetDataIDWise/{HODID}")]

        public async Task<OperationResult<List<HODMasterDataModel>>>GetHODIDWise(int HODID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(HODID, "GetIDWise", 0, "HODController.GetIDWise");
            var result = new OperationResult<List<HODMasterDataModel>>();
            try
            {
                result.Data =  UtilityHelper.HODMasterUtility.GetHODIDWise(HODID);
                if(result.Data != null || result.Data.Count>0)
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
            catch(Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("HODController.GetHODIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;
        }

        [HttpPost("SaveData")]

        public async Task<OperationResult<bool>>SaveData(HODMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExist = false;
            if(IfExist == false)
            {
                    result.Data =  UtilityHelper.HODMasterUtility.SaveData(request);
                    if(result.Data)
                    {
                        result.State = OperationState.Success;
                        if(request.HODID==0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.HODID, "SaveData", 0, "HODController");
                            result.SuccessMessage = "Data Add Successfully !";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.HODID, "SaveData", 0, "HODController");
                            result.SuccessMessage = "Data Update Successfully !";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.HODID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
            }
            else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.HODID + "is alredy tacken";
                }
            }
            catch(Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("HODController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;

        }


        [HttpPost("Delete/{HODID}")]

        public async Task<OperationResult<bool>> DeleteData(int HODID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.HODMasterUtility.DeleteData(HODID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", HODID, "HODMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("HODController.DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }
    }
}