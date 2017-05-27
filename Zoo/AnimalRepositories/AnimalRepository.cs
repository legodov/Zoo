using System;
using System.Collections.Generic;
using Zoo.Animals;
using System.Linq;

namespace Zoo.AnimalRepositories
{
    class AnimalRepository : IAnimalRepository
    {
        List<Animal> animals;
        int countOfDead;

        public AnimalRepository()
        {
            animals = new List<Animal>();
            countOfDead = 0;
        }
        public bool AddAnimal(string name, string type)
        {
            bool exists = animals.FirstOrDefault(a => a.Name == name) != null;
            if (!exists)
            {
                Animal newAnimal = CreateAnimal(name, type);
                if (newAnimal != null)
                {
                    animals.Add(newAnimal);
                    return true;
                }
                else return false;
            }
            else return false;
        }
        private Animal CreateAnimal(string name, string type)
        {
            Animal newAnimal;
            switch (type)
            {
                case "lion": newAnimal = AnimalFactory.CreateLion(name); break;
                case "tiger": newAnimal = AnimalFactory.CreateTiger(name); break;
                case "elephant": newAnimal = AnimalFactory.CreateElephant(name); break;
                case "bear": newAnimal = AnimalFactory.CreateBear(name); break;
                case "wolf": newAnimal = AnimalFactory.CreateWolf(name); break;
                case "fox": newAnimal = AnimalFactory.CreateFox(name); break;
                default: newAnimal = null; break;
            }
            return newAnimal;
        }
        public bool FeedAnimal(string name)
        {
            Animal animal = animals.FirstOrDefault(a => a.Name == name);
            if (animal != null && animal.State != AnimalState.Dead)
            {
                if (animal.State == AnimalState.Hungry)
                    animal.State = AnimalState.Satisfied;
                return true;
            }
            else return false;
        }
        public bool CureAnimal(string name)
        {
            Animal animal = animals.FirstOrDefault(a => a.Name == name);
            if (animal != null && animal.State != AnimalState.Dead)
            {
                ++animal.Health;
                return true;
            }
            else return false;
        }
        public bool DeleteAnimal(string name)
        {
            Animal animal = animals.FirstOrDefault(a => a.Name == name);
            if (animal != null && animal.State == AnimalState.Dead)
            {
                animals.Remove(animal);
                --countOfDead;
                return true;
            }
            else return false;
        }
        private Animal GetRandomAnimal()
        {
            Animal randAnimal = null;
            if (animals.Count > 0)
            {
                int randValue = (new Random().Next()) % animals.Count;
                return animals[randValue];
            }
            else return randAnimal;
        }
        public bool MoveTime()
        {
            Animal animal = GetRandomAnimal();
            if (animal != null && animal.State != AnimalState.Dead)
            {
                if (animal.State == AnimalState.Ill)
                {
                    --animal.Health;
                    if (animal.Health == 0)
                    {
                        animal.State = AnimalState.Dead;
                        ++countOfDead;
                    }
                }
                else if (animal.State == AnimalState.Satisfied)
                    animal.State = AnimalState.Hungry;
                else animal.State = AnimalState.Ill;
                return true;
            }
            else return false;
        }
        public bool IsAllDead()
        {
            return countOfDead == animals.Count;
        }

        public IEnumerable<IGrouping<string, Animal>> GetGroupsOfAllAnimalsByType()
        {
            return from animal in animals
                   group animal by animal.Type;

            //return animals.GroupBy(animal => animal.Type);
        }
        public IEnumerable<Animal> GetAnimalsWithState(AnimalState state)
        {
            return from animal in animals
                   where animal.State == state
                   select animal;

            //return animals.Where(animal => animal.State == state);
        }
        public IEnumerable<Animal> GetIllTigers()
        {
            return from animal in animals
                   where animal.Type == "tiger" && 
                         animal.State == AnimalState.Ill
                   select animal;

            //return animals.Where(animal => animal.Type == "tiger" && 
            //                               animal.State == AnimalState.Ill);
        }
        public Animal GetElephantWithName(string name)
        {
            var elephants = from animal in animals
                            where animal.Type == "elephant" && 
                                  animal.Name == name
                            select animal;
            return elephants.FirstOrDefault();

            //return animals.Where(animal => animal.Type == "elephant" &&
            //                               animal.Name == name)
            //              .FirstOrDefault();
        }
        public IEnumerable<string> GetNamesOfHugryAnimals()
        {
            return from animal in animals
                   where animal.State == AnimalState.Hungry
                   select animal.Name;

            //return animals.Where(animal => animal.State == AnimalState.Hungry)
            //              .Select(animal => animal.Name);
        }
        public IEnumerable<Animal> GetHealthiestAnimalsOfEachTypes()
        {
            return animals.GroupBy(animal => animal.Type)
                          .Select(animalGroup => animalGroup.Where(animal => animal.Health == animalGroup.Max(animal1 => animal1.Health))
                                                            .FirstOrDefault());
        }
        public IDictionary<string, int> GetCountOfDeadAnimalsOfEachTypes()
        {
            return animals.GroupBy(animal => animal.Type)
                          .Select(animalGroup => new KeyValuePair<string, int>(animalGroup.Key, animalGroup.Count(animal => animal.State == AnimalState.Dead)))
                          .ToDictionary(f => f.Key, s => s.Value);
        }
        public IEnumerable<Animal> GetWolfsAndBearsWithHealthMore3()
        {
            return from animal in animals
                   where (animal.Type == "wolf" || animal.Type == "bear") && 
                         animal.Health > 3
                   select animal;

            //return animals.Where(animal => (animal.Type == "bear" || animal.Type == "wolf") 
            //                               && animal.Health > 3);
        }
        public IEnumerable<Animal> GetAnimalsWithMaxAndMinHealth()
        {
            return animals.Where(animal => animal.Health == animals.Max(animal1 => animal1.Health))
                          .Take(1)
                          .Union(animals.Where(animal => animal.Health == animals.Min(animal1 => animal1.Health))
                                        .Take(1));
        }
        public double GetAverageValueOfHealth()
        {
            return animals.Average(animal => animal.Health);
        }
    }
}
