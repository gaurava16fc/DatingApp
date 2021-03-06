using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    // public interface IDatingRepository<T> where T: class
    // {
    //      void Add(T entity);
    //      void Delete(T entity);
    //      Task<bool> SaveAll();
    //      Task<IEnumerable<T>> GetAll();
    //      Task<T> GetById();         
    // }

    public interface IDatingRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);         
    }
}