using michael_3038_WebApiHomework.IService;
using michael_3038_WebApiHomework.Models;
using MySql.Data.MySqlClient;
using System.Data;
namespace michael_3038_WebApiHomework.Service
{
    public class UserService: IUserService
    {
        private string connection = "server=localhost;port=3306;database=myfirstadodb;user=root;password=123456";

        public bool Insert(User user)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
                {
                    mySqlConnection.Open();
                    string insertSql = "insert into users(username,password,email,age,gender,active,address) values (@username,@password,@email,@age,@gender,@active,@address)";
                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = insertSql;
                        mySqlCommand.Parameters.AddWithValue("@username", user.UserName);
                        mySqlCommand.Parameters.AddWithValue("@password", user.Password);
                        mySqlCommand.Parameters.AddWithValue("@email", user.Email);
                        mySqlCommand.Parameters.AddWithValue("@age", user.Age);
                        mySqlCommand.Parameters.AddWithValue("@gender", user.Gender);
                        mySqlCommand.Parameters.AddWithValue("@active", user.Active);
                        mySqlCommand.Parameters.AddWithValue("@address", user.Address);
                        var count = mySqlCommand.ExecuteNonQuery();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
        public bool Update(int userId, string password)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
                {
                    mySqlConnection.Open();
                    string updateSql = "UPDATE users SET password = @password WHERE id = @id";
                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = updateSql;
                        mySqlCommand.Parameters.AddWithValue("@password", password);
                        mySqlCommand.Parameters.AddWithValue("@id", userId);
                        var count = mySqlCommand.ExecuteNonQuery();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;

        }

        public bool Delete(int userId)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
                {
                    mySqlConnection.Open();
                    string deleteSql = "DELETE FROM users WHERE id= @userId";
                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.CommandText = deleteSql;
                        mySqlCommand.Parameters.AddWithValue("@userId", userId);
                        var count = mySqlCommand.ExecuteNonQuery();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;

        }
        public List<User> SearchRowByRow(string age)
        {
            try
            {
                List<User> users = new List<User>();
                using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
                {
                    mySqlConnection.Open();
                    string searchSql = "SELECT * FROM users WHERE age = @age";
                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.Parameters.AddWithValue("@age", age);
                        mySqlCommand.CommandText = searchSql;
                        var rd = mySqlCommand.ExecuteReader();
                        while (rd.Read())
                        {
                            User user = new User();
                            user.UserName = rd.GetString("username");
                            user.Email = rd.GetString("email");
                            user.Address = rd.GetString("address");
                            user.Gender = (GenderEnum)rd.GetInt16("gender");
                            users.Add(user);
                        }
                        rd.Close();
                    }
                }
                 return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<User> SearchInBatch(string age)
        {
            try
            {
                List<User> users = new List<User>();
                using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
                {
                    mySqlConnection.Open();
                    string searchSql = "SELECT * FROM user WHERE age = @age";

                    using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                    {
                        mySqlCommand.Parameters.AddWithValue("@age", age);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(mySqlCommand);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            User user = new User();
                            user.UserName = ConvertToString(dr["username"]);
                            user.Email = ConvertToString(dr["email"]);
                            user.Address = ConvertToString(dr["address"]);
                            user.Gender = dr["gender"] == DBNull.Value ? GenderEnum.Male : (GenderEnum)Convert.ToInt32(dr["gender"]);
                            users.Add(user);
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        private string? ConvertToString(object obj)
        {
            if (obj == null)
                return null;
            if (obj == DBNull.Value)
                return null;

            return Convert.ToString(obj);

        }


    }
}
