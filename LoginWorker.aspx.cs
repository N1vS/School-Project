using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginWorker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        WorkerService ws = new WorkerService();
        Session["WorkerFirstName"] = ws.ValidateWorker(this.Login1.UserName, this.Login1.Password);
        if (Session["WorkerFirstName"] != null)
            e.Authenticated = true;
    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        Session["UserName"] = this.Login1.UserName;
        Session["UserDefiner"] = "Worker";
        Response.Redirect("HomePage.aspx");
    }
}