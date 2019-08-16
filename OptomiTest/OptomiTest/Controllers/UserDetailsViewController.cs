using Foundation;
using System;
using System.IO;
using UIKit;
using OptomiTest.Data;
using System.Text.RegularExpressions;

namespace OptomiTest
{
    public partial class UserDetailsViewController : UIViewController
    {
        public string IdUser { get; set; }
        private readonly UserDatabase userDb;

        public UserDetailsViewController (IntPtr handle) : base (handle)
        {
            userDb = new UserDatabase();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnSave.Clicked += BtnSave_Clicked;
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
           string errorMessage = null;
           try
            {
                if (PasswordValidation(txtLastName.Text, out errorMessage))
                    userDb.Insert(new Models.User { FirstName = txtFirstName.Text, LastName = txtLastName.Text });
                else
                    Console.WriteLine(errorMessage);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool PasswordValidation(string password, out string errorMessage)
        {
            var input = password;
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "The password can not be empty";
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasMiniMaxChars = new Regex(@"^.{5,12}$");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (!hasLowerChar.IsMatch(input))
            {
                errorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                errorMessage = "Password should not be less than or greater than 12 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                errorMessage = "Password should contain At least one numeric value";
                return false;
            }
            else if(detectSequences(password))
            {
                errorMessage = "There are 2 sequences of characters which are followed ";
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool detectSequences(string password)
        {
            for(int i=0; i< password.Length; i++){
                for (int j = 1; j < password.Length; j++)
                {
                    if (j < password.Length - i)
                    {
                        string sequence = password.Substring(i, j);
                        if (!String.IsNullOrEmpty(sequence))
                        {
                            if (sequence.Length * 2 < password.Length - i)
                            {
                                if (sequence == password.Substring(sequence.Length + i, sequence.Length))
                                    return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}