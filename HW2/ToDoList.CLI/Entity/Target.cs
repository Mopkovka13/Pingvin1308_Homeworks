namespace ToDoList.CLI.Entity
{
    internal class Target
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public DateTime Created { get; private set; }
        public int UserId { get; private set; }
        public Target(string name, string description, int userId)
        {
            Name = name;
            Description = description;
            Status = true;
            UserId = userId;
            Created = DateTime.Now;
        }
    }
}
