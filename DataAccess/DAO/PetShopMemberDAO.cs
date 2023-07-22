using BusinessObjects.Entities.Context;
using BusinessObjects.Entities;

namespace DataAccess.DAO
{
    public class PetShopMemberDAO
    {
        public static PetShopMember? FindPetShopMember(string email, string password)
        {
            PetShopMember? petShopMember = null;

            try
            {
                using var context = new PetShop2023DBContext();

                petShopMember = context.PetShopMembers.SingleOrDefault(m => m.EmailAddress == email && m.MemberPassword == password);

                if (petShopMember == null)
                {
                    throw new Exception("Invalid email or password!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return petShopMember;
        }
    }
}
