namespace Zoo.Animals
{
    class Tiger : Animal
    {
        public Tiger(string name)
        {
            health = 4;
            maxHealth = health;
            state = AnimalState.Satisfied;
            base.name = name;
            type = "tiger";
        }
    }
}