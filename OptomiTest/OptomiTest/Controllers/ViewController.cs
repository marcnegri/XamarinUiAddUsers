using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using UIKit;
using OptomiTest.Models;
using OptomiTest.Data;

namespace OptomiTest
{
    public partial class ViewController : UIViewController
    {
        private List<User> lstUsers;
        private UserDatabase userDB;
        public ViewController(IntPtr handle) : base(handle)
        {
            lstUsers = new List<User>();
            userDB = new UserDatabase();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            try {

                //Init DB
                userDB.CreateTable();

                //Init for the first Launch - populate data - mock
                lstUsers = new List<User>
                {
                    new User("johndoe", "john", "Doe", "123abc")
                };

                userTableView.Source = new UserTableViewSource(lstUsers);
                userTableView.RowHeight = UITableView.AutomaticDimension;
                userTableView.EstimatedRowHeight = 60f;
                userTableView.ReloadData();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            var userDetailsViewController = segue.DestinationViewController as UserDetailsViewController;
        }

        /// <summary>
        /// Refresh the user lists each time the view is refresh
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            try
            {
                lstUsers = new List<User>();
                var selectUsers = userDB.GetUsers();
                foreach (User user in selectUsers)
                {
                    lstUsers.Add(user);
                }
                userTableView.Source = new UserTableViewSource(lstUsers);
                userTableView.ReloadData();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not get users : " + ex.Message);
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}