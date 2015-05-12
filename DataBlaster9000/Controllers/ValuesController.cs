using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataBlaster9000.Models;
using DataBlaster9000.Repositories;
using DataBlaster9000.Repositories.Interfaces;
using DataBlaster9000.Services;

namespace DataBlaster9000.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly UsersService _usersService;

        public ValuesController()
        {
            _usersService = new UsersService();
        }

        // GET api/values
        public IEnumerable<UserDataModel> Get()
        {
            return _usersService.GetAllUsers();
        }

        // GET api/values/5
        public UserDataModel Get(int id)
        {
            return _usersService.FindById(id.ToString());
        }

        // POST api/values
        public void Post([FromBody]UserDataModel value)
        {
            _usersService.Add(value);
        }


        // PUT api/values
        public void Put([FromBody]UserDataModel value)
        {
            _usersService.Update(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _usersService.Delete(new UserDataModel
            {
                Id = id
            });
        }
    }
}