namespace MyFirstAPI.Services.UsersServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<string> AddUser(User User);
        Task<string> UpdateUser(User User);
        Task<string> DeleteUser(Int64 UserId);
        Task<User> GetUser(Int64 UserId);

    }
}
