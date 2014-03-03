using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class WorkerOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserDefiner"] != "Worker")
        //{
        //    Response.Redirect("HomePage.aspx");
        //}
        PopulateAvailableOrdersGridView();
        PopulateInProgressOrdersGridView();
    }
    public void PopulateAvailableOrdersGridView()
    {
        OrderService os = new OrderService();
        this.GridViewAvailableOrders.DataSource = os.GetAvailableOrders();
        this.GridViewAvailableOrders.DataBind();
    }

    public void PopulateInProgressOrdersGridView()
    {
        OrderService os = new OrderService();
        this.GridViewInProgressOrders.DataSource = os.GetOrdersForWorker(Convert.ToInt32(Session["WorkerID"]));
        this.GridViewInProgressOrders.DataBind();
    }
}