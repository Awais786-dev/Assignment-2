namespace FirstAssignment.Models
{
    public class UserRepos
    {
        // List<User> users;
        private List<User> users; // Static list
       // private List<User> users;
        public UserRepos()
        {
                users = new List<User>()  {
                new User() { Id=1, Name="M Awais" , Age=21 , Address="Lahore"},
                new User() { Id=2, Name="Ali Khan" , Age=27 , Address="Pishawer" },
                new User() { Id=3,  Name="Tahir Mustasfvi" , Age=20  , Address="Multan"},
                new User() { Id=4,  Name="Abdullah" , Age=23 , Address="Karachi" }

            };
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {     
            return users.Find(s=> s.Id == id);
        }

        public void AddNewUser(User user)
        {
            users.Add(user);
        }


        public void UpdateUser(int id, User updatedUser)
        {
            User existingUser = GetUserById(id);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Age = updatedUser.Age;
                existingUser.Address = updatedUser.Address;
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

            public void DeleteUser(int id)
            {
                User userToRemove = GetUserById(id);
                if (userToRemove != null)
                {
                    users.Remove(userToRemove);
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
        


        public void DeleteUserAndCheck(int id)
        {
            // Attempt to delete the user
            DeleteUser(id);

            // Check if the user still exists
            var deletedUser = GetUserById(id);

            if (deletedUser == null)
            {
                Console.WriteLine($"User with ID {id} was successfully deleted.");
            }
            else
            {
                Console.WriteLine($"User with ID {id} was not deleted.");
            }
        }



    }
}
