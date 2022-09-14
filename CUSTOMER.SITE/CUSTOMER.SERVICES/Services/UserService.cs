using CUSTOMER.CONSTANTS;
using CUSTOMER.DTO;
using CUSTOMER.MODELS;
using CUSTOMER.SERVICES.IServices;
using DATA.ACCESS.LAYER;
using DATA.ACCESS.LAYER.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOMER.SERVICES.Services
{
    public class UserService:IUserService
    {

        private readonly IRepository _repository;
        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public Token Login(LoginDTO login)
        {
            var user = getLoginDetails(login);
            if(user == null)
            {
                return new Token()
                {
                    JwtAuth = ""
                };
            }
            return new Token()
            {
                JwtAuth = JwtHelper.CreateJwtToken(user)
            };

        }


        private UserDTO getLoginDetails(LoginDTO login)
        {
            SqlParameter[] parameters =  new SqlParameter[]
            {
                new SqlParameter(UserProdeduresVariables.UserName, login.UserName),
                new SqlParameter(UserProdeduresVariables.Password , Hashing.HashPassword(login.Password))
            };
            DataTable dt = _repository.returnDTWithProc_adapter(StoredProdedureNames.UserLogin, parameters);
           return GetUserByDataTable(dt);

            
        }

        public string signUp(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(UserProdeduresVariables.UserName, user.UserName),
                new SqlParameter(UserProdeduresVariables.Password , Hashing.HashPassword(user.Password) ),
                new SqlParameter(UserProdeduresVariables.FirstName , user.FirstName),
                new SqlParameter(UserProdeduresVariables.LastName, user.LastName),
                new SqlParameter(UserProdeduresVariables.Role, UserRoles.Client),

            };
            return (string)_repository.executeScalerWithProc(StoredProdedureNames.UserSignUp, parameters);
        }

        public string createAdmin(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(UserProdeduresVariables.UserName, user.UserName),
                new SqlParameter(UserProdeduresVariables.Password , Hashing.HashPassword(user.Password) ),
                new SqlParameter(UserProdeduresVariables.FirstName , user.FirstName),
                new SqlParameter(UserProdeduresVariables.LastName, user.LastName),
                new SqlParameter(UserProdeduresVariables.Role, UserRoles.Admin),

            };
            return (string)_repository.executeScalerWithProc(StoredProdedureNames.UserSignUp, parameters);
        }

        public UserDTO GetUserById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
           {
                new SqlParameter(UserProdeduresVariables.UserId, id),
           };
            DataTable dt = _repository.returnDTWithProc_adapter(StoredProdedureNames.GetUserById, parameters);
            return GetUserByDataTable(dt);
        }
        public IEnumerable<UserDTO> GetAllClients()
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(UserProdeduresVariables.Role, UserRoles.Client),
            };
            DataTable dt = _repository.returnDTWithProc_adapter(StoredProdedureNames.GetUserByRole, parameters);
            return GetUsersByDataTable(dt);
        }

        public IEnumerable<UserDTO> GetAllAdmins()
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(UserProdeduresVariables.Role, UserRoles.Admin),
            };
            DataTable dt = _repository.returnDTWithProc_adapter(StoredProdedureNames.GetUserByRole, parameters);
            return GetUsersByDataTable(dt);
        }

        private IEnumerable<UserDTO> GetUsersByDataTable(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                return dt.AsEnumerable().Select(row => new UserDTO
                {
                    UserId = row.Field<int>(UserColumns.Id),
                    UserName = row.Field<string>(UserColumns.UserName),
                    FirstName = row.Field<string>(UserColumns.FirstName),
                    LastName = row.Field<string>(UserColumns.LastName),
                    Role = row.Field<string>(UserColumns.Role),
                }).ToList();
            }
            else
            {
                return null;
            }
        }
        private UserDTO GetUserByDataTable(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                return dt.AsEnumerable().Select(row => new UserDTO
                {
                    UserId = row.Field<int>(UserColumns.Id),
                    UserName = row.Field<string>(UserColumns.UserName),
                    FirstName = row.Field<string>(UserColumns.FirstName),
                    LastName = row.Field<string>(UserColumns.LastName),
                    Role = row.Field<string>(UserColumns.Role),
                }).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        


    }
}
