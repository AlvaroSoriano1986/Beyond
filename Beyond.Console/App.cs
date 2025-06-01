using Beyond.Application.Contracts;

namespace Beyond.Console
{
    public class App
    {
        private readonly ITodoListApplication _todoListApplication;
        private short _currentOption = -1;

        public App(ITodoListApplication todoListApplication)
        {
            _todoListApplication = todoListApplication;
        }

        public void Run()
        {
            while (_currentOption != 0)
            {
                System.Console.WriteLine(PrintMenu());
                System.Console.Write("> ");
                ReadOption();

                try
                {
                    ExecuteAction();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        private string PrintMenu()
        {
            return
                $"SELECT AN OPTION:\n" +
                $"1. Add item\n" +
                $"2. Print items\n" +
                $"3. Register progression\n" +
                $"4. Remove item\n" +
                $"5. Update item\n" +
                $"0. Exit\n";
        }

        private void ReadOption()
        {
            var option = System.Console.ReadLine();

            try
            {
                _currentOption = short.Parse(option);

                if (_currentOption < 0 || _currentOption > 5)
                {
                    throw new Exception();
                }
            }
            catch
            {
                _currentOption = -1;
                System.Console.WriteLine("Invalid option");
            }
        }

        private void ExecuteAction()
        {
            switch (_currentOption)
            {
                case 1:
                    AddAction();
                    break;
                case 2:
                    _todoListApplication.PrintItems();
                    break;
                case 3:
                    RegisterProgressionAction();
                    break;
                case 4:
                    RemoveAction();
                    break;
                case 5:
                    UpdateAction();
                    break;
            }
        }

        private void AddAction()
        {
            System.Console.Write("Write title: ");
            var title = System.Console.ReadLine();
            System.Console.Write("Write description: ");
            var description = System.Console.ReadLine();

            var enabledCategories = _todoListApplication.GetAllCategories();

            System.Console.WriteLine("Select one category from the list below:");
            System.Console.WriteLine(string.Join(',', enabledCategories));
            System.Console.Write("> ");

            var category = System.Console.ReadLine();

            if (!enabledCategories.Contains(category))
            {
                System.Console.WriteLine("Invalid category");
                return;
            }

            _todoListApplication.AddItem(title, description, category);

            System.Console.WriteLine("Item successfuly added");
        }

        private void RegisterProgressionAction()
        {
            int id = 0;

            try
            {
                id = ReadId();
            }
            catch
            {
                return;
            }

            decimal percentage = 0;

            System.Console.Write("Write percentage: ");
            var percentageRead = System.Console.ReadLine();

            try
            {
                percentage = decimal.Parse(percentageRead);
            }
            catch
            {
                System.Console.WriteLine("Incorrect percentage");
                return;
            }

            var currentDate = DateTime.Now; // this value could be also asked by ui

            _todoListApplication.RegisterProgression(id, currentDate, percentage);

            System.Console.WriteLine("Progression successfuly added");
        }

        private void RemoveAction()
        {
            int id = 0;

            try
            {
                id = ReadId();
            }
            catch
            {
                return;
            }

            _todoListApplication.RemoveItemById(id);

            System.Console.WriteLine("Item successfuly removed");
        }

        private void UpdateAction()
        {
            int id = 0;

            try
            {
                id = ReadId();
            }
            catch
            {
                return;
            }

            System.Console.Write("Write new description: ");
            var description = System.Console.ReadLine();

            _todoListApplication.UpdateItem(id, description);

            System.Console.WriteLine("Item successfuly updated");
        }

        private int ReadId()
        {
            int id = 0;

            System.Console.Write("Write item id: ");
            var idRead = System.Console.ReadLine();

            try
            {
                id = int.Parse(idRead);
            }
            catch
            {
                System.Console.WriteLine("Incorrect id");
                throw new Exception();
            }

            return id;
        }
    }
}
