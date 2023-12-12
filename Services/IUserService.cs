using JWTWebApi.Models;

namespace JWTWebApi.Services
{
    public interface IUserService
    {
            User GetById(int id);
            IEnumerable<User> GetAll();
    }
}