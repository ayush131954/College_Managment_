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
    public class LibraryMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;
        public LibraryMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetAllData")]


        public async Task<OperationResult<DataTable>> GetAllBookData()
        {
            var result = new OperationResult<DataTable>();

            try
            {
                result.Data = UtilityHelper.LibraryMasterUtility.GetAllBooksList();
                result.State = OperationState.Success;
                if(result.Data!= null && result.Data.Rows.Count>0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data Load Sucessfully";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No Record Found";
                }
            }
            catch(Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LibraryMasterController.GetAllBookList",ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }


        [HttpGet("GetDataIDWise/{LibraryID}")]

        public async Task<OperationResult<List<LibraryMasterDataModel>>> GetBookIDWise(int LibraryID)
        {
            CommonDataAccessHelper.Insert_TrnUserLog(LibraryID, "GetIDWise", 0, "LibraryController.GetIDWise");
            var result = new OperationResult<List<LibraryMasterDataModel>>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LibraryMasterUtility.GetBookIDWise(LibraryID));
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
                CommonDataAccessHelper.Insert_ErrorLog("LibraryController.GetBookIDWise", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;
        }

        [HttpPost("SaveData")]

        public async Task<OperationResult<bool>> SaveData(LibraryMasterDataModel request)
        {
            var result = new OperationResult<bool>();
            try
            {
                bool IfExist = false;
                //IfExist = UtilityHelper.DepartmentMasterUtility.IfExists(request.SubjectID, request.SubjectName);
                if (IfExist == false)
                {
                    result.Data = await Task.Run(() => UtilityHelper.LibraryMasterUtility.SaveData(request));
                    if (result.Data)
                    {
                        result.State = OperationState.Success;
                        if (request.LibraryID == 0)
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.LibraryID, "SaveData", 0, "LibraryController");
                            result.SuccessMessage = "Data Add Successfully !";
                        }
                        else
                        {
                            CommonDataAccessHelper.Insert_TrnUserLog(request.LibraryID, "SaveData", 0, "LibraryController");
                            result.SuccessMessage = "Data Update Successfully !";
                        }
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        if (request.LibraryID == 0)
                            result.ErrorMessage = "There was an error adding data.!";
                        else
                            result.ErrorMessage = "There was an error updating data.!";
                    }
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = request.LibraryID + "is alredy tacken";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("LibraryMasterController.SaveData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            return result;

        }

        [HttpPost("Delete/{LibraryID}")]

        public async Task<OperationResult<bool>> DeleteData(int LibraryID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.LibraryMasterUtility.DeleteData(LibraryID));
                if (result.Data)
                {
                    CommonDataAccessHelper.Insert_TrnUserLog(0, "Delete", LibraryID, "LibraryMaster");
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
                CommonDataAccessHelper.Insert_ErrorLog("LibraryController.DeleteData", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();

            }
            return result;
        }

    }
}
