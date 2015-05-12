using System;
using System.Collections.Generic;
using System.Linq;
using DataBlaster9000.Models;
using DataBlaster9000.Repositories.DataContexts;
using DataBlaster9000.Repositories.Interfaces;

namespace DataBlaster9000.Repositories
{
    public class UserRepository : FileDataContext, IDataRepository<UserDataModel>
    {
        private List<UserDataModel> _users;
        private FileDataModel _file;

        public UserRepository()
        {
            _file = new FileDataModel
            {
                Lines = new List<string>(),
                Uid = new Guid("14a149a8-1486-4f1d-9cb9-a9fc3f3cfea7")
            };

            _users = LoadFile(_file).Lines.Select(s => new UserDataModel(s)).ToList();
        }

        public void Add(UserDataModel user)
        {
            if (user.Id < 1)
            {
                user.Id = _users.Max(u => u.Id) + 1;
                _users.Add(user);
                ReplaceAllLines(_users.Select(u => u.CsvRow).ToList(), _file);
            }
        }

        public void Delete(UserDataModel user)
        {
            var keepUsers = _users.Where(u => u.Id != user.Id);
            ReplaceAllLines(keepUsers.Select(u => u.CsvRow), _file);
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

            ReplaceAllLines(_users.Select(u => u.CsvRow), _file);
        }

        public IEnumerable<UserDataModel> All()
        {
            return _users;
        }
    }
}