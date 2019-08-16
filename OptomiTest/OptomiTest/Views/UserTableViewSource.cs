using System;
using System.Collections.Generic;
using Foundation;
using OptomiTest.Models;
using UIKit;
namespace OptomiTest
{
    public class UserTableViewSource : UITableViewSource
    {
        private List<User> lstUsers;

        public UserTableViewSource(List<User> lstUsers)
        {
            this.lstUsers = lstUsers;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UserCell cell = null;
            try { 
            cell = (UserCell)tableView.DequeueReusableCell("user_cell_id", indexPath); //new UITableViewCell(UITableViewCellStyle.Default, "");

            var user = lstUsers[indexPath.Row];
            cell.UpdateCell(user);
            //cell.TextLabel.Text = lstUsers[indexPath.Row].FirstName;

            return cell;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return lstUsers.Count;
        }
    }
}
 