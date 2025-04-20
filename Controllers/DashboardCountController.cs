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
    public class DashboardCountController : College_Management_ControllerBase
    {
        private IConfiguration _configuration;
        public DashboardCountController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetDashboardCount")]

        public async Task<OperationResult<List<DashboardData>>> GetDashboardCount()
        {

            CommonDataAccessHelper.Insert_TrnUserLog(0, "GetAllData", 0, "Dashboard");
            var result = new OperationResult<List<DashboardData>>();
            try
            {

                result.Data = await Task.Run(() => UtilityHelper.DashboardCountUtility.GetAllDashboardCount());
                result.State = OperationState.Success;
                if (result.Data.Count > 0)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Data load successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.SuccessMessage = "No record found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("DashboardMaster.GetDashboardCount", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }
    }
}
