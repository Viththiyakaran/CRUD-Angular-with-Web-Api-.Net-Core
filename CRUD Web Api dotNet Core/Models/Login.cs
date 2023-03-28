using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRUD_With_Angular.Models
{
  
    public class Login
    {
        [Key]
        public int EmpId { get; set; }

        public Guid Id { get; set; }
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Designation { get; set; }

        public string? AccessToken { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
