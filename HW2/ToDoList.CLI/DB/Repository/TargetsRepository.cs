using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.CLI.Entity;

namespace ToDoList.CLI.DB.Repository
{
    internal class TargetsRepository
    {
        private List<Target> _targets = new List<Target>();
        private string _path = "C:\\Users\\Evgen\\Desktop\\Pingvin1308_Homeworks\\HW2\\ToDoList.CLI\\DB\\target.json";
        public TargetsRepository()
        {
            string jsonTarget = File.ReadAllText(_path);
            _targets = JsonSerializer.Deserialize<List<Target>>(jsonTarget);
        }

        public void CreateTarget(string name, string description, int userId)
        {
            Target newTarget = new Target(name, description, userId);
            _targets.Add(newTarget);
            string json = JsonSerializer.Serialize(_targets);
            File.WriteAllText(_path, json);
        }

        public List<Target> GetTargets(int userId)
        {
            var targetsForCurrentUser = _targets.Where(x => x.UserId == userId).ToList();
            return targetsForCurrentUser;
        }
    }
}
