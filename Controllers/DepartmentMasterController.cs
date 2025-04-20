using College_Management_DataAccess.Common;
using College_Management_Model;
using College_Managment_Model;
using College_Managment_Utility;
using College_Managment_Utility.CustomerDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using College_Management_API.Controllers;
using College_Management_DataAccess.Interface;
using System.Data;
using College_Managment_DataAccess.Repositories;

namespace College_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;

        //DepartmentMasterRepository obj  = new DepartmentMasterRepository();

        public DepartmentMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

       

        [HttpGet("GetDepartmentList")]

        public async Task<OperationResult<DataTable>> GetAllDepartmentList()
        {
            //CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAllData", 0, "DepartmentMaster");
            var result = new OperationResult<DataTable>();
            try
            {

                //result.Data = obj.GetAllDepartmentMasterList();


                result.Data = await Task.Run(() => UtilityHelper.DepartmentMasterUtility.GetAllDepartmentList());
                result.State = OperationState.Success;
                if (result.Data != null && result.Data.Rows.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data loaded successfully!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentMasterController.GetAllDepartmentList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        [HttpGet("GetDepartmentList/{DepartmentID}")]
        public async Task<OperationResult<List<DepartmentMasterDataModel>>> GetDepartmentIDWise(int DepartmentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "FetchData_IDWise", DepartmentID, "DepartmentMaster");
            var result = new OperationResult<List<DepartmentMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentMasterUtility.GetDepartmentIDWise(DepartmentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentMasterController.GetDepartmentIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }


        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(DepartmentMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                //IfExits = UtilityHelper.DepartmentMasterUtility.IfExists(request.DepartmentID, request.DepartmentName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.DepartmentMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.DepartmentID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.DepartmentID, "Save", 0, "DepartmentMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.DepartmentID, "Update", request.DepartmentID, "DepartmentMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.DepartmentID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.DepartmentName + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }
        
       

        [HttpPost("Delete/{DepartmentID}")]

        public async Task <OperationResult<bool>> DeleteData(int DepartmentID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.DepartmentMasterUtility.DeleteData(DepartmentID));
                if(result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", DepartmentID, "DepartmentMaster");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Delete Successfully";
                }else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "There is an error";
                }

            }
            catch(Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DepartmentMasterController.DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

    }

}               

