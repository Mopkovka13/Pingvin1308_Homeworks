using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using ToDoList.API.Contracts;
using ToDoList.Repository;
using ToDoList.Repository.Entities;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class IssuesController : ControllerBase
    {
        private readonly ILogger<IssuesController> _logger;
        private readonly IssuesRepository _issueRepository;

        public IssuesController(ILogger<IssuesController> logger)
        {
            _logger = logger;
            _issueRepository = new IssuesRepository();
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetIssuesResponse),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var issues = _issueRepository.Get();
            var response = new GetIssuesResponse
            {
                Issues = issues.Select(x => new Issue
                {
                    Id = x.Id,
                    Note = x.Note,
                    CreatedDate = x.CreatedDate
                }).ToArray()
            };
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody]CreateIssueRequest request)
        {
            Issue createIssue = new Issue
            {
                Note = request.Note,
                CreatedDate = DateTimeOffset.UtcNow
            };
            Guid issueId = await _issueRepository.Add(createIssue);
            return Ok(issueId);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody]UpdateIssueRequest request)
        {
            Issue updateIssue = new Issue
            {
                Id = request.Id, //Нам нужно знать, какую запись мы изменяем ?!
                Note = request.Note,
                CreatedDate = DateTimeOffset.UtcNow
            };
            bool updateSuccess = _issueRepository.Update(updateIssue);
            return Ok(updateSuccess);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromBody] DeleteIssueRequest request)
        {
            Issue deleteIssue = new Issue
            {
                Id = request.Id
            };
            bool deleteSuccess = _issueRepository.Delete(deleteIssue);
            return Ok(deleteSuccess);
        }
    }
}
