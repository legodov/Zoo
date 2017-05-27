using Zoo.AnimalRepositories;

namespace Zoo.AnimalCommands
{
    class CureAnimalCommand : ICommand
    {
        IAnimalRepository animals;
        string name;

        public CureAnimalCommand(IAnimalRepository animals, string name)
        {
            this.animals = animals;
            this.name = name;
        }
        public bool Execute()
        {
            return animals.CureAnimal(name);
        }
    }
}
