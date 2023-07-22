namespace PetStore2023API.Utils
{
    public interface IAccountRepo
    {
        public string? GenerateJwtToken(string email, string roleName);
    }
}
