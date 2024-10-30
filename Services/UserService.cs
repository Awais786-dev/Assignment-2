using FirstAssignment.Models;

namespace FirstAssignment.Services
{
    public class UserService
    {
        private readonly UserRepos _userRepos;

        public UserService(UserRepos userRepos)
        {
            _userRepos = userRepos;
        }

        public List<User> GetAllUsers() => _userRepos.GetAllUsers();

        public User GetUserById(int id) => _userRepos.GetUserById(id);

        public void AddUser(User user) => _userRepos.AddNewUser(user);

        public void UpdateUser(int id, User updatedUser) => _userRepos.UpdateUser(id, updatedUser);

        public void DeleteUser(int id) => _userRepos.DeleteUserAndCheck(id);
    }

}
