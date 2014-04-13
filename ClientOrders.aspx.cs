using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class ClientOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserDefiner"]==null||Session["UserDefiner"]!="User")
            Response.Redirect("HomePage.aspx");

        PopulateInProgressOrdersGridView();
        PopulateCompletedOrdersGridView();
    }

    public void PopulateInProgressOrdersGridView()
    {
        OrderService os = new OrderService();
        int clientID = Convert.ToInt32(Session["UserID"]);
        this.GridViewInProgressOrders.DataSource = os.GetClientOrders(clientID);
        this.GridViewInProgressOrders.DataBind();

    }

    public void PopulateCompletedOrdersGridView()
    {
        OrderService os = new OrderService();
        int clientID = Convert.ToInt32(Session["UserID"]);
        this.GridViewDoneOrders.DataSource = os.GetClientCompletedOrders(clientID);
        this.GridViewDoneOrders.DataBind();

    }
    protected void GridViewInProgressOrders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CancelOrder")
        {
            try
            {
                object row = e.CommandArgument;
                int rowNumber = Convert.ToInt32(row);
                int orderID = Convert.ToInt32(((GridView)sender).Rows[rowNumber].Cells[0].Text);
                int clientID = Convert.ToInt32(Session["UserID"]);
                string sqlCommand = "DELETE FROM Orders  WHERE OrderID="+orderID+";";

                OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
                OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();

                PopulateInProgressOrdersGridView();
                PopulateCompletedOrdersGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}