using AnimalManagementAPI.Model;

namespace AnimalManagementAPI.Services
{
    public class AnimalService
    {
        private readonly List<Animal> _animals;

        public AnimalService()
        {
            _animals = new List<Animal>();
        }

        public List<Animal> GetAllAnimals()
        {
            return _animals;
        }

        public Animal GetAnimalById(string name)
        {
            return _animals.FirstOrDefault(a => a.Name == name);
        }

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public bool DeleteAnimal(string name)
        {
            var animalToRemove = _animals.FirstOrDefault(a => a.Name == name);
            if (animalToRemove != null)
            {
                _animals.Remove(animalToRemove);
                return true;
            }
            return false;
        }
    }
}
