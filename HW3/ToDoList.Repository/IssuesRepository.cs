using System.IO;
using System.Text;
using System.Text.Json;
using ToDoList.Repository.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoList.Repository
{
    /// <summary>
    /// Не оптимальный вариант репозитория на файлах, т.к. при больших размерах весь файл каждый раз перезаписывать...
    /// Удобнее было бы содержать много файлов для каждоый записи и получать GetFiles из директории.
    /// Удаление бы просто удаляло файл с названием Id (Guid)
    /// </summary>
    public class IssuesRepository
    {
        private readonly string _path = "C:\\Users\\Evgen\\Desktop\\Pingvin1308_Homeworks\\HW3\\ToDoList.Repository\\Issues.json";
        private List<Issue> _issues;
        public IssuesRepository()
        {
            _issues = new List<Issue>();
        }
        private async void ReadFile()
        {
            using (StreamReader reader = new StreamReader(_path))
            {
                string jsonIssue = await reader.ReadToEndAsync();
                _issues = JsonSerializer.Deserialize<List<Issue>>(jsonIssue);
            }
        }
        private async void RefreshFile()
        {
            using (StreamWriter writer = new StreamWriter(_path, false))
            {
                string jsonIssues = JsonSerializer.Serialize(_issues);
                await writer.WriteLineAsync(jsonIssues);
            }
        }
        public Issue[] Get()
        {
            ReadFile();
            Issue[] result = _issues.ToArray();
            return result;
        }

        public async Task<Guid> Add(Issue issue)
        {
            issue.Id = Guid.NewGuid();
            _issues.Add(issue);
            RefreshFile();
            return issue.Id;
        }

        public bool Update(Issue issue)
        {
            _issues.Where(x => x.Id == issue.Id).ToList().ForEach(i => i.Note = issue.Note);
            RefreshFile();
            return true;
        }
        public bool Delete(Issue issue)
        {
            _issues = _issues.Where(x => x.Id != issue.Id).ToList();
            RefreshFile();
            return true;
        }
    }
}