using System.Text.Json;
using ToDoList.CLI.Entity;

namespace ToDoList.CLI.DB.Repository
{
    internal class AuthorizationRepository
    {
        private List<User> _users = new List<User>();
        private string _path = "C:\\Users\\Evgen\\Desktop\\Pingvin1308_Homeworks\\HW2\\ToDoList.CLI\\DB\\login.json"; //Не смог сделать норм путь, мог через Directory.GetCurrentDictionary(),
                                                                                                                      //но там мы в debug, а хотелось создать базу json на слое выше
        public AuthorizationRepository()
        {
            string jsonUsers = File.ReadAllText(_path);
            _users = JsonSerializer.Deserialize<List<User>>(jsonUsers);
        }
        public User? CheckUser(string login, string password)
        {
            var hashPassword = CreateMD5(password);
            var currentUser = _users.Where(x => x.Login == login && x.Password == hashPassword).ToList();
            if (currentUser.Count > 0) //Костыльно ;( Лучше не придумал
                return currentUser[0];
            return null;
        }

        public User CreateUser(string login, string password)
        {
            int newId = _users.Count > 0 ? _users.Max(x => x.Id) + 1 : 0;
            var hashPassword = CreateMD5(password);
            var newUser = new User(newId, login, hashPassword);
            _users.Add(newUser);
            string json = JsonSerializer.Serialize(_users);
            File.WriteAllText(_path, json);
            return newUser;
        }

        private string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
