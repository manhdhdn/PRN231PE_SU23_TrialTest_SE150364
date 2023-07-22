using BusinessObjects.Entities;

namespace DataAccess.Repositories
{
    public interface IPetRepository
    {
        public List<Pet> GetPets();
        public Pet GetPet(int id);
        public void PutPet(Pet pet);
        public void PostPet(Pet pet);
        public void DeletePet(Pet pet);
    }
}
