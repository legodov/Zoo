using Zoo.Animals;

namespace Zoo
{
    static class AnimalFactory
    {
        public static Animal CreateLion(string name)
        {
            return new Lion(name);
        }
        public static Animal CreateTiger(string name)
        {
            return new Tiger(name);
        }
        public static Animal CreateElephant(string name)
        {
            return new Elephant(name);
        }
        public static Animal CreateBear(string name)
        {
            return new Bear(name);
        }
        public static Animal CreateWolf(string name)
        {
            return new Wolf(name);
        }
        public static Animal CreateFox(string name)
        {
            return new Fox(name);
        }
    }
}
