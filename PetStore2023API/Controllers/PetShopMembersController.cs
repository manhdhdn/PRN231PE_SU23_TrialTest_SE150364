using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using PetStore2023API.Model;
using PetStore2023API.Utils;

namespace PetStore2023API.Controllers
{
    public class PetShopMembersController : ODataController
    {
        private readonly IPetShopMemberRepository repository = new PetShopMemberRepository();
        private readonly IAccountRepo _accountRepo;

        public PetShopMembersController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        // POST /OData/SignIn
        public IActionResult Post([FromBody] SignInModel signInModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = repository.FindMember(signInModel.Email, signInModel.Password);

            if (member == null)
            {
                return Unauthorized();
            }

            var roleName = "Member";

            switch (member.MemberRole)
            {
                case 1:
                    roleName = "Administrator";
                    break;

                case 2:
                    roleName = "Staff";
                    break;

                default:
                    break;
            }

            var token = _accountRepo.GenerateJwtToken(member.EmailAddress!, roleName);

            return Ok(token);
        }
    }
}
