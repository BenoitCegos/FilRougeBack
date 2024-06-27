using FilRouge.Models;
using Microsoft.EntityFrameworkCore;

namespace FilRouge.DAO
{
    public class CommentaireDAO
    {
        private readonly FilRougeContext _DB;

        public CommentaireDAO(FilRougeContext context)
        {
            _DB = context;
        }

        public async Task<IEnumerable<Commentaire>> GetCommentaires()
        {
            return await _DB.Commentaires.ToListAsync();
        }

        public async Task<Commentaire> GetCommentaire(int id)
        {
            return await _DB.Commentaires.FindAsync(id);
        }

        //AJOUT
        public async Task<Commentaire> AddCommentaire(Commentaire Commentaire)
        {
            _DB.Commentaires.Add(Commentaire);
            await _DB.SaveChangesAsync();
            return Commentaire;
        }

        //Mise à jour
        public async Task<Commentaire> UpdateCommentaire(Commentaire Commentaire)
        {
            _DB.Entry(Commentaire).State = EntityState.Modified;
            await _DB.SaveChangesAsync();
            return Commentaire;
        }

        public async Task<bool> DeleteCommentaire(int id)
        {
            var Commentaire = await _DB.Commentaires.FindAsync(id);
            if (Commentaire == null) return false;

            _DB.Commentaires.Remove(Commentaire);
            await _DB.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Commentaire>> GetCommentsTaches(int id)
        {

            return _DB.Commentaires.Where(c => c.TacheId == id).ToArray();

        }
    }
}