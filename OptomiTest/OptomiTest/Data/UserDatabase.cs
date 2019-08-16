using System;
using SQLite;
using OptomiTest.Models;
using System.Collections.Generic;
using System.IO;

namespace OptomiTest.Data
{
    public class UserDatabase
    {
        static readonly object locker = new object();
        readonly SQLiteConnection database;
        private string dbPath;

        public UserDatabase()
        {
            dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "localDB.db3");
            database = new SQLite.SQLiteConnection(dbPath);
        }

        public bool CreateTable()
        {
            try
            {
                //database.DeleteAll<User>();
                database.CreateTable<User>();
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine("Error trying to connect to the DB : " + ex.Message);
                return false;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            lock (locker)
            {
                return database.Table<User>().ToList();
            }
        }

        public User Find(int id)
        {
            lock (locker)
            {
                return database.Table<User>().FirstOrDefault();
            }
        }

        public int Insert(User user)
        {
            lock (locker)
            {
                return database.Insert(user);
            }
        }

        public int Update(User user)
        {
            lock (locker)
            {
                return database.Update(user);
            }
        }

        public int Delete(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
