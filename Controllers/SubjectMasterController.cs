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
    public class SubjectMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;
        public SubjectMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetAllData")]

        public async Task<OperationResult<DataTable>>GetAllSubjectList()
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SubjectMasterUtility.GetAllSubjectList());
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

        [HttpGet("GetDataIDWise/{SubjectID}")]

        public async Task<OperationResult<List<SubjectMasterDataModel>>> GetHODIDWise(int SubjectID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(SubjectID, "GetIDWise", 0, "SubjectController.GetIDWise");
            var result = new OperationResult<List<SubjectMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SubjectMasterUtility.GetSubjectIDWise(SubjectID));
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
                CommonDataAccessHelper.Insert_ErrorLog("SubjectMasterController.GetStaffIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;
        }


        [HttpPost("SaveData")]

        public async Task<OperationResult<bool>> SaveData(SubjectMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExist = false;
                //IfExist = UtilityHelper.DepartmentMasterUtility.IfExists(request.SubjectID, request.SubjectName);
                if (IfExist == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.SubjectMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.SubjectID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.SubjectID, "SaveData", 0, "StaffController");
                            result.SuccessMessage = "Data Add Successfully !";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.SubjectID, "SaveData", 0, "StaffController");
                            result.SuccessMessage = "Data Update Successfully !";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.SubjectID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.SubjectID + "is alredy tacken";
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

        [HttpPost("Delete/{SubjectID}")]

        public async Task<OperationResult<bool>> DeleteData(int SubjectID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.SubjectMasterUtility.DeleteData(SubjectID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", SubjectID, "SubjectMaster");
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
