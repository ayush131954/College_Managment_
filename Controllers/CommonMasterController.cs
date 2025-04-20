using System.Data;
using College_Management_API.Controllers;
using College_Management_DataAccess.Common;
using College_Management_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace College_Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonMasterController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;
        public CommonMasterController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetGenderList")]

        public async Task<OperationResult<DataTable>> GetAllGenderList()
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonUtility.GetAllGenderList());
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

        [HttpGet("GetYearList")]

        public async Task<OperationResult<DataTable>> GetAllYearList()
        {
            var result = new OperationResult<DataTable>();
            try
            {
                result.Data = await Task.Run(() => UtilityHelper.CommonUtility.GetAllfyList());
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
    }
}
