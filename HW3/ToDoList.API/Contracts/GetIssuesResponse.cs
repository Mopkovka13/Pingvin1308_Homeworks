using ToDoList.Repository.Entities;

namespace ToDoList.API.Contracts
{
    public sealed class GetIssuesResponse
    {
        public Issue[] Issues { get; set; }
    }
}
