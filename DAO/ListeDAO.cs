using FilRouge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilRouge.Controllers;
//using FilRouge.Controllers.DAO;
//using AnguGameNew.Data;

namespace FilRouge.DAO
{
    public class ListeDAO

        {
            private readonly FilRougeContext _DB;

            public ListeDAO(FilRougeContext context)
            {
                _DB = context;
            }

            public async Task<IEnumerable<Liste>> GetListes()
            {
                return await _DB.Listes.ToListAsync();
            }

            public async Task<Liste> GetListe(int id)
            {
                return await _DB.Listes.FindAsync(id);
            }

            public async Task<Liste> AddListe(Liste Liste)
            {
                _DB.Listes.Add(Liste);
                await _DB.SaveChangesAsync();
                return Liste;
            }

            public async Task<Liste> UpdateListe(Liste Liste)
            {
                _DB.Entry(Liste).State = EntityState.Modified;
                await _DB.SaveChangesAsync();
                return Liste;
            }

            public async Task<bool> DeleteListe(int id)
            {
                var Liste = await _DB.Listes.FindAsync(id);
                if (Liste == null) return false;

                _DB.Listes.Remove(Liste);
                await _DB.SaveChangesAsync();
                return true;
            }
            /*
            public async Task<IEnumerable<User>> GetUsers()
            {
                return await _context.Users.Include(u => u.Purchases)
                                           .ThenInclude(p => p.PurchaseListes)
                                           .ThenInclude(pa => pa.Liste)
                                           .ToListAsync();
            }

            public async Task<User> GetUser(int id)
            {
                return await _context.Users.Include(u => u.Purchases)
                                           .ThenInclude(p => p.PurchaseListes)
                                           .ThenInclude(pa => pa.Liste)
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

