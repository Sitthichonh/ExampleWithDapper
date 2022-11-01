using ExampleWithDapper.Dto;
using ExampleWithDapper.Interfaces;
using ExampleWithDapper.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser _user;
        private readonly IUserRoles _userRoles;
        private readonly IStatus _status;
        public UserController(IUser user, IUserRoles userRoles, IStatus status)
        {
            _user = user;
            _userRoles = userRoles;
            _status = status;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAll()
        {
            //try
            //{
            //    var users = await _user.GetUserAll();
            //    return Ok(users);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
            var users = await _user.GetUserAll();
            if (users is null)
                return NoContent();

            foreach(var item in users)
            {
                item.Role = await _userRoles.GetUserRoleById(item.UserID);
                item.Status = await _status.GetStatusById(item.StatusID);
            }
            return Ok(users);

        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetUserById(int UserId)
        {
            //try
            //{
            //    var user = await _user.GetUserByIdAsync(UserId);
            //    if (user is null)
            //        return NotFound();

            //    return Ok(user);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}

            var user = await _user.GetUserByIdAsync(UserId);
            if (user is null)
                return NotFound();
            user.Role = await _userRoles.GetUserRoleById(user.UserID);
            user.Status = await _status.GetStatusById(user.StatusID);
            return Ok(user);
        }

        [HttpGet("Username")]
        public async Task<IActionResult> GetUserByName(string username, string password)
        {
            //try
            //{
            //    var user = await _user.GetUserByNameAsync(username, password);
            //    if (user is null)
            //        return NotFound();

            //    return Ok(user);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}

            var user = await _user.GetUserByNameAsync(username, password);
            if (user is null)
                return NotFound();
            user.Role = await _userRoles.GetUserRoleById(user.UserID);
            user.Status = await _status.GetStatusById(user.StatusID);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(RequestUserModel user)
        {
            //try
            //{
            //    await _user.InsertUserByIdAsync(user);
            //    return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}

            try
            {
                var isUser = await _user.GetUserByNameAsync(user.Username, user.Password);
                if (isUser is not null)
                    return BadRequest("Useranme Or Password Duplicate");

                var dbUser = await _user.InsertUserByIdAsync(user);
                var userRole = new UserRoleDto { UserID = dbUser.UserID, /*RoleID = 2*/ RoleID = (int)RoleStatus.Member };
                if (dbUser.UserID > 0)
                    await _userRoles.InsertUserRole(userRole);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateUser(int Userid, RequestUserModel user)
        {
            //try
            //{
            //    var user = await _user.GetUserByIdAsync(Userid);
            //    if (user is null)
            //        return NotFound();

            //    await _user.UpdateUserByIdAsync(Userid, model);
            //    return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}

            try
            {
                var isUser = await _user.GetUserByNameAsync(user.Username, user.Password);
                if (isUser is not null)
                    return BadRequest("Useranme Or Password Duplicate");

                var dbUser = await _user.GetUserByIdAsync(Userid);
                if (dbUser is null)
                    return NotFound();

                await _user.UpdateUserByIdAsync(Userid, user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUser(int Userid)
        {
            //try
            //{
            //    var user = await _user.GetUserByIdAsync(Userid);
            //    if (user is null)
            //        return NotFound();

            //    await _user.DeleteUserByIdAsync(user.UserID);
            //    return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}

            try
            {
                var user = await _user.GetUserByIdAsync(Userid);
                if (user is null)
                    return NotFound();

                await _user.DeleteUserByIdAsync(Userid);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
