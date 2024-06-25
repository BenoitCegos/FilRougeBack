using FilRouge.DAO;
using FilRouge.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDAO _DAO;

        public UserController(UserDAO dao)
        {
            _DAO = dao;
        }



        [HttpGet("Users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var reponse = await _DAO.GetUsers();
            return Ok(reponse);
        }

        [HttpGet("Users/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _DAO.GetUser(id);
            return Ok(User);

        }
        //Ajout 
        [HttpPost("Users")]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            await _DAO.AddUser(User);
            return CreatedAtAction("GetUser", new { id = User.Id }, User);
        }

        //Mise à jour
        [HttpPut("/Users/{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }

            await _DAO.UpdateUser(User);

            return NoContent();
        }

        [HttpDelete("/Users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _DAO.DeleteUser(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}