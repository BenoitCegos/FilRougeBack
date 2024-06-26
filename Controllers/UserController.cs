﻿using FilRouge.DAO;
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



        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var reponse = await _DAO.GetUsers();
            return Ok(reponse);
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _DAO.GetUser(id);
            return Ok(User);

        }
        //Ajout 
        [HttpPost("users")]
        public async Task<ActionResult<User>> PostUser([FromBody] User User)
        {
            await _DAO.AddUser(User);
            return CreatedAtAction("GetUser", new { id = User.Id }, User);
        }

        //Mise à jour
        [HttpPut("users/{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] User User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }

            await _DAO.UpdateUser(User);

            return NoContent();
        }

        [HttpDelete("users/{id}")]
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