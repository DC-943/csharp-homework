using michael_3038EFWebAPI.IService;
using michael_3038EFWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using michael_3038EFWebAPI.Data;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;


namespace michael_3038EFWebAPI.Service
{
    public class UserService : IUserService
    {
        private ApplicationSettings _settings;

        /** for interface implementation, no meaning here**/
        public UserService(ApplicationSettings appSettings) {
            _settings = appSettings;
        }

        public bool Insert(User user)
        {
            return false;
        }

        public  List<User> GetAll()
        {
            List<User> list = new List<User>();
            return list;
        }

        public Task<UserEF> GetUserByNameAsync(string username)
        {
            UserEF user = new UserEF();

            return null;
        }

        /*********** for remote API test****************/

        public async Task<IList<User>> GetUserAsync()
        {
            HttpClient client = new HttpClient();
            //Imaging there is some access token required to pull data remotely
            
            using HttpResponseMessage response = await client.GetAsync(_settings.URL);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<IList<User>>(jsonResponse, options);
        }


    }
    public class ApplicationSettings
    {
        public string URL { get; set; }
    }
}
