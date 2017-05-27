namespace Zoo.Animals
{
    class Elephant : Animal
    {
        public Elephant(string name)
        {
            health = 7;
            maxHealth = health;
            state = AnimalState.Satisfied;
            base.name = name;
            type = "elephant";
        }
    }
}

