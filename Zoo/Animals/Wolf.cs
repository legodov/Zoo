namespace Zoo.Animals
{
    class Wolf : Animal
    {
        public Wolf(string name)
        {
            health = 4;
            maxHealth = health;
            state = AnimalState.Satisfied;
            base.name = name;
            type = "wolf";
        }
    }
}
