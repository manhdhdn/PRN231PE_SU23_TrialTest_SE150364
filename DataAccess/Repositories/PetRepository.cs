using BusinessObjects.Entities;
using DataAccess.DAO;

namespace DataAccess.Repositories
{
    public class PetRepository : IPetRepository
    {
        public List<Pet> GetPets() => PetDAO.GetPets();
        public Pet GetPet(int id) => PetDAO.FindPet(id);
        public void PutPet(Pet pet) => PetDAO.UpdatePet(pet);
        public void PostPet(Pet pet) => PetDAO.SavePet(pet);
        public void DeletePet(Pet pet) => PetDAO.DeletePet(pet);
    }
}
