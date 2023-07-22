using BusinessObjects.Entities;
using BusinessObjects.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class PetDAO
    {
        public static List<Pet> GetPets()
        {
            var listPet = new List<Pet>();

            try
            {
                using var context = new PetShop2023DBContext();

                listPet = context.Pets.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listPet;
        }

        public static Pet FindPet(int id)
        {
            Pet pet = new();

            try
            {
                using var context = new PetShop2023DBContext();

                pet = context.Pets.Find(id)!;

                if (pet == null)
                {
                    throw new Exception("Not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pet!;
        }

        public static void SavePet(Pet pet)
        {
            try
            {
                using var context = new PetShop2023DBContext();

                context.Pets.Add(pet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdatePet(Pet pet)
        {
            try
            {
                using var context = new PetShop2023DBContext();

                context.Entry(pet).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeletePet(Pet pet)
        {
            try
            {
                using var context = new PetShop2023DBContext();
                var petInDB = FindPet(pet.PetId);

                context.Pets.Remove(petInDB);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
