using FilRouge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilRouge.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FilRouge.DAO
{
    public class ProjetDAO
    {
        private readonly FilRougeContext _DB;

        public ProjetDAO(FilRougeContext context)
        {
            _DB = context;
        }

        public async Task<IEnumerable<Projet>> GetProjets()
        {
            return await _DB.Projets.ToListAsync();
        }

        public async Task<Projet> GetProjet(int id)
        {
            return await _DB.Projets.FindAsync(id);
        }

        //AJOUT
        public async Task<Projet> AddProjet(Projet Projet)
        {
            _DB.Projets.Add(Projet);
            await _DB.SaveChangesAsync();
            return Projet;
        }

        //Mise à jour
        public void UpdateProjet(Projet Projet)
        {
            if (string.IsNullOrWhiteSpace(Projet.Nom))
                throw new ArgumentException("Project name ('nom') cannot be null or empty.");

            _DB.Projets.Update(Projet);
            _DB.SaveChangesAsync();
        }

        public async Task<bool> DeleteProjet(int id)
        {
            var Projet = await _DB.Projets.FindAsync(id);
            if (Projet == null) return false;

            _DB.Projets.Remove(Projet);
            await _DB.SaveChangesAsync();
            return true;
        }
        /*public async Task<IEnumerable<Liste>> GetProjetListes(int id)
        {
            var listesParProjet = _DB.Projets.
                Where(p => p.Id == id)
                .Include(p => p.Listes)
                .FirstOrDefault();
            
            if (listesParProjet ==null)
            {
               // return NotFound
            }
            else
            {
                return await listesParProjet;
            }

        }*/
        /*public async Task<IEnumerable<Liste>> GetProjetListes(int id)
        {
            var projet = await _DB.Projets
                        .AsNoTracking()
                        .Where(p => p.Id == id)
                        .Include(p => p.Listes)
                        .FirstOrDefaultAsync();
            //FirstOrDefaultAsync au lieu de FirstOrDefault pour les requetes ASYNC
            return projet?.Listes ?? Enumerable.Empty<Liste>();
        }
        */
        /*
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(u => u.Purchases)
                                       .ThenInclude(p => p.PurchaseProjets)
                                       .ThenInclude(pa => pa.Projet)
                                       .ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.Include(u => u.Purchases)
                                       .ThenInclude(p => p.PurchaseProjets)
                                       .ThenInclude(pa => pa.Projet)
                                       .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }*/
    }
}