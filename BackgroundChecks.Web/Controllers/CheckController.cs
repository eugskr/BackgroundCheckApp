using BackgroundChecks.Data.Models;
using BackgroundChecks.Data.Responses;
using BackgroundChecks.Services.CheckRepo;
using BackgroundChecks.Services.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundChecks.Web.Controllers
{
    [ApiController]
    
    public class CheckController : ControllerBase
    {
        private readonly ICheckService _service;

        public CheckController(ICheckService service)
        {
            _service = service;
        }

        [HttpPost("api/getcheck")]
        public CheckResponse Post(CheckRequest model)
        {
            return _service
                .ProcceedBackgroundCheck(model)
                .ToCheckResponse();
        }
    }
}
