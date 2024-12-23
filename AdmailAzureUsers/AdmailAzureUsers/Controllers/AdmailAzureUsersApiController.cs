using AdmailAzureUsers.BL.Services;
using AdmailAzureUsers.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdmailAzureUsers.Controllers
{
    [ApiController]
    [Route("AdmailAzureUsersApi")]
    public class AdmailAzureUsersApiController : Controller
    {
        private readonly AzureUsersService azureUsersService;
        public AdmailAzureUsersApiController(AzureUsersService _azureUsersService)
        {
            azureUsersService = _azureUsersService;
        }


        [HttpGet]
        [Route("GetUsers/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> GetAzureusersAsync(int id)
        {
            ResponseDTO<object> res = new ResponseDTO<object>();
            try
            {
                res.data = await azureUsersService.GetAzureUsers(id);
                res.success = true;
                return Ok(res);
            }
            catch (Exception ex)
            {
                res.success = false;
                res.errorMessage = ex.Message;
                res.data = null;
                return BadRequest(res);
            }

        }
    }
}
