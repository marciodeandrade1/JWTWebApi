﻿using JWTWebApi.Models;

namespace JWTWebApi.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User> {
            new User {
                Id = 1, FirstName = "mytest",Role= new List<Role>{Role.Customer}, LastName = "User", Username = "mytestuser", Password = "test123"
            },
            new User {
                Id = 2, FirstName = "mytest2", LastName = "User2", Username = "test", Password = "test"
            }
        };

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);

        }
    }
}
