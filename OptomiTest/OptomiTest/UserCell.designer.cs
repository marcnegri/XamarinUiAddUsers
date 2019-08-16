// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace OptomiTest
{
    [Register ("UserCell")]
    partial class UserCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPasword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblUsername { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblPasword != null) {
                lblPasword.Dispose ();
                lblPasword = null;
            }

            if (lblUsername != null) {
                lblUsername.Dispose ();
                lblUsername = null;
            }
        }
    }
}