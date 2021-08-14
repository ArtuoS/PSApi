using Microsoft.AspNetCore.Mvc;
using PremierAPI.Models;
using System.Threading.Tasks;
using PremierAPI.Repository.Interfaces;
using System;
using PremierAPI.Models.Interfaces;
using System.Linq;
using PremierAPI.Views;
using AutoMapper;

namespace PremierAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUtilities _utilities;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IUtilities utilities, IMapper mapper)
        {
            _userRepository = userRepository;
            _utilities = utilities;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/users/")]
        public async Task<ActionResult> Create([FromBody] UserViewModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var response = _userRepository.Create(user);
            return new JsonResult(response);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var response = _userRepository.GetById(id);
            if (response == null)
                return NotFound();
            return new JsonResult(response);
        }

        [HttpGet]
        [Route("api/users/")]
        public async Task<ActionResult> Get()
        {
            var response = _userRepository.GetAll();
            if (!response.Any())
                return NotFound();
            return new JsonResult(response);
        }

        [HttpPut]
        [Route("api/users/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] string nome)
        {
            var user = _userRepository.GetById(id);

            if (_utilities.IsValidId(user.id.ToInt()))
            {
                user.UpdatePropertiesByNewUser(new User() { nome = nome });
                var response = _userRepository.Update(user);

                if (_utilities.IsValidId(response.id.ToInt()))
                {
                    return new JsonResult(response);
                }
            }

            return StatusCode(404);
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
