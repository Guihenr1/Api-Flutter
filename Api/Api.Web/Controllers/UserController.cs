using System;
using System.Threading.Tasks;
using Api.Application.DTOs.User;
using Api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController<UserController>
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Autenticação do usuário
        /// </summary>
        /// <param name="userRequest">Credenciais</param>
        /// <returns>Retorna dados do usuário e um token.</returns>
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserRequestDTO userRequest)
        {
            UserResponseDTO userData;
            try
            {
                userData = await _userService.Authenticate(userRequest);
            }
            catch (Exception ex)
            {
                return CreateServerErrorResponse(ex, null);
            }

            return CreateResponse(userData);
        }
    }
}