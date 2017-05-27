namespace Zoo.Animals
{
    abstract class Animal
    {
        protected int health;
        protected int maxHealth;
        protected AnimalState state;
        protected string name;
        protected string type;

        public int Health
        {
            get { return health; }
            set
            {
                if (value >= 0 && value <= maxHealth)
                    health = value;
            }
        }
        public int MaxHealth
        {
            get { return maxHealth; }
        }
        public AnimalState State
        {
            get { return state; }
            set { state = value; }
        }
        public string Name
        {
            get { return name; }
        }
        public string Type
        {
            get { return type; }
        }
    } 
}
