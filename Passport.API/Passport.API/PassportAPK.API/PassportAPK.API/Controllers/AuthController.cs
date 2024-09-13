using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;
using System.Data;

namespace PassportAPK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTTokenService _jWTTokenService;
        public AuthController(UserManager<ApplicationUser> userManager, IJWTTokenService jWTTokenService, SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _jWTTokenService = jWTTokenService;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var user = new ApplicationUser { UserName = $"{registerUserDTO.FirstName}{registerUserDTO.LastName}", Email = registerUserDTO.EmailAddress, PhoneNumber = registerUserDTO.PhoneNumber , LoginId = registerUserDTO.LoginId, FirstName = registerUserDTO.FirstName, LastName = registerUserDTO.LastName};
            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user,"User");
                User newUser = new User
                {
                    FirstName = registerUserDTO.FirstName,
                    LastName = registerUserDTO.LastName,
                    EmailAddress = registerUserDTO.EmailAddress,
                    LoginId = registerUserDTO.LoginId,
                    Password = registerUserDTO.Password,
                    PhoneNumber = registerUserDTO.PhoneNumber,
                    DateOfBirth = registerUserDTO.DateOfBirth
                };
                await _unitOfWork.UserRepository.AddAsync(newUser);
                return Ok(new { Message = $"User {user.UserName} Register Successful." });
            }
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.Users.FirstOrDefaultAsync(id => id.LoginId == loginDTO.LoginId);
            var validUser = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!validUser.Succeeded)
            {
                return Unauthorized("Login Id not found and/or password incorrect");
            }
            else
            {
                var getUser = _unitOfWork.UserRepository.GetByLoginId(loginDTO.LoginId);
                var userRoles = await _userManager.GetRolesAsync(user);
                LoggedInUserDTO loggedIn = new LoggedInUserDTO
                {
                    UserId = getUser.Result.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.Email,
                    LoginId = user.LoginId,
                    Token = await _jWTTokenService.GenerateToken(user),
                    UserRoles = userRoles.FirstOrDefault()
                };
                return Ok(loggedIn);
            }
        }

        [HttpGet]
        [Route("CheckLoginIdExist")]
        public async Task<IActionResult> CheckLoginIdExist(string loginId)
        {
            var LoginIdExist = await _userManager.Users.FirstOrDefaultAsync(id => id.LoginId == loginId);
            return Ok(LoginIdExist != null);
        }
    }
}
