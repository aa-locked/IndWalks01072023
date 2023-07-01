using IndWalks.API.Model.DTO;
using IndWalks.API.Repository.UserAUth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IndWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserAuthJwtRepository _userAuthJwtRepository;

        public UserAuthController(UserManager<IdentityUser> userManager, IUserAuthJwtRepository userAuthJwtRepository)
        {
            _userManager = userManager;
            _userAuthJwtRepository = userAuthJwtRepository;
        }

        // api/UserAuth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDTO.Password);
            if (identityResult.Succeeded)
            {
                //Add roles to the user
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User Registered! Please Login.");
                    }
                }
            }
            return BadRequest("Something Went Wrong!");
        }

        // /api/UserAuth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDTO.UserName);
            if (user != null)
            {
                var checkPasswordresult = _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (checkPasswordresult != null)
                {
                    //Get Roles

                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwttoken = _userAuthJwtRepository.CreateJWTToken(user, roles.ToList());
                        //var response = new LoginResponseDTO
                        //{
                        //    JwtToken = jwttoken,
                        //};
                        //return Ok(response);
                        return Ok(jwttoken.ToString());
                    }

                }
            }
            return BadRequest("Username Or Password is Incorrect!");
        }
    }
}
