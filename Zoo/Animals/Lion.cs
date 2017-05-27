namespace Zoo.Animals
{
    class Lion : Animal
    {
        public Lion(string name)
        {
            health = 5;
            maxHealth = health;
            state = AnimalState.Satisfied;
            base.name = name;
            type = "lion";
        }
    }
}
