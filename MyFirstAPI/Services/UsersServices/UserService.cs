
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Data;

namespace MyFirstAPI.Services.UsersServices
{
    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<string> AddUser(User User)
        {
            try
            {
                _context.Users.Add(User);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return "ERROR: could not add user :" + ex.Message;
            }

            return "OK";
        }

        public async Task <string> DeleteUser(Int64 UserId)
        {
            try
            {
                var User = await _context.Users.FindAsync(UserId);
                if (User is null)
                    return "ERROR: User id invalid";


                _context.Users.Remove(User);

               await _context.SaveChangesAsync();

                return "OK";

            }
            catch (Exception ex)
            {
                return "ERROR: could not delete user :" + ex.Message;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            var Users = await _context.Users.ToListAsync();

            return Users;
        }

        public async Task<User> GetUser(Int64 UserId)
        {
            var User = await _context.Users.FindAsync(UserId);
            if (User is null)
                return null;

            return User;
        }

        public async Task<string> UpdateUser(User UpdateDataUser)
        {

            try
            {
                var User = await _context.Users.FindAsync(UpdateDataUser.UserId);
                if (User is null)
                    return "ERROR: User id invalid";



                User.Name = UpdateDataUser.Name;
                User.Email = UpdateDataUser.Email;
                User.LastName = UpdateDataUser.LastName;

                _context.SaveChanges();

                return "OK";

            }
            catch (Exception ex)
            {
                return "ERROR: could not edit user :" + ex.Message;
            }
        }
    }
}
