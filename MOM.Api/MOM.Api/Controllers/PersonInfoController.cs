using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOM.BasicAuthentication.Authentication.Basic.Attributes;
using MOM.Business.IServices;

namespace MOM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInfoController : ControllerBase
    {
        private readonly IPersonInfoService _personInfoService;
        public PersonInfoController(IPersonInfoService personInfoService)
        {
            _personInfoService = personInfoService;
        }

        [HttpGet("[action]"), BasicAuthorization]
        public IActionResult GetAllPersonInfo()
        {


            var ListOfPersonInfo = _personInfoService.GetAll();
            if (ListOfPersonInfo == null)
            {
                return NotFound();
                //return BadRequest("omid you faced a problem");
            }
            else
            {
                return Ok(ListOfPersonInfo);
            }
        }
    }
}
