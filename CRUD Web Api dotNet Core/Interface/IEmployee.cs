using CRUD_With_Angular.Models;

namespace CRUD_With_Angular.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(Guid id);

        Task AddAsync(Employee employee);

        Task<Employee> UpdateAsync(Guid id, Employee employee);

        Task DeleteAsync(Guid id);
    }
}
