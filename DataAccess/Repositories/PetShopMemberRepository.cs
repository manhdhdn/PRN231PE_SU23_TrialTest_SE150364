using BusinessObjects.Entities;
using DataAccess.DAO;

namespace DataAccess.Repositories
{
    public class PetShopMemberRepository : IPetShopMemberRepository
    {
        public PetShopMember? FindMember(string email, string password) => PetShopMemberDAO.FindPetShopMember(email, password);
    }
}
