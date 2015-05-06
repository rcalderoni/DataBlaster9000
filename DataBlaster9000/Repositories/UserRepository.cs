using System;
using System.Collections.Generic;
using System.Linq;
using DataBlaster3000.Extensions;
using DataBlaster3000.Models;
using DataBlaster3000.Repositories.DataContexts;
using DataBlaster3000.Repositories.Interfaces;

namespace DataBlaster3000.Repositories
{
    public class UserRepository : FileDataContext, IDataRepository<UserDataModel>
    {
        private List<UserDataModel> _users; 

        public UserRepository(FileDataModel fileDataModel) : base (fileDataModel)
        {
            _users = LoadFile().Lines.Select(s => new UserDataModel(s)).ToList();
        }

        public void Add(UserDataModel user)
        {
            if (user.Id < 1)
            {
                user.Id = _users.Max(u => u.Id) + 1;
                _users.Add(user);
                ReplaceAllLines(_users.Select(u => u.CsvRow).ToList());
            }
        }

        public void Delete(UserDataModel user)
        {
            var keepUsers = _users.Where(u => u.Id != user.Id);
            ReplaceAllLines(keepUsers.Select(u => u.CsvRow));
        }

        public void Update(UserDataModel user)
        {
            var updateUser = _users.FirstOrDefault(u => u.Id == user.Id);

            if (updateUser != null && !updateUser.Equals(user))
            {
                updateUser.Age = user.Age;
                updateUser.FirstName = user.FirstName;
                updateUser.LastName = user.LastName;
            }

            ReplaceAllLines(_users.Select(u => u.CsvRow));
        }

        public IEnumerable<UserDataModel> All()
        {
            return _users;
        }
    }
}