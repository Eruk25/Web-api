using APILern.Application.DTO.User;
using APILern.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APILern.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Client")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDto>> GetUserProfile(int id)
        {
            var userProfile = await _userService.GetUserProfileAsync(id);

            return userProfile is null ? NotFound() : Ok(userProfile);
        }
    }
}