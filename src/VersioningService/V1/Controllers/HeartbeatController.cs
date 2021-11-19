using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VersioningService.Core.Interfaces.Services;
using VersioningService.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersioningService.V1.Controllers
{
    // [Route("api/[controller]")]
    // [Route("api" + "/v{api-version:apiVersion}/[controller]")]
    // [Route("api/" + ApiConstants.ServiceName + "/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HeartbeatController : Controller
    {
        public HeartbeatController()
        {
        }
        // GET: api/values
        [HttpGet]
        [Route("ping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Get()
        {
            // return await Task.FromResult<ActionResult<bool>>(Ok(true));
            return Ok(true);
        }
    }
}
