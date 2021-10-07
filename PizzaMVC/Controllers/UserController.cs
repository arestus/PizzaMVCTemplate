using PizzaMVC.Models;
using PizzaMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _services;

        public UserController(UserService userService)
        {
            _services = userService;
        }

       

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            var userDTO = _services.Register(user);
            if (userDTO != null)
                return await userDTO;
            return BadRequest("Not able too register");


        }
        // PUT api/<UserController>/5
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserDTO user)
        {
            var userDTO = _services.Login(user);
            if (userDTO != null)
                return Ok(userDTO);
            return BadRequest("Not able too register");

        }
    }
}
