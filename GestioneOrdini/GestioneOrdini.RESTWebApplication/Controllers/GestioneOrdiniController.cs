using GestioneOrdini.Entities;
using GestioneOrdini.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestioneOrdini.RESTWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestioneOrdiniController : ControllerBase
    {
        //Collego il repository
        private readonly IRepositoryOrdine repo;
        public GestioneOrdiniController(IRepositoryOrdine service)
        {
            this.repo = service;
        }

        //Get all
        [HttpGet]
        public ActionResult<List<Ordine>> GetOrdini()
        {
            return Ok(repo.GetAll());
        }

        //Get by id
        [HttpGet("{id}")]
        public ActionResult<Ordine> GetOrdine(int id)
        {
            Ordine ordine = repo.GetByID(id);
            if (ordine == null)
                return NotFound();
            return Ok(ordine);
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool risultato = repo.Delete(id);
            if (risultato)
                return Ok();
            return NotFound();
        }

        //Create
        [HttpPost]
        public ActionResult Crea([FromBody] Ordine ordine)
        {
            if (ordine == null)
                return BadRequest();

            bool creato = repo.Create(ordine);
            if (creato)
                return Created($"{HttpContext.Request.Path}/{ordine.ID}", ordine);
            return BadRequest();
        }

        //Update
        [HttpPut]
        public ActionResult Update([FromBody] Ordine ordine, int id)
        {
            Ordine ordine1 = repo.GetByID(id);
            ordine1.CodiceOrdine = ordine.CodiceOrdine;
            ordine1.CodiceProdotto = ordine.CodiceProdotto;
            ordine1.DataOrdine = ordine.DataOrdine;
            ordine1.Importo = ordine.Importo;
            ordine1.Cliente = ordine.Cliente;
            bool aggiornato = repo.Update(ordine1);
            if (aggiornato)
                return Ok();
            return BadRequest();
        }
    }
}
