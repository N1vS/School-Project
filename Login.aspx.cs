using System;
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
        this.Login1.FailureText = "ההתחברות נכשלה";
    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        CheckBox mashu = (CheckBox)this.Login1.FindControl("RememberMe");

        if (mashu.Checked)
        {
            HttpCookie myCookie = new HttpCookie("myCookie");
            Response.Cookies.Remove("myCookies");
            Response.Cookies.Add(myCookie);
            myCookie.Values.Add("userName", this.Login1.UserName.ToString());
            DateTime dtEXpiration = DateTime.Now.AddDays(10);
            Response.Cookies["myCookie"].Expires = dtEXpiration;
        }

        Session["UserName"] = this.Login1.UserName;
        Session["UserDefiner"] = "User";
        Response.Redirect("HomePage.aspx");
    }
}