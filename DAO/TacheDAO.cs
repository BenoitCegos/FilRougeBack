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
        public async Task<Tache> UpdateTache(Tache Tache)
        {
            _DB.Entry(Tache).State = EntityState.Modified;
            await _DB.SaveChangesAsync();
            return Tache;
        }

        public async Task<bool> DeleteTache(int id)
        {
            var Tache = await _DB.Taches.FindAsync(id);
            if (Tache == null) return false;

            _DB.Taches.Remove(Tache);
            await _DB.SaveChangesAsync();
            return true;
        }
    }
}