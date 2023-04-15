using animals.commands;
using animals.view;


namespace animals.controller
{
    internal class Controller
    {
        private View view;
        private UICommands cmd;

        public Controller(View view, UICommands cmd)
        {
            this.view = view;
            this.cmd = cmd;
        }
        public void Execute()
        {
            view.Print("Добро пожаловать в приложение 'animals'.");
            view.Print("");
            view.Print("Вам доступны следующие команды: ");
            view.Print("");
            cmd.Help();

            while (true)
            {
                view.Print("Введите команду: ");
                var userCommand = view.GetString();
                switch (userCommand.ToLower().Trim())
                {
                    case "add":
                        cmd.AddAnimal(cmd.GetAnimalName(), cmd.GetSpecies());
                        view.Print("");
                        break;

                    case "count":
                        cmd.PrintCount();
                        view.Print("");
                        break;

                    case "showcmd":
                        cmd.PrintAnimalCommands(cmd.SearchAnimalByName(cmd.GetAnimalName()));
                        view.Print("");
                        break;

                    case "addcmd":
                        cmd.AddNewAnimalComand(cmd.SearchAnimalByName(cmd.GetAnimalName()));
                        view.Print("");
                        break;

                    case "help":
                        cmd.Help();
                        view.Print("");
                        break;

                    case "exit":
                        view.Print("Работа приложения завершена. Нажмите любую кнопку...");
                        view.ReadKey();
                        return;

                    default:
                        view.Print("Неизвестная команда. Повторите ввод.");
                        view.Print("");
                        break;
                }
            }
        }
    }
}