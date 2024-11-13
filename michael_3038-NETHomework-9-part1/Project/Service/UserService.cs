using michael_3038_WebApiHomework.IService;
using michael_3038_WebApiHomework.Service;
using michael_3038_WebApiHomework.Models;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;

namespace michael_3038_WebApiHomework.Service
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>()
            {
                new User()
                {
                 UserId = 1,
                 UserName = "Jack Ma",
                 Email = "Jack.ma@gmail.com",
                 Address = "jane street",
                 Gender = GenderEnum.Male,
                 Password = "666",
                 Phone = "0408899798"
                },
                new User()
                {
                 UserId = 2,
                 UserName = "Donald Trump",
                 Email = "Donald.Trump@gmail.com",
                 Address = "Trump street",
                 Gender = GenderEnum.Male,
                 Password = "888",
                 Phone = "0408899797"

                },
                new User()
                {
                 UserId = 3,
                 UserName = "Joe Biden",
                 Email = "Joe.Biden@gmail.com",
                 Address = "Biden street",
                 Gender = GenderEnum.Male,
                 Password = "666",
                 Phone = "0408899796"
                },
                new User()
                {
                 UserId = 4,
                 UserName = "Joe Don",
                 Email = "Joe.Don@gmail.com",
                 Address = "Joe Street",
                 Gender = GenderEnum.Male,
                 Password = "666",
                 Phone = "0408899795"
                },
                new User()
                {
                 UserId = 5,
                 UserName = "Jane Don",
                 Email = "Jane.Don@gmail.com",
                 Address = "Jane Street",
                 Gender = GenderEnum.Male,
                 Password = "666",
                 Phone = "0408899794"
                }
            };
        }
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User Add(User newUser)
        {
            newUser.UserId = _users.Count + 1;
            _users.Add(newUser);
            return newUser;
        }

        public User GetById(int id)
        { 
            User user = _users.FirstOrDefault(item=>item.UserId == id);
            return user;
        }

        public User GetByNamePassword(string name, string password)
        {
            return _users.Where(a => a.UserName == name && a.Password == password).FirstOrDefault();
        }
        public User GetByEmail(string email)
        {
            return _users.Where(a => a.Email == email).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existingUser = _users.First(a => a.UserId == id);
            _users.Remove(existingUser);
        }
    }
}
