using michael_3038EFWebAPI.Models
namespace michael_3038EFWebAPI.IService
{
    public interface IUserService
    {
        bool Insert(User user);

        List<User> GetAll();

        Task<UserEF> GetUserByNameAsync(string username);

    }
}
