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
    public class StudentLibraryController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;
        public StudentLibraryController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetAllData")]

        public async Task<OperationResult<DataTable>> GetAllStudentLibraryList()
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StudentLibraryMasterUtility.GetAllStudentLibrary());
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

        [HttpGet("GetDataIDWise/{StudLibraryID}")]

        public async Task<OperationResult<List<StudentLibraryDataModel>>> GetDataIDWise(int StudLibraryID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(StudLibraryID, "GetIDWise", 0, "StudentLibraryController.GetIDWise");
            var result = new OperationResult<List<StudentLibraryDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StudentLibraryMasterUtility.GetStudentLibraryIDWise(StudLibraryID));
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
                CommonDataAccessHelper.Insert_ErrorLog("StudentLibraryController.GetBookIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;

        }

        [HttpPost("SaveData")]

        public async Task<OperationResult<bool>> SaveData(StudentLibraryDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExist = false;
                //IfExist = UtilityHelper.DepartmentMasterUtility.IfExists(request.SubjectID, request.SubjectName);
                if (IfExist == false)
                {
                    result.Data =UtilityHelper.StudentLibraryMasterUtility.SaveData(request);
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.StudLibraryID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StudLibraryID, "SaveData", 0, "StudentLibraryController");
                            result.SuccessMessage = "Data Add Successfully !";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StudLibraryID, "SaveData", 0, "StudentLibraryController");
                            result.SuccessMessage = "Data Update Successfully !";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.StudLibraryID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.StudLibraryID + "is alredy tacken";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("StudentLibraryMasterController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;

        }

        [HttpPost("Delete/{StudLibraryID}")]

        public async Task<OperationResult<bool>> DeleteData(int StudLibraryID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StudentLibraryMasterUtility.DeleteData(StudLibraryID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", StudLibraryID, "SubjectMaster");
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
