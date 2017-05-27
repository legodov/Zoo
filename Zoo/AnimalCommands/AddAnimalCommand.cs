using Zoo.AnimalRepositories;

namespace Zoo.AnimalCommands
{
    class AddAnimalCommand : ICommand
    {
        IAnimalRepository animals;
        string name;
        string type;

        public AddAnimalCommand(IAnimalRepository animals, string name, string type)
        {
            this.animals = animals;
            this.name = name;
            this.type = type;
        }
        public bool Execute()
        {
            return animals.AddAnimal(name, type);
        }
    }
}
