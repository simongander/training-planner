using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TrainingAppBL.Interfaces;
using TrainingAppDAL.Model;

namespace TrainingAppRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("AppOrigin")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        //[HttpOptions]
        public ActionResult Authenticate()
        {
            try
            {
                var credentials = HttpContext.Request.Headers["Authorization"].ToString();
                credentials = credentials.Replace("Basic ", "");
                var token = _userRepository.Authenticate(credentials);
                var bearer = new Bearer
                {
                    Token = token
                };
                return Ok(bearer);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        //[HttpOptions]
        public ActionResult Create()
        {
            try
            {
                var credentials = HttpContext.Request.Headers["Authorization"].ToString();
                credentials = credentials.Replace("Basic ", "");
                _userRepository.CreateUser(credentials);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}