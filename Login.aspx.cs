using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        UserService us = new UserService();
        DataSet ds = us.ValidateUser(this.Login1.UserName, this.Login1.Password);
        if (ds != null)
        {
            e.Authenticated = true;
            Session["UserName"] = this.Login1.UserName;
            Session["UserID"] = ds.Tables[0].Rows[0]["ClientID"];
        }
    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
        this.Login1.FailureText = "ההתחברות נכשלה";
    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        Session["UserName"] = this.Login1.UserName;
        Session["UserDefiner"] = "User";
        Response.Redirect("HomePage.aspx");
    }
    protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
    {
        WorkerService ws = new WorkerService();
        Session["WorkerID"] = ws.ValidateWorker(this.Login2.UserName, this.Login2.Password);
        if (Session["WorkerID"] != null)
            e.Authenticated = true;
    }
    protected void Login2_LoginError(object sender, EventArgs e)
    {
        this.Login2.FailureText = "ההתחברות נכשלה";
    }
    protected void Login2_LoggedIn(object sender, EventArgs e)
    {
        Session["UserName"] = this.Login2.UserName;
        Session["UserDefiner"] = "Worker";
        Response.Redirect("HomePage.aspx");
    }
}