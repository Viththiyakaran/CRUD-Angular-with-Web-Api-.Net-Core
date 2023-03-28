using CRUD_With_Angular.Models;

namespace CRUD_With_Angular.Interface
{
    public interface ILogin
    {
        Task<Login> LoginAsync(Login loginDetail);


    }
}
