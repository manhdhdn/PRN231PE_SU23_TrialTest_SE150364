using BusinessObjects.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace PetStore2023API.Controllers
{
    public class PetsController : ODataController
    {
        private readonly IPetRepository repository = new PetRepository();

        // GET /OData/Pets
        [Authorize(Roles = "Staff")]
        [EnableQuery]
        public IQueryable<Pet> Get() => repository.GetPets().AsQueryable();

        // GET /OData/Pets(5)
        [Authorize(Roles = "Member")]
        [EnableQuery]
        public SingleResult<Pet> Get([FromRoute] int key) => SingleResult.Create(new[] { repository.GetPet(key) }.AsQueryable());

        // POST /OData/Pets
        public IActionResult Post([FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.PostPet(pet);

            return Created(pet);
        }

        // PUT /OData/Pets(5)
        public IActionResult Put([FromRoute] int key, [FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != pet.PetId)
            {
                return BadRequest();
            }

            var oldPet = repository.GetPet(key);

            if (oldPet == null)
            {
                return NotFound();
            }

            repository.PutPet(pet);

            return Updated(pet);
        }

        // PATCH /OData/Pets(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IActionResult Patch([FromRoute] int key, Delta<Pet> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pet = repository.GetPet(key);

            if (pet == null)
            {
                return NotFound();
            }

            delta.Patch(pet);

            repository.PutPet(pet);

            return Updated(pet);
        }

        // DELETE /OData/Pets(5)
        public IActionResult Delete([FromRoute] int key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pet = repository.GetPet(key);

            if (pet == null)
            {
                return NotFound();
            }

            repository.DeletePet(pet);

            return NoContent();
        }
    }
}
