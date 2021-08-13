using Microsoft.AspNetCore.Mvc;
using PremierAPI.Models;
using PremierAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PremierAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHelper _helper;
        private readonly IUtilities _utilities;

        public UserController(IHelper helper, IUtilities utilities)
        {
            _helper = helper;
            _utilities = utilities;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/users/{id?}")]
        public async Task<ActionResult> Get(int? id)
        {
            if (_utilities.IsIdValid(id))
            {
                User user = null;

                using (var client = _helper.Initial())
                {
                    var response = client.GetAsync($"users/{id}").Result;
                    var myContent = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(myContent);
                }
                return new JsonResult(user);
            }

            List<User> users = new();

            using (var client = _helper.Initial())
            {
                var response = client.GetAsync("users").Result;
                var myContent = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(myContent);
            }

            return new JsonResult(users);
        }
    }
}
