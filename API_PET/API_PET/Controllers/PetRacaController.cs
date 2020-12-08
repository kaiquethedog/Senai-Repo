using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_PET.Domains;
using API_PET.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetRacaController : ControllerBase
    {

        PetRacaRepository repo = new PetRacaRepository();

        // GET: api/<PetRacaController>
        [HttpGet]
        public List<PetRaca> Get()
        {
            return repo.LerTodos();
        }

        // GET api/<PetRacaController>/5
        [HttpGet("{id}")]
        public PetRaca Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST api/<PetRacaController>
        [HttpPost]
        public PetRaca Post([FromBody] PetRaca novoPetRaca)
        {
            return repo.Registrar(novoPetRaca);
        }

        // PUT api/<PetRacaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetRacaController>/5
        [HttpDelete("{id}")]
        public PetRaca Delete([FromBody] PetRaca delPetRaca)
        {
            return repo.Excluir(delPetRaca);
        }
    }
}
