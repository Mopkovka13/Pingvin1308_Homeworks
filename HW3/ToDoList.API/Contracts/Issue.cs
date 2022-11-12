namespace ToDoList.API.Contracts
{
    public class Issue
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
