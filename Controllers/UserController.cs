using Microsoft.AspNetCore.Mvc;
using FirstAssignment.Models;
using FirstAssignment.Services;
using AutoMapper; 

namespace FirstAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //  private UserService _userService; // Use the service
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper; // Inject AutoMapper
        }

        [HttpGet]
        [Route("get")]
        public List<UserDto> Get()
        {
             var users = _userService.GetAllUsers();
             return _mapper.Map<List<UserDto>>(users);
            // return _userService.GetAllUsers();
        }


        [HttpGet]
        // [HttpGet("{id}")]
        [Route("find/{id}")]
        public ActionResult<UserDto> Get(int id) // Return UserDto
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return _mapper.Map<UserDto>(user); // Map User to UserDto
        }

        [HttpPost]
        [Route("Add")]
        public ApiResponse<List<UserDto>> Add(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                _userService.AddUser(user);

                var users = _userService.GetAllUsers();
                var userDtos = _mapper.Map<List<UserDto>>(users);

                return new ApiResponse<List<UserDto>>
                {
                    Status = "success",
                    Message = "User added successfully.",
                    Data = userDtos
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<UserDto>>
                {
                    Status = "error",
                    Message = "An error occurred while adding the user.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }



        //public List<User> Update(User user, int id)
        //{
        //    _userService.UpdateUser(id, user);
        //   return _userService.GetAllUsers();
        //}



        [HttpPut("{id}")]
        // [Route("update")]
        public ApiResponse<List<UserDto>> Update(UserDto userDto, int id) 
        {
            var user = _mapper.Map<User>(userDto); // Map UserDto to User
            _userService.UpdateUser(id, user);
            // Get all users and map to UserDto
            var users = _userService.GetAllUsers();
            var userDtos = _mapper.Map<List<UserDto>>(users);

            // return userDtos;
            return new ApiResponse<List<UserDto>>
            {
                Status = "success",
                Message = "User updated successfully.",
                Data = userDtos
            };
        }



        [HttpDelete("{id}")]
        // [Route("update")]
        public ApiResponse<List<UserDto>> DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                var users = _userService.GetAllUsers();
                var userDtos = _mapper.Map<List<UserDto>>(users);

                return new ApiResponse<List<UserDto>>
                {
                    Status = "success",
                    Message = "User deleted successfully.",
                    Data = userDtos
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<UserDto>>
                {
                    Status = "error",
                    Message = "User ID is not Available. Try In Given Ids",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

    }
}
