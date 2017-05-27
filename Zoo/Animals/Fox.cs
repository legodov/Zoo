namespace Zoo.Animals
{
    class Fox : Animal
    {
        public Fox(string name)
        {
            health = 3;
            maxHealth = health;
            state = AnimalState.Satisfied;
            base.name = name;
            type = "fox";
        }
    }
}
