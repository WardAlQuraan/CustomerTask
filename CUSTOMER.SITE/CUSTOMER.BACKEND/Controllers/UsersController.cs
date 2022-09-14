using CUSTOMER.CONSTANTS;
using CUSTOMER.DTO;
using CUSTOMER.MODELS;
using CUSTOMER.SERVICES.IServices;
using CUSTOMER.SERVICES.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CUSTOMER.BACKEND.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Login(LoginDTO login)
        {
            
            try
            {
                var token = _userService.Login(login);
                return Ok(token);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult SignUp(User user)
        {
            try
            {                
                return Ok(_userService.signUp(user));
            }
            catch (SqlException ex)
            {
                return BadRequest(GetErrors.GenerateErrorMessage(ex.ErrorCode.ToString()));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public IHttpActionResult GetAllClients()
        {
            try
            {
                return Ok(_userService.GetAllClients());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public IHttpActionResult GetAllAdmins()
        {
            try
            {
                return Ok(_userService.GetAllAdmins());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IHttpActionResult CreateAdmin(User user)
        {
            try
            {
                return Ok(_userService.createAdmin(user));
            }
            catch (SqlException ex)
            {
                return BadRequest(GetErrors.GenerateErrorMessage(ex.ErrorCode.ToString()));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
