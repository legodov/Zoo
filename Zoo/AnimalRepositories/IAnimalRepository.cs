namespace Zoo.AnimalRepositories
{
    interface IAnimalRepository
    {
        bool AddAnimal(string name, string type); 
        bool FeedAnimal(string name); 
        bool CureAnimal(string name); 
        bool DeleteAnimal(string name);
        bool MoveTime();
    }
}
