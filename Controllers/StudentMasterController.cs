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
    public class StudentMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;
        private StudentFeesMasterDataModel dataModel;


        public StudentMasterController(IConfiguration configuration) : base(configuration)
        {
        }

        [HttpGet("GetAllStudentData")]

        public async Task<OperationResult<DataTable>> GetAllStudentList()
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StudentMasterUtility.GetAllStudentList());
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


        [HttpGet("GetDataIDWise/{StudentID}")]

        public async Task<OperationResult<List<StudentMasterDataModel>>> GetHODIDWise(int StudentID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(StudentID, "GetIDWise", 0, "StudentController.GetIDWise");
            var result = new OperationResult<List<StudentMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StudentMasterUtility.GetStudentIDWise(StudentID));
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
                CommonDataAccessHelper.Insert_ErrorLog("StudentMasterController.GetStudentIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;
        }


        [HttpPost("SaveData")]
        public async Task<OperationResult<bool>> SaveData(StudentMasterDataModel request)
        {
            var result = new OperationResult<bool>();

            try
            {
                bool IfExits = false;
                //IfExits = UtilityHelper.DepartmentMasterUtility.IfExists(request.StudentID, request.SFirstName);
                if (IfExits == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.StudentMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.StudentID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StudentID, "Save", 0, "StudentMaster");
                            result.SuccessMessage = "Saved successfully .!";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.StudentID, "Update", request.StudentID, "StudentMaster");
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
                    result.ErrorMessage = request.SFirstName + " is Already Exist, It Can't Not Be Duplicate.!";
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


        //[HttpPost("SaveData/{StudentID}")]
        //public async Task<OperationResult<bool>> SaveEditData(StudentMasterDataModel request)
        //{
        //    var result = new OperationResult<bool>();

        //    try
        //    {
        //        bool IfExits = false;
        //        IfExits = UtilityHelper.DepartmentMasterUtility.IfExists(request.StudentID, request.SFirstName);
        //        if (IfExits == false)
        //        {
        //            result.Data = await Task.Run(() => UtilityHelper.StudentMasterUtility.SaveData(request));
        //            if (result.Data)
        //            {
        //                result.State = OperationState.Success;
        //                if (request.StudentID == 0)
        //                {
        //                    CommonDataAccessHelper.Insert_TrnUserLog(request.StudentID, "Save", 0, "StudentMaster");
        //                    result.SuccessMessage = "Saved successfully .!";
        //                }
        //                else
        //                {
        //                    CommonDataAccessHelper.Insert_TrnUserLog(request.StudentID, "Update", request.StudentID, "StudentMaster");
        //                    result.SuccessMessage = "Updated successfully .!";
        //                }
        //            }
        //            else
        //            {
        //                result.State = OperationState.Error;
        //                if (request.StudentID == 0)
        //                    result.ErrorMessage = "There was an error adding data.!";
        //                else
        //                    result.ErrorMessage = "There was an error updating data.!";
        //            }
        //        }
        //        else
        //        {
        //            result.State = OperationState.Warning;
        //            result.ErrorMessage = request.SFirstName + " is Already Exist, It Can't Not Be Duplicate.!";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        CommonDataAccessHelper.Insert_ErrorLog("StudentMasterController.SaveData", e.ToString());
        //        result.State = OperationState.Error;
        //        result.ErrorMessage = e.Message.ToString();

        //    }
        //    finally
        //    {
        //        //UnitOfWork.Dispose();
        //    }
        //    return result;
        //}


        [HttpPost("Delete/{StudentID}")]


        public async Task<OperationResult<bool>> DeleteData(int StudentID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.StudentMasterUtility.DeleteData(StudentID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "DeleteData", StudentID, "DeleteData.StudentData");
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted Data Succesfully";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "This is error";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;
        }
    }
}
