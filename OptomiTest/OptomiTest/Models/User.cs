using System;
using SQLite;
namespace OptomiTest.Models
{
    public class User
    {
        private int id;
        private string username;
        private string firstName;
        private string lastName;
        private string password;

        public string Username { get => username; set => username = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }

        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => id = value; }

        public User()
        {
        }

        public User(string _username, string _firtName, string _lastName, string _password)
        {
            this.username = _username;
            this.firstName = _firtName;
            this.lastName = _lastName;
            this.password = _password;
        }

    }
}
