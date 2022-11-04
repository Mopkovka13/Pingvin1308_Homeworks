using ToDoList.CLI.DB.Repository;
using ToDoList.CLI.Entity;

namespace ToDoList.CLI
{
    /// <summary>
    /// Поменять Status на False, когда задача выполнена
    /// Можно добавить Задачами Id, чтобы удаление и редактирование было по Id записи
    /// </summary>
    public class ToDoList
    {
        private Authorization _authorization;
        private TargetsRepository _targetsRepository;
        public ToDoList()
        {
            _authorization = new Authorization();
            _targetsRepository = new TargetsRepository();
        }
        public enum MenuList
        {
            Show = 1,
            Create = 2,
            Execute = 3,
            Update = 4,
            Delete = 5,
            Exit = 0

        }
        public void Start()
        {
            _authorization.Menu();
            if(_authorization.IsAuthenticated)
            {
                Menu();
            }
        }
        private void Menu()
        {
            int choose;
            do
            {
                foreach (var item in Enum.GetValues(typeof(MenuList))) //Вывод пунктов меню
                {
                    Console.WriteLine((int)item + ". " + item);
                }

                bool isCorrectValue = Int32.TryParse(Console.ReadLine(), out choose);
                if(choose ==(int)MenuList.Show)
                {
                    ShowTargets();
                }
                else if(choose ==(int)MenuList.Create)
                {
                    CreateTarget();
                }
            } while(choose != (int)MenuList.Exit);
        }

        public void ShowTargets()
        {
            foreach(var item in _targetsRepository.GetTargets(_authorization.CurrentUser.Id))
            {
                Console.WriteLine("Name: " + item.Name + 
                                  "Description: " + item.Description + 
                                  "CreationDate: " + item.Created);
            }
        }

        public void CreateTarget()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            _targetsRepository.CreateTarget(name, description, _authorization.CurrentUser.Id);
        }

    }
}
