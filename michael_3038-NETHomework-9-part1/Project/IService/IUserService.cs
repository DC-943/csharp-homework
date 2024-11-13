using michael_3038_WebApiHomework.Models;


namespace michael_3038_WebApiHomework.IService
{
   public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Add(User newBook);
        User GetById(int id);

        User GetByNamePassword(string name, string password);
        User GetByEmail(string email);
        void Remove(int id);
    }
}
