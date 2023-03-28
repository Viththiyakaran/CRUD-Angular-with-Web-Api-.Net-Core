using CRUD_With_Angular.Interface;
using CRUD_With_Angular.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_With_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILogin _servie;

        public LoginController(ILogin servie)
        {
            _servie = servie;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Login loginDetail)
        {
           var data =await _servie.LoginAsync(loginDetail);

            if(data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
    }
}
