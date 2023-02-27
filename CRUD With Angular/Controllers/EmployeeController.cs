using CRUD_With_Angular.Interface;
using CRUD_With_Angular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CRUD_With_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _servie;

        public EmployeeController(IEmployee servie)
        {
            _servie = servie;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee() 
        {
            var data = await _servie.GetEmployeesAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            employee.Id= Guid.NewGuid();
            await _servie.AddAsync(employee);

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]Guid id, [FromBody]  Employee employee)
        {
           var data = await _servie.GetEmployeeByIdAsync(id);

            if(data != null)
            {
               await _servie.UpdateAsync(id, employee);

                return Ok(employee);
            }
            else
            {
                return NotFound("Not found");
            }
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var data = await _servie.GetEmployeeByIdAsync(id);

            if (data != null)
            {
                await _servie.DeleteAsync(id);

                return Ok(data);
            }
            else
            {
                return NotFound("Not found");
            }
        }
    }
}
