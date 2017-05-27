using System;
using System.Threading;
using System.Threading.Tasks;
using Zoo.AnimalCommands;
using Zoo.AnimalRepositories;
using Zoo.Animals;

namespace Zoo
{
    static class Manager
    {
        static AnimalRepository animals;
        static int maxNumberOfAction;
        static int minNumberOfAction;

        static Manager()
        {
            animals = new AnimalRepository();
            maxNumberOfAction = 6;
            minNumberOfAction = 1;
        }
        static void MoveTime()
        {
            ICommand command = new MoveTimeCommand(animals);
            while (true)
            {
                Thread.Sleep(5000);
                Console.WriteLine(DateTime.Now);
                command.Execute();
            }
        }
        static void StartMoveTime(IAnimalRepository animals)
        {
            Task.Run(new Action(MoveTime));
        }

        static string GetValue()
        {
            bool exit = false;
            string name = "";
            while (!exit)
            {
                name = Console.ReadLine();
                if (name != "") exit = true;
            }
            return name;
        }
        static void ShowProperties()
        {
            Console.WriteLine("Choose action:");
            Console.WriteLine("1) Add animal");
            Console.WriteLine("2) Feed animal");
            Console.WriteLine("3) Cure animal");
            Console.WriteLine("4) Delete animal");
            Console.WriteLine("5) Exit");
        }
        static int GetNumberOfAction()
        {
            bool exit = false;
            int id = 0;
            while (!exit)
            {
                if (Int32.TryParse(Console.ReadLine(), out id)
                    && id >= minNumberOfAction
                    && id <= maxNumberOfAction)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Error");
                }
                
            }
            return id;
        }
        static ICommand GetCommand(int id, string name, string type)
        {
            ICommand command;
            switch (id)
            {
                case 1: command = new AddAnimalCommand(animals, name, type); break;
                case 2: command = new FeedAnimalCommand(animals, name); break;
                case 3: command = new CureAnimalCommand(animals, name); break;
                case 4: command = new DeleteAnimalCommand(animals, name); break;
                default: command = null; break;
            }
            return command;
        }
        static void DisplayAnimal(Animal animal)
        {
            Console.WriteLine("_______________________________");
            Console.WriteLine(animal.Type + " " + animal.Name);
            Console.WriteLine("Health: " + animal.Health);
            Console.WriteLine("State: " + animal.State);
            Console.WriteLine("_______________________________");
        }
        static void Main()
        {
            StartMoveTime(animals);
            bool exit = false;
            while (!exit)
            {
                ShowProperties();
                int id = GetNumberOfAction();
                string name = "", type = "";
                if (id == 1)
                {
                    Console.WriteLine("Input name:");
                    name = GetValue();
                    Console.WriteLine("Input type:");
                    type = GetValue();
                    if (new AddAnimalCommand(animals, name, type).Execute())
                        Console.WriteLine("Operation seccessful");
                    else Console.WriteLine("Error");
                }
                else if (id == 6) exit = true;
                else if (id == 5)
                {

                }
                else
                {
                    Console.WriteLine("Input name:");
                    name = GetValue();
                    bool op = false;
                    switch (id)
                    {
                        case 2: op = new FeedAnimalCommand(animals, name).Execute(); break;
                        case 3: op = new CureAnimalCommand(animals, name).Execute(); break;
                        case 4: op = new DeleteAnimalCommand(animals, name).Execute(); break;
                        default: break;
                    }
                    if (op) Console.WriteLine("Operation seccessful");
                    else Console.WriteLine("Error");
                }
            }
        }
    }
}
