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
        [Route("GetUsers/{domain}")]
        [Produces("application/json")]
        public async Task<ActionResult> GetAzureUsers(string domain)
        {
            ResponseDTO<object> res = new ResponseDTO<object>();
            try
            {
                res.data = await azureUsersService.GetAzureUsers(domain);
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
        [HttpGet]
        [Route("GetGroups/{domain}")]
        [Produces("application/json")]
        public async Task<ActionResult> GetAzureGroups(string domain)
        {
            ResponseDTO<object> res = new ResponseDTO<object>();
            try
            {
                res.data = await azureUsersService.GetAzureGroups(domain);
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
