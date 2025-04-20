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
    public class StudentFeesMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;

        public StudentFeesMasterController(IConfiguration configuration):base(configuration) 
        {
            _configuration = configuration;
        }

        [HttpGet("GetAllFeesData")]

        public async Task<OperationResult<DataTable>> GetAllDataList()
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StudentFessMasterUtility.GetAllStudentFees());
                result.State = OperationState.Success;
                if(result.Data!= null && result.Data.Rows.Count>0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load Successfully";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No Record Found ";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StudentFeesController.GetAllStudentList", ex.ToString());
                result.State=OperationState.Error;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }

        [HttpGet("GetDataIDWise/{FeesID}")]

        public async Task<OperationResult<List<StudentFeesMasterDataModel>>> GetFeesIDWise( int FeesID)
        {
            var result = new OperationResult<List<StudentFeesMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StudentFessMasterUtility.GetStudentFeesIDWise(FeesID));
                result.State = OperationState.Success;
                if (result.Data != null && result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load Successfully";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No Record Found ";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StudentFeesController.GetAllStudentList", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(StudentFeesMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                //IfExits = UtilityHelper.StudentFessMasterUtility.IfExists(request.StudentID, request.SFirstName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.StudentFessMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.StudentID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.FeesID, "Save", 0, "StudentMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.FeesID, "Update", request.FeesID, "StudentMaster");
                            result.SuccessMessage = "Updated successfully .!";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.StudentID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.PaymentID + " is Already Exist, It Can't Not Be Duplicate.!";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StudentMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
            finally
            {
                //UnitOfWork.Dispose();
            }
            return result;
        }

        [HttpPost("Delete/{FeesID}")]

        public async Task<OperationResult<bool>> DeleteData(int FeesID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StudentFessMasterUtility.DeleteData(FeesID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", FeesID, "FeesMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("FeesController.DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }


    }
}
