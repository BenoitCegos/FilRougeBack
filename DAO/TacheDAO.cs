using FilRouge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilRouge.Controllers;

namespace FilRouge.DAO
{
    public class TacheDAO
    {
        private readonly FilRougeContext _DB;

        public TacheDAO(FilRougeContext context)
        {
            _DB = context;
        }

        public async Task<IEnumerable<Tache>> GetTaches()
        {
            return await _DB.Taches.ToListAsync();
        }

        public async Task<Tache> GetTache(int id)
        {
            return await _DB.Taches.FindAsync(id);
        }

        //AJOUT
        public async Task<Tache> AddTache(Tache Tache)
        {
            _DB.Taches.Add(Tache);
            await _DB.SaveChangesAsync();
            return Tache;
        }

        //Mise à jour
        public void UpdateTache(Tache Tache)
        {
            if (string.IsNullOrWhiteSpace(Tache.Nom))
                throw new ArgumentException("Tache name ('nom') cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(Tache.Description))
                throw new ArgumentException("Tache Description ('description') cannot be null or empty.");

            _DB.Taches.Update(Tache);
            _DB.SaveChangesAsync();
        }

        public async Task<bool> DeleteTache(int id)
        {
            var Tache = await _DB.Taches.FindAsync(id);
            if (Tache == null) return false;

            _DB.Taches.Remove(Tache);
            await _DB.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Tache>> GetTachesListes(int id)
        {

            return _DB.Taches.Where(t => t.ListeId == id).ToArray();

        }

    }
}