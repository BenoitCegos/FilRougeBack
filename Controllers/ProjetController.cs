using FilRouge.DAO;
using FilRouge.Models;
using Microsoft.AspNetCore.Mvc;
//using FilRouge.Controllers.DAO;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilRouge.Controllers
{
    public class ProjetController : Controller
    {
        private readonly ProjetDAO _DAO;

        public ProjetController(ProjetDAO dao)
        {
            _DAO = dao;
        }

        

        [HttpGet("projets")]
        public async Task<ActionResult<IEnumerable<Projet>>> GetProjets()
        {
            var reponse = await _DAO.GetProjets();
            return Ok(reponse);
        }

        [HttpGet("projets/{id}")]
        public async Task<ActionResult<Projet>> GetProjet(int id)
        {
            var Projet = await _DAO.GetProjet(id);
            return Ok(Projet);

        }
        //Ajout 
        [HttpPost("projets")]
        public async Task<ActionResult<Projet>> PostProjet(Projet Projet)
        {
            await _DAO.AddProjet(Projet);
            return CreatedAtAction("GetProjet", new { id = Projet.Id }, Projet);
        }

        //Mise à jour
        [HttpPut("/projets/{id}")]
        public async Task<IActionResult> PutProjet(int id, Projet Projet)
        {
            if (id != Projet.Id)
            {
                return BadRequest();
            }

            await _DAO.UpdateProjet(Projet);

            return NoContent();
        }

        [HttpDelete("/projets/{id}")]
        public async Task<IActionResult> DeleteProjet(int id)
        {
            var success = await _DAO.DeleteProjet(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("projetlistes/{id}")]
        public async Task<ActionResult<IEnumerable<Projet>>> GetProjetListes(int id)
        {
            var reponse = await _DAO.GetProjetListes(id);
            return Ok(reponse);
        }

    }
}