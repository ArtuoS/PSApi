using Microsoft.AspNetCore.Mvc;
using PremierAPI.Models;
using System.Threading.Tasks;
using PremierAPI.Repository.Interfaces;

namespace PremierAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/users/")]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            var response = _userRepository.Create(user);
            return StatusCode(200);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var response = _userRepository.GetById(id);
            return new JsonResult(response);
        }

        [HttpGet]
        [Route("api/users/")]
        public async Task<ActionResult> Get()
        {
            var response = _userRepository.GetAll();
            return new JsonResult(response);
        }

        [HttpPut]
        [Route("api/users/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] string nome)
        {
            var user = _userRepository.GetById(id);
            user.Nome = nome;
            var response = _userRepository.Update(user);
            return StatusCode(200);
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = _userRepository.Delete(id);
            return new JsonResult(response);
        }
    }
}
