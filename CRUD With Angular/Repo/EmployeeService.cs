using CRUD_With_Angular.Database;
using CRUD_With_Angular.Interface;
using CRUD_With_Angular.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_With_Angular.Repo
{
    public class EmployeeService : IEmployee
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.tblEmployee.AddAsync(employee); 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var data = _context.tblEmployee.FirstOrDefault( n => n.Id == id);

            _context.tblEmployee.Remove(data);

            await _context.SaveChangesAsync();  
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            var data = await _context.tblEmployee.FirstOrDefaultAsync(n=>n.Id== id);

            return data;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
           var data = await _context.tblEmployee.ToListAsync();
           return data;
        }

        public async Task<Employee> UpdateAsync(Guid id, Employee employee)
        {
            var data = _context.tblEmployee.FirstOrDefault(n => n.Id == id);

            data.Email = employee.Email;
            data.Phone = employee.Phone;
            data.Name = employee.Name;

            _context.tblEmployee.Update(data);
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
