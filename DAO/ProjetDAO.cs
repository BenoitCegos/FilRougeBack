using FilRouge.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Projet> AddProjet(Projet Projet)
        {
            _DB.Projets.Add(Projet);
            await _DB.SaveChangesAsync();
            return Projet;
        }

        public async Task<Projet> UpdateProjet(Projet Projet)
        {
            _DB.Entry(Projet).State = EntityState.Modified;
            await _DB.SaveChangesAsync();
            return Projet;
        }

        public async Task<bool> DeleteProjet(int id)
        {
            var Projet = await _DB.Projets.FindAsync(id);
            if (Projet == null) return false;

            _DB.Projets.Remove(Projet);
            await _DB.SaveChangesAsync();
            return true;
        }
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