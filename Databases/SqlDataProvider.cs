using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace Databases
{
    public class SqlDataProvider
    {
        private MySqlConnection _connection;

        private int chunk = 10000;

        public void Open(string serverAddress, string dbName, string userName, string userPass)
        {
            _connection = new MySqlConnection($"" +
              $"Server = {serverAddress}; " +
              //$"Port = {port};" +
              $"Database = {dbName};" +
              $"Uid = {userName};" +
              $"Pwd = {userPass};");

            _connection.Open();
        }

        public IList<UserDataItem> GetUserData()
        {
            GetUseDatabaseCommand().ExecuteNonQuery();
            var reader = CreateGetUserDataCommand().ExecuteReader();
            var result = new List<UserDataItem>();
            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string firstName = reader.GetString("firstname");
                string lastName = reader.GetString("lastname");
                string m1 = reader.GetString("email");
                string m2 = reader.GetString("email2");
                string profession = reader.GetString("profession");
                var userDataItem = new UserDataItem(id, firstName, lastName, m1, m2, profession);
                result.Add(userDataItem);
            }

            return result;
        }

        public void AddUserData(IList<UserDataItem> data)
        {
            GetUseDatabaseCommand().ExecuteNonQuery();
            var offset = 0;

            do
            {
                var sb = new StringBuilder();
                sb.Append("INSERT INTO user_data (id, firstname, lastname, email, email2, profession) VALUES ");
                var rowsLeft = data.Count - offset;
                var rowsToInsert = rowsLeft < chunk ? rowsLeft : chunk;

                var rows = new List<string>();

                for (int i = 0; i < rowsToInsert; i++)
                {
                    var item = data[offset + i];
                    rows.Add($"('{item.id}','{item.firstname}', '{item.lastname}', '{item.email}', '{item.email2}', '{item.profession}')");
                }

                offset += rowsToInsert;

                var allRows = string.Join(',', rows);
                sb.Append(allRows);
                sb.Append(";");
                var q = sb.ToString();
                var cmd = new MySqlCommand(q, _connection);

                cmd.ExecuteNonQuery();

            } while (offset < data.Count);
        }


        private MySqlCommand GetUseDatabaseCommand()
        {
            var cmd = new MySqlCommand("use test;", _connection);
            return cmd;
        }

        private MySqlCommand CreateGetUserDataCommand()
        {
            var command = new MySqlCommand("SELECT * FROM user_data;", _connection);
            return command;
        }
    }
}
