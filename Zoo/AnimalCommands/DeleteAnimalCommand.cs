using Zoo.AnimalRepositories;

namespace Zoo.AnimalCommands
{
    class DeleteAnimalCommand : ICommand
    {
        IAnimalRepository animals;
        string name;

        public DeleteAnimalCommand(IAnimalRepository animals, string name)
        {
            this.animals = animals;
            this.name = name;
        }
        public bool Execute()
        {
            return animals.DeleteAnimal(name);
        }
    }
}
