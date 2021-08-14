using Microsoft.AspNetCore.Mvc;
using PremierAPI.Models;
using PremierAPI.Repository.Interfaces;
using System.Linq;
using PremierAPI.Views;
using AutoMapper;

namespace PremierAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create an User
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/users/")]
        public ActionResult Create([FromBody] UserViewModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var response = _userRepository.Create(user);
            if (response != null)
                return new JsonResult(response);
            return StatusCode(404);
        }

        /// <summary>
        /// Get a specific User from PremierSoft Api by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/users/{id}")]
        public ActionResult Get(int id)
        {
            var response = _userRepository.GetById(id);
            if (response == null)
                return NotFound();
            return new JsonResult(response);
        }

        /// <summary>
        /// Get all Users from PremierSoft Api
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/users/")]
        public ActionResult Get()
        {
            var response = _userRepository.GetAll();
            if (!response.Any())
                return NotFound();
            return new JsonResult(response);
        }

        /// <summary>
        /// Update the name of an User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/users/{id}")]
        public ActionResult Update(int id, [FromBody] string nome)
        {
            var user = _userRepository.GetById(id);

            if (user != null && nome != null)
            {
                user.UpdatePropertiesByNewUser(new User() { nome = nome });
                var response = _userRepository.Update(user);

                if (response != null)
                    return new JsonResult(response);
            }

            return StatusCode(404);
        }

        /// <summary>
        /// Delete an User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/users/{id}")]
        public ActionResult Delete(int id)
        {
            var response = _userRepository.Delete(id);
            if (response != null)
                return new JsonResult(response);
            return StatusCode(404);
        }
    }
}
