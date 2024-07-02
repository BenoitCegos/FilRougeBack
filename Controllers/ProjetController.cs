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
        public async Task<ActionResult<Projet>> PostProjet([FromBody] Projet Projet)
        {
            await _DAO.AddProjet(Projet);
            return CreatedAtAction("GetProjet", new { id = Projet.Id }, Projet);
        }

        //Mise à jour
        [HttpPut("projets/{id}")]
        public IActionResult PutProjet([FromBody] Projet projet, int id)
        {
            // Update projet in database
            try
            {
                if (projet == null)
                {
                    return BadRequest("Projet is null");
                }
                Projet? toUpdate = _DAO.GetProjet(id).Result;
                if (toUpdate == null)
                {
                    return NotFound();
                }
                
                toUpdate.Nom = projet.Nom;
                _DAO.UpdateProjet(toUpdate);
                return Json(toUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        

        [HttpDelete("projets/{id}")]
        public async Task<IActionResult> DeleteProjet(int id)
        {
            var success = await _DAO.DeleteProjet(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}