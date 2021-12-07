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
    public class MicrofrontEndsController : Controller
    {
        private readonly IMicrofrontEndService _mfeService;

        public MicrofrontEndsController(IMicrofrontEndService mfeService)
        {
            _mfeService = mfeService ?? throw new ArgumentNullException(nameof(mfeService));
        }
        // GET: api/values
        [HttpGet]
        // [SwaggerOperation("GetMicrofrontEnds")]
        // [Route("getMicrofrontEnds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]// (typeof(ApiErrorResponse), 401)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MicrofronEnd>>> Get()
        {
            // throw new Exception($"Error while trying to call GetMicrofrontends method");
            var response = await _mfeService.GetAllMicrofrontEnds();
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MicrofronEnd>> Get(Guid id)
        {
            var mfe = await _mfeService.GetMicrofronEndById(id);
            return mfe != null ? Ok(mfe) : NotFound();
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MicrofronEnd>> Post(MicrofronEnd mfe) //[FromBody] string value
        {
            if (!ModelState.IsValid) // This will be replaced by FluentValidation
            {
                return BadRequest();
            }
            var response = await _mfeService.CreateMicrofronEnd(mfe);
            // return CreatedAtRoute(nameof(Get), new {Id = response.id} response);
            // return CreatedAtRoute(nameof(Get), response);
            return CreatedAtAction(nameof(Get), new { version = HttpContext.GetRequestedApiVersion().ToString(), controller = "MicrofrontEnds" }, response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Put(Guid id, MicrofronEnd mfe) //[FromBody] string value
        {
            if (!ModelState.IsValid) // This will be replaced by FluentValidation
            {
                return BadRequest();
            }
            return await _mfeService.UpdateMicrofrontEnd(id, mfe).ConfigureAwait(false);
        }

        // DELETE api/values/5
        [HttpDelete("{id}", Name = "DeleteMicrofrontEnd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return await _mfeService.DeleteMicrofrontEnd(id);
        }
    }
}
