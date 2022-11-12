namespace ToDoList.API.Contracts
{
    /// <summary>
    /// Можно было бы добавить Дату для ручного изменения
    /// Но мы будем изменять её на дату обновления.
    /// </summary>
    public class UpdateIssueRequest
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
    }
}
