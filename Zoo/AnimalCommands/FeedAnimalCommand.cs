using Zoo.AnimalRepositories;

namespace Zoo.AnimalCommands
{
    class FeedAnimalCommand : ICommand
    {
        IAnimalRepository animals;
        string name;

        public FeedAnimalCommand(IAnimalRepository animals, string name)
        {
            this.animals = animals;
            this.name = name;
        }
        public bool Execute()
        {
            return animals.FeedAnimal(name);
        }
    }
}
