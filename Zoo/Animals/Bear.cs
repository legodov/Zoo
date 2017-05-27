namespace Zoo.Animals
{
    class Bear : Animal
    {
        public Bear(string name)
        {
            health = 6;
            maxHealth = health;
            state = AnimalState.Satisfied;
            base.name = name;
            type = "bear";
        }
    }
}
