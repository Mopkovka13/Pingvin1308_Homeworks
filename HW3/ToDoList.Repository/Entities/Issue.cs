namespace ToDoList.Repository.Entities
{
    public class Issue
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
