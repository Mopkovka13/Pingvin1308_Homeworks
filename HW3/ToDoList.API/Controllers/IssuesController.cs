using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using ToDoList.API.Contracts;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class IssuesController : ControllerBase
    {
        private readonly ILogger<IssuesController> _logger;

        public IssuesController(ILogger<IssuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetIssuesResponse),(int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody]CreateIssueRequest request)
        {
            return Ok(5);
        }
    }
}
