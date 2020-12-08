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
    public class TipoDePetController : ControllerBase
    {


        TipoDePetRepository repo = new TipoDePetRepository();
        // GET: api/<TipoDePetController>
        [HttpGet]
        public List<TipoDePet> Get()
        {
            return repo.LerTodos();
        }

        // GET api/<TipoDePetController>/5
        [HttpGet("{id}")]
        public TipoDePet Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST api/<TipoDePetController>
        [HttpPost]
        public TipoDePet Post([FromBody] TipoDePet novoTipoDePet)
        {
            return repo.Registrar(novoTipoDePet);
        }

        // PUT api/<TipoDePetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipoDePetController>/5
        [HttpDelete("{id}")]
        public TipoDePet Delete([FromBody] TipoDePet delTipoDePet)
        {
            return repo.Excluir(delTipoDePet);
        }
    }
}
