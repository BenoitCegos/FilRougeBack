﻿using FilRouge.DAO;
using FilRouge.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.Controllers
{
    public class CommentaireController : Controller
    {
        private readonly CommentaireDAO _DAO;

        public CommentaireController(CommentaireDAO dao)
        {
            _DAO = dao;
        }



        [HttpGet("Commentaires")]
        public async Task<ActionResult<IEnumerable<Commentaire>>> GetCommentaires()
        {
            var reponse = await _DAO.GetCommentaires();
            return Ok(reponse);
        }

        [HttpGet("Commentaires/{id}")]
        public async Task<ActionResult<Commentaire>> GetCommentaire(int id)
        {
            var Commentaire = await _DAO.GetCommentaire(id);
            return Ok(Commentaire);

        }
        //Ajout 
        [HttpPost("Commentaires")]
        public async Task<ActionResult<Commentaire>> PostCommentaire([FromBody] Commentaire Commentaire)
        {
            await _DAO.AddCommentaire(Commentaire);
            return CreatedAtAction("GetCommentaire", new { id = Commentaire.Id }, Commentaire);
        }

        //Mise à jour
        [HttpPut("Commentaires/{id}")]
        public async Task<IActionResult> PutCommentaire(int id, [FromBody] Commentaire Commentaire)
        {
            if (Commentaire == null)
            {
                return BadRequest("Projet is null");
            }
            Commentaire? toUpdate = _DAO.GetCommentaire(id).Result;
            if (toUpdate == null)
            {
                return NotFound();
            }

            toUpdate.Contenu = Commentaire.Contenu;
            _DAO.UpdateCommentaire(toUpdate);
            return Json(toUpdate);
        }

        [HttpDelete("Commentaires/{id}")]
        public async Task<IActionResult> DeleteCommentaire(int id)
        {
            var success = await _DAO.DeleteCommentaire(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("Commentaires/GetCommentsTaches/{id}")]
        public async Task<ActionResult<IEnumerable<Commentaire>>> GetCommentsTaches(int id)
        {
            var maReponse = await _DAO.GetCommentsTaches(id);
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