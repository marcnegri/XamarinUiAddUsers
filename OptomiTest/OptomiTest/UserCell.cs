using Foundation;
using OptomiTest.Models;
using System;
using UIKit;

namespace OptomiTest
{
    public partial class UserCell : UITableViewCell
    {
        public UserCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(User user)
        {
            lblUsername.Text = user.Username;
            lblPasword.Text = user.Password;
        }
    }
}