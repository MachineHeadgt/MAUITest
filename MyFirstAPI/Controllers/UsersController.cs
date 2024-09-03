using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.OpenApi.Validations;
using MyFirstAPI.Data;
using MyFirstAPI.Services.UsersServices;
using System.Collections.Generic;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _IUserService;

        public UsersController(IUserService IUserService)
        {
           _IUserService = IUserService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var Result = await _IUserService.GetAllUsers();
            if (Result == null)
            {
                return BadRequest("ERROR: could not get all Users");
            }
            
            return Ok(Result);
        }


        [HttpGet("{UserId}")]
        public async Task<ActionResult<User>> GetUser(Int64 UserId)
        {
            var Result = await _IUserService.GetUser(UserId);
            if (Result == null)
            {
                return BadRequest("ERROR: coudn't get User");
            }

            return Ok(Result);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User User)
        {
            var Result = await _IUserService.AddUser(User);
            if (Result.ToString().StartsWith("ERROR"))
            {
                return BadRequest("ERROR: coudn't add user :" +  Result.ToString());
            }

            return Ok(Result);
        }


        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User UpdateDataUser)
        {
            var Result = await _IUserService.UpdateUser(UpdateDataUser);
            if (Result.ToString().StartsWith("ERROR"))
            {
                return BadRequest("ERROR: coudn't Update user :" + Result.ToString());
            }

            return Ok(Result);


        }

        [HttpDelete("{UserId}")]
        public async Task<ActionResult<User>> DeleteUser(Int64 UserId)
        {
            var Result = await _IUserService.DeleteUser(UserId);
            if (Result.ToString().StartsWith("ERROR"))
            {
                return BadRequest("ERROR: coudn't Update user :" + Result.ToString());
            }

            return Ok(Result);


        }


    }
}
