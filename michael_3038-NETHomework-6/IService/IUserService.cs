using michael_3038_WebApiHomework.Models;

namespace michael_3038_WebApiHomework.IService
{
    public interface IUserService
    {
        bool Insert(User user);

        bool Update(int userId, string password);

        bool Delete(int userId);

        List<User> SearchRowByRow(string age);

        List<User> SearchInBatch(string age);

    }
}
