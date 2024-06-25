using Microsoft.AspNetCore.Mvc;
//using FilRouge.Controllers.DAO;
using FilRouge.DAO;
using FilRouge.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FilRouge.Controllers
{
    public class FilRougeController : Controller
    {
        private readonly ListeDAO _DAO;

        public FilRougeController(ListeDAO dao)
        {
            _DAO = dao;
        }

        /*
               public <- accessibilité de la fonction
                async <- declarer la fonction comme asynchrone (elle est utiliser par un autre thread)
                Task<ActionResult<IEnumerable<Liste>>>  <- Type de la valeur de retour de la fonction
                Getlistes <- nom de la fonction
                () <- parametres
                public async Task<ActionResult<IEnumerable<Liste>>> Getlistes()
                {
                    return await _DB.listes.ToListAsync();
                }
        
                Dans le cas ou je return un object DTO*/


        /*public async Task<ActionResult<IEnumerable<ListeDTO>>> Getlistes()
        {
            var listeListe = await _DB.listes.ToListAsync();
        foreach (var Liste in _DB.listes)
        {
           listesDTO.  
        }
        return listesDTO;
        }*/

        //Dans le cas ou je recois un object DTO

        /*public async Task<ActionResult<IEnumerable<Liste>>> Getlistes()
       {
           //Liste classique = dto.toListe();
           foreach( Liste varListe in _DB.listes)
           {

           }
           ListeDTO monListe= new ListeDTO();
           return await() ;
       }*/



        [HttpGet("listes")]
        public async Task<ActionResult<IEnumerable<Liste>>> GetListes()
        {
            var reponse = await _DAO.GetListes();
            return Ok(reponse);
        }

        [HttpGet("listes/{id}")]
        public async Task<ActionResult<Liste>> GetListe(int id)
        {
            var Liste = await _DAO.GetListe(id);
            return Ok(Liste);

        }

        [HttpPost("listes")]
        public async Task<ActionResult<Liste>> PostListe(Liste Liste)
        {
            await _DAO.AddListe(Liste);
            return CreatedAtAction("GetListe", new { id = Liste.Id }, Liste);
        }

        [HttpPut("/listes/{id}")]
        public async Task<IActionResult> PutListe(int id, Liste Liste)
        {
            if (id != Liste.Id)
            {
                return BadRequest();
            }

            await _DAO.UpdateListe(Liste);

            return NoContent();
        }

        [HttpDelete("/listes/{id}")]
        public async Task<IActionResult> DeleteListe(int id)
        {
            var success = await _DAO.DeleteListe(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        //DTO Version
        /*[HttpGet("listes")]
        public async Task<ActionResult<IEnumerable<Liste>>> Getlistes()
        {
          return await _DB.listes.ToListAsync();
        }*/

        /*
        [HttpGet("list/{id}")]
        public async Task<ActionResult<Liste>> GetListe(int id)
        {
            var Liste = await _DB.listes.FindAsync(id);
            if (Liste == null)
            {
                return NotFound();
            }
            return Liste;
        }
        //Put
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("put/{id}")]
        public async Task<IActionResult> PutListe(int id, Liste Liste)
        {
            if (id != Liste.Id)
            {
                return BadRequest();
            }

            _DB.Entry(Liste).State = EntityState.Modified;

            try
            {
                await _DB.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Liste
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Liste>> PostListe(Liste Liste)
        {
            _DB.listes.Add(Liste);
            await _DB.SaveChangesAsync();

            return CreatedAtAction("GetListe", new { id = Liste.Id }, Liste);
        }

        // DELETE: api/Liste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListe(int id)
        {
            var Liste = await _DB.listes.FindAsync(id);
            if (Liste == null)
            {
                return NotFound();
            }

            _DB.listes.Remove(Liste);
            await _DB.SaveChangesAsync();

            return NoContent();
        }
        */
        /*private bool ListeExists(int id)
        {
            return _DB.listes.Any(e => e.Id == id);
        }*/
    }
}
