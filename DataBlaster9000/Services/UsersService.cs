using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataBlaster9000.Models;
using DataBlaster9000.Repositories;

namespace DataBlaster9000.Services
{
    public class UsersService
    {
        private readonly UserRepository _userRepo;

        public UsersService()
        {
            _userRepo = new UserRepository();
        }

        public IEnumerable<UserDataModel> GetAllUsers()
        {
            return _userRepo.All();
        }

        public void Add(UserDataModel user)
        {
            _userRepo.Add(user);
        }

        public void Update(UserDataModel user)
        {
            _userRepo.Update(user);
        }

        public void Delete(UserDataModel user)
        {
            _userRepo.Delete(user);
        }

        public UserDataModel FindById(String id)
        {
            var users = _userRepo.All();
            return users.First(u => u.Id.ToString() == id);
        }

        public IEnumerable<UserDataModel> FindByLastName(String lastName)
        {
            var users = _userRepo.All();
            return users.Where(u => u.LastName.ToLower() == lastName.ToLower());
        }

        public IEnumerable<UserDataModel> FindWithinAgeRange(int minAge, int maxAge)
        {
            var users = _userRepo.All();
            return users.Where(u => u.Age >= minAge && u.Age <= maxAge);
        }
    }
}