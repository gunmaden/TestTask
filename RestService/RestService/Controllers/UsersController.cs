using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.EntityModels;
using Models.RequestModels;
using Models.Validators;

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST api/users
        [HttpPost]
        public async Task<Page<User>> GetFilteredUsers([FromBody] RequestUsersModel request)
        {
            return await _userRepository.GetUsers(request);
        }

        //PUT api/users
        [HttpPut]
        public async Task<ActionResult<ResponseModel<User>>> PutUser([FromBody] CreationUserModel request)
        {
            ResponseModel<User> result;
            var validator = new UserCreateValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                result = new ResponseModel<User>
                {
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
                    IsSuccess = false,
                    Result = null
                };
                return BadRequest(result);
            }

            try
            {
                result = new ResponseModel<User>
                {
                    Errors = null,
                    IsSuccess = true,
                    Result = await _userRepository.PutUser(request)
                };
            }
            catch (ValidationException e)
            {
                Console.WriteLine(e);
                result = new ResponseModel<User>
                {
                    Errors = new List<string> {e.Message},
                    IsSuccess = false,
                    Result = null
                };
                return BadRequest(result);
            }

            return result;
        }

        //DELETE api/users/{ID}
        [HttpDelete("{userId}")]
        public async Task<ActionResult<ResponseModel<object>>> DeleteUser(Guid userId)
        {
            ResponseModel<object> result;
            try
            {
                var deletedUser = await _userRepository.Delete(userId);
                result = new ResponseModel<object>
                {
                    IsSuccess = deletedUser != 0,
                    Result = null
                };
            }
            catch (ValidationException e)
            {
                Console.WriteLine(e);
                result = new ResponseModel<object>
                {
                    IsSuccess = false,
                    Errors = new List<string> {e.Message}
                };
                return BadRequest(result);
            }

            return result;
        }
    }
}