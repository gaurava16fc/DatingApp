using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _dbContext;

        public DatingRepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var _user = await _dbContext.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return _user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var _users = await _dbContext.Users.Include(p => p.Photos).ToListAsync();
            return _users;
        }

        public async Task<bool> SaveAll()
        {
           return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}