using Newtonsoft.Json;
using PremierAPI.Models;
using PremierAPI.Models.Interfaces;
using PremierAPI.Repository.Interfaces;
using System.Collections.Generic;
using System.Transactions;

namespace PremierAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IHelper _helper;
        private readonly IUtilities _utilities;

        public UserRepository(IHelper helper, IUtilities utilities)
        {
            _helper = helper;
            _utilities = utilities;
        }

        public User Delete(int id)
        {
            var user = this.GetById(id);

            using (var tc = new TransactionScope())
            {
                using (var client = _helper.Initial())
                {
                    _helper.ReponseDeleteAsString(client, $"users/{id}");
                }
            }


            return user;
        }

        public List<User> GetAll()
        {
            List<User> users = new();

            using (var tc = new TransactionScope())
            {
                using (var client = _helper.Initial())
                {
                    var content = _helper.ReponseReaderAsString(client, "users");
                    users = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }

            return users;
        }

        public User GetById(int id)
        {
            User user = null;

            if (_utilities.IsValidId(id))
            {
                using (var tc = new TransactionScope())
                {
                    using (var client = _helper.Initial())
                    {
                        var content = _helper.ReponseReaderAsString(client, $"users/{id}");
                        user = JsonConvert.DeserializeObject<User>(content);
                    }
                }
            }

            return user;
        }

        public User Create(User entity)
        {
            User user = new();
            using (var tc = new TransactionScope())
            {
                using (var client = _helper.Initial())
                {
                    var serializedUser = JsonConvert.SerializeObject(entity);
                    var content = _helper.ReponseCreateAsString(client, $"users", serializedUser);
                    user = JsonConvert.DeserializeObject<User>(content);
                }
            }

            return user;
        }

        public User Update(User entity)
        {
            User user = null;
            using (var tc = new TransactionScope())
            {
                using (var client = _helper.Initial())
                {
                    var serializedUser = JsonConvert.SerializeObject(entity);
                    var content = _helper.ReponseUpdateAsString(client, $"users/{entity.Id}", serializedUser);
                    user = JsonConvert.DeserializeObject<User>(content);
                }
            }

            return user;
        }
    }
}
