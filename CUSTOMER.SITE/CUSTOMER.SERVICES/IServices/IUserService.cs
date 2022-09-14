using CUSTOMER.DTO;
using CUSTOMER.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOMER.SERVICES.IServices
{
    public interface IUserService
    {
        Token Login(LoginDTO login);
        string signUp(User user);
        IEnumerable<UserDTO> GetAllClients();
        IEnumerable<UserDTO> GetAllAdmins();
        UserDTO GetUserById(int id);
        string createAdmin(User user);

    }
}
