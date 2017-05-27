using Zoo.AnimalRepositories;

namespace Zoo.AnimalCommands
{
    class MoveTimeCommand : ICommand
    {
        IAnimalRepository animals;

        public MoveTimeCommand(IAnimalRepository animals)
        {
            this.animals = animals;
        }
        public bool Execute()
        {
            return animals.MoveTime();
        }
    }
}