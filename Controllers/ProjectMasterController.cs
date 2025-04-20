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
    public class ProjectMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;
        public ProjectMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("GetAllData")]

        public async Task<OperationResult<DataTable>> GetAllProjectList()
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ProjectMasterUtility.GetAllProjectData());
                result.State = OperationState.Success;
                if(result.Data != null && result.Data.Rows.Count>0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data Load Successfully";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No Record Found";

                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("ProjectMaster.GetAllDataList",ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        [HttpGet("GetDataIDWise/{ProjectID}")]

        public async Task<OperationResult<List<ProjectMasterDataModel>>> GetHODIDWise(int ProjectID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(ProjectID, "GetIDWise", 0, "ProjectController.GetIDWise");
            var result = new OperationResult<List<ProjectMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ProjectMasterUtility.GetProjectIDWise(ProjectID));
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
                CommonDataAccessHelper.Insert_ErrorLog("ProjectMasterController.GetProjectIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;

        }

        [HttpPost("SaveData")]

        public async Task<OperationResult<bool>> SaveData(ProjectMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExist = false;
                if (IfExist == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.ProjectMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.ProjectID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.ProjectID, "SaveData", 0, "HODController");
                            result.SuccessMessage = "Data Add Successfully !";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.ProjectID, "SaveData", 0, "HODController");
                            result.SuccessMessage = "Data Update Successfully !";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.ProjectID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.ProjectID + "is alredy tacken";
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

        [HttpPost("Delete/{projectID}")]

        public async Task<OperationResult<bool>> DeleteData(int projectID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.ProjectMasterUtility.DeleteData(projectID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", projectID, "HODMaster");
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
