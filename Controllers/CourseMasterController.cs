using System.Data;
using College_Management_API.Controllers;
using College_Management_DataAccess.Common;
using College_Management_Model;
using College_Managment_Model;
using College_Managment_Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace College_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;

        public CourseMasterController (IConfiguration configuration) : base (configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetCourseList")]

        public async Task<OperationResult<DataTable>> GetAllCourseList(int DepartmentID)
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.GetAllCourseList(DepartmentID));
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

        [HttpGet("GetCourseList/{CourseID}")]
        public async Task<OperationResult<List<CourseMasterDataModel>>> GetDepartmentIDWise(int CourseID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(0, "FetchData_IDWise", CourseID, "DepartmentMaster");
            var result = new OperationResult<List<CourseMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.GetCourseIDWise(CourseID));
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
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.GetDepartmentIDWise", ex.ToString());
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

        public async Task<OperationResult<bool>> SaveData(CourseMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExist = false;
                if (IfExist == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.CourseID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.CourseID, "Save", 0, "CourseMaster");
                            result.SuccessMessage = "Data Save Succesfully !";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.CourseID, "Save", 0, "CourseMaster");
                            result.SuccessMessage = "Data Update Succesfully !";

                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.CourseID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.CourseName + "is alredy tacken";
                }
            }
            catch (Exception e)
            {
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.SaveData", e.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = e.Message.ToString();

            }
        return result;

        }

        [HttpPost("Delete/{CourseID}")]

        public async Task<OperationResult<bool>> DeleteData(int CourseID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CourseMasterUtility.DeleteData(CourseID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", CourseID, "CourseMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("CourseMasterController.DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }
    }
}
