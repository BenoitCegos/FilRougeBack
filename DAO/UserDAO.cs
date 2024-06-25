using FilRouge.Models;
using Microsoft.EntityFrameworkCore;

namespace FilRouge.DAO
{
    public class UserDAO
    {
        private readonly FilRougeContext _DB;

        public UserDAO(FilRougeContext context)
        {
            _DB = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _DB.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _DB.Users.FindAsync(id);
        }

        //AJOUT
        public async Task<User> AddUser(User User)
        {
            _DB.Users.Add(User);
            await _DB.SaveChangesAsync();
            return User;
        }

        //Mise à jour
        public async Task<User> UpdateUser(User User)
        {
            _DB.Entry(User).State = EntityState.Modified;
            await _DB.SaveChangesAsync();
            return User;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var User = await _DB.Users.FindAsync(id);
            if (User == null) return false;

            _DB.Users.Remove(User);
            await _DB.SaveChangesAsync();
            return true;
        }
    }
}