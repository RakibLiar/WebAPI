using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userNamager;

        public UserProfileController(UserManager<ApplicationUser> userNamager)
        {
            _userNamager = userNamager;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userNamager.FindByIdAsync(userId);
            return new
            {
                user.Email,
                user.UserName
            };
        }
    }
}
