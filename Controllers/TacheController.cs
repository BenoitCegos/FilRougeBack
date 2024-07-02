using FilRouge.DAO;
using FilRouge.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.Controllers
{
    public class TacheController : Controller
    {

        private readonly TacheDAO _DAO;

        public TacheController(TacheDAO dao)
        {
            _DAO = dao;
        }



        [HttpGet("Taches")]
        public async Task<ActionResult<IEnumerable<Tache>>> GetTaches()
        {
            var reponse = await _DAO.GetTaches();
            return Ok(reponse);
        }

        [HttpGet("Taches/{id}")]
        public async Task<ActionResult<Tache>> GetTache(int id)
        {
            var Tache = await _DAO.GetTache(id);
            return Ok(Tache);

        }
        //Ajout 
        [HttpPost("Taches")]
        public async Task<ActionResult<Tache>> PostTache([FromBody] Tache Tache)
        {
            await _DAO.AddTache(Tache);
            return CreatedAtAction("GetTache", new { id = Tache.Id }, Tache);
        }

        //Mise à jour
        [HttpPut("Taches/{id}")]
        public IActionResult PutTache(int id, [FromBody] Tache Tache)
        {
            if (Tache == null)
            {
                return BadRequest("Projet is null");
            }
            Tache? toUpdate = _DAO.GetTache(id).Result;

            if (toUpdate == null)
            {
                return NotFound();
            }
            toUpdate.Nom = Tache.Nom;
            toUpdate.Description = Tache.Description;
            
            _DAO.UpdateTache(toUpdate);

            return NoContent();
        }

        [HttpDelete("Taches/{id}")]
        public async Task<IActionResult> DeleteTache(int id)
        {
            var success = await _DAO.DeleteTache(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("Taches/GetTachesListes/{id}")]
        public async Task<ActionResult<IEnumerable<Tache>>> GetTachesListes(int id)
        {
            var maReponse = await _DAO.GetTachesListes(id);
            if (maReponse == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(maReponse);
            }
        }
    }
}