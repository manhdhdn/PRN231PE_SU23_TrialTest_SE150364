using BusinessObjects.Entities;

namespace DataAccess.Repositories
{
    public interface IPetShopMemberRepository
    {
        public PetShopMember? FindMember(string email, string password);
    }
}
