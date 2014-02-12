﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        UserService us = new UserService();
        e.Authenticated = us.ValidateUser(this.Login1.UserName,this.Login1.Password);
    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
        this.Login1.FailureText = "Failed to login";
    }
}