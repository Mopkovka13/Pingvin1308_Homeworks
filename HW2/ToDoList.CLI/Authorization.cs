using ToDoList.CLI.DB.Repository;
using ToDoList.CLI.Entity;

namespace ToDoList.CLI
{
    internal class Authorization
    {
        private AuthorizationRepository _authRepository;
        public Authorization()
        {
            _authRepository = new AuthorizationRepository();
        }
        public User? CurrentUser { get; private set; } = null;
        public bool IsAuthenticated { get; private set; } = false;
        
        enum MenuList
        {
            SignIn = 1,
            SignUp = 2,
            Exit = 3
        }

        public void Menu()
        {
            int choose;
            do
            {
                foreach (var item in Enum.GetValues(typeof(MenuList))) //Вывод пунктов меню
                {
                    Console.WriteLine((int)item + ". " + item);
                }

                bool isCorrectValue = Int32.TryParse(Console.ReadLine(), out choose); //Можно сделать вывод относительно ошибки

                if (choose == (int)MenuList.SignIn)
                    SignIn();
                else if(choose == (int)MenuList.SignUp)
                    SignUp();
            } while (choose != (int)MenuList.Exit && IsAuthenticated == false);
        }

        private void SignIn()
        {
            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            CurrentUser = _authRepository.CheckUser(login, password);
            if (CurrentUser != null)
                IsAuthenticated = true;
        }

        private void SignUp()
        {
            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            CurrentUser = _authRepository.CreateUser(login, password);
            if (CurrentUser != null)
                IsAuthenticated = true;
        }
    }
}
