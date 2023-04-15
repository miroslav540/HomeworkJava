using animals.model;
using animals.model.PackAnimals;
using animals.view;

namespace animals.commands
{
    internal class UICommands
    {
        private View view;
        private static Dictionary<string, string> listCommands = new()
        {
             {"Add", "Добавляет животное в базу данных питомника."},
             {"ShowCmd", "Выводит на экран команды, которые знает животное."},
             {"AddCmd", "Обучает животное новой команде."},
             {"Help", "Выводит список доступных команд для пользователя."},
             {"Count", "Вывод общего количества животных."},
             {"Exit", "Выйти из программы."}
        };

        internal UICommands(View view)
        {
            this.view = view;
        }
        internal void AddAnimal(string name, string species)
        {
            switch (species.ToLower().Trim())
            {
                case "cat":
                    var newCat = new Cat(name, species);
                    AddToPetDict(species, newCat);
                    break;
                case "dog":
                    var newDog = new Dogs(name, species);
                    AddToPetDict(species, newDog);
                    break;
                case "humster":
                    var newHumster = new Humsters(name, species);
                    AddToPetDict(species, newHumster);
                    break;
                case "horse":
                    var newHorse = new Horses(name, species);
                    AddToPackAnimalsDict(species, newHorse);
                    break;
                case "camel":
                    var newCamel = new Camels(name, species);
                    AddToPackAnimalsDict(species, newCamel);
                    break;
                case "donkey":
                    var newDonkey = new Donkeys(name, species);
                    AddToPackAnimalsDict(species, newDonkey);
                    break;
            }
        }

        internal void PrintAnimalCommands(Animals animal)
        {
            foreach (string item in animal.Commands)
                view.Print(item);
        }

        internal string GetAnimalName()
        {
            view.Print($"Введите имя животного: ");
            return view.GetString();
        }

        internal void AddNewAnimalComand(Animals animal)
        {
            view.Print($"Введите название для новой команды");
            string result = view.GetString();
            animal.Commands.Add(result);
            view.Print($"Команда {result} изучена {animal.Name}");
        }

        internal Animals SearchAnimalByName(string name)
        {
            var list = new List<Animals>();

            string animalName = name;
            string species = GetSpecies();

            if (Animals.pets.ContainsKey(species))
                if (Animals.pets.TryGetValue(species, out List<Animals> result))
                    list = result;
                else if (Animals.packedAnimals.ContainsKey(species))
                    if (Animals.packedAnimals.TryGetValue(species, out List<Animals> result1))
                        list = result1;
                    else return default;

            foreach (Animals animals in list)
            {
                if (animals.Name.Equals(animalName))
                {
                    return animals;
                }
            }

            return default;
        }

        internal void Help()
        {
            view.Print("Список команд:");
            foreach (var command in UICommands.listCommands)
                view.Print($"{command.Key}\t-\t{command.Value}");
        }

        internal void ShowSpecies()
        {
            view.Print($"Введите вид животного:\n" +
                   $" Cat,\n Dog,\n Humster,\n Horse, \n Camel,\n Donkey");
        }

        internal string GetSpecies()
        {
            bool work;
            string result;

            do
            {
                ShowSpecies();
                result = view.GetString();
                work = Animals.pets.ContainsKey(result.ToLower().Trim())
                    || Animals.packedAnimals.ContainsKey(result.ToLower().Trim());
                if (!work) view.Print("Необходимо ввести вид животного из списка");
                else break;
            }
            while (!work);
            return result;
        }

        private void AddToPetDict(string species, Animals animal)
        {

            if (!Animals.pets.ContainsKey(animal.Specias))
            {
                var list = new List<Animals>();
                list.Add(animal);
                Animals.pets.Add(animal.Specias, list);
            }
            else if (Animals.pets.TryGetValue(species, out List<Animals> result))
            {
                var list = result;
                list.Add(animal);
            }
            AddSuccess(animal);
        }
        private void AddToPackAnimalsDict(string species, Animals animal)
        {
            if (!Animals.packedAnimals.ContainsKey(animal.Specias))
            {
                var list = new List<Animals>();
                list.Add(animal);
                Animals.packedAnimals.Add(animal.Specias, list);
            }
            else if (Animals.packedAnimals.TryGetValue(species, out List<Animals> result))
            {
                var list = result;
                list.Add(animal);
            }
            AddSuccess(animal);
        }

        private void AddSuccess(Animals animal)
        {
            view.Print($"Животное {animal.Name} вида {animal.Specias} успешно добавлено");
        }

        internal void PrintCount()
        {
            view.Print($"Всего животных в питомнике: {Animals.counter}");
        }
    }
}