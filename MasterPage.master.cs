using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserDefiner"] == "Worker")
        {
            MenuItem item = new MenuItem("משלוחי עובד", "WorkerOrders");
            item.NavigateUrl = "~/WorkerOrders.aspx";
            item.Enabled = true;
            this.NavigationMenu.Items.Add(item);
        }
    }
}
