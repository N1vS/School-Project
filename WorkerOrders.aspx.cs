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
        if (Session["UserDefiner"].ToString() != "Worker")
        {
            Response.Redirect("HomePage.aspx");
        }
        PopulateAvailableOrdersGridView();
        PopulateInProgressOrdersGridView();
        PopulateDoneOrdersGridView();
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
    public void PopulateDoneOrdersGridView()
    {
        OrderService os = new OrderService();
        this.GridViewInProgressOrders.DataSource = os.GetCompletedOrdersForWorker(Convert.ToInt32(Session["WorkerID"]));
        this.GridViewInProgressOrders.DataBind();
    }
    protected void GridViewAvailableOrders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ApplyOrder")
        {
            try
            {
                object row = e.CommandArgument;
                int rowNumber = Convert.ToInt32(row);
                int orderID = Convert.ToInt32(((GridView)sender).Rows[rowNumber].Cells[0].Text);
                int workerID = Convert.ToInt32(Session["WorkerID"]);
                string sqlCommand = "UPDATE Orders SET WorkerID=" + workerID + ", Status='InProgress' WHERE OrderID=" + orderID + ";";

                OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
                OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();
                PopulateAvailableOrdersGridView();
                PopulateInProgressOrdersGridView();
                PopulateDoneOrdersGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void GridViewInProgressOrders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "OrderDone")
        {
            try
            {
                object row = e.CommandArgument;
                int rowNumber = Convert.ToInt32(row);
                int orderID = Convert.ToInt32(((GridView)sender).Rows[rowNumber].Cells[0].Text);
                int workerID = Convert.ToInt32(Session["WorkerID"]);
                string sqlCommand = "UPDATE Orders SET Status='Done' WHERE OrderID=" + orderID + ";";

                OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
                OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();
                PopulateAvailableOrdersGridView();
                PopulateInProgressOrdersGridView();
                PopulateDoneOrdersGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        if (e.CommandName == "FailOrder")
        {
            try
            {
                object row = e.CommandArgument;
                int rowNumber = Convert.ToInt32(row);
                int orderID = Convert.ToInt32(((GridView)sender).Rows[rowNumber].Cells[0].Text);
                int workerID = Convert.ToInt32(Session["WorkerID"]);
                string sqlCommand = "UPDATE Orders SET WorkerID=0, Status='New' WHERE OrderID=" + orderID + ";";

                OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
                OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();
                PopulateAvailableOrdersGridView();
                PopulateInProgressOrdersGridView();
                PopulateDoneOrdersGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void GridViewDoneOrders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FailOrder")
        {
            try
            {
                object row = e.CommandArgument;
                int rowNumber = Convert.ToInt32(row);
                int orderID = Convert.ToInt32(((GridView)sender).Rows[rowNumber].Cells[0].Text);
                int workerID = Convert.ToInt32(Session["WorkerID"]);
                string sqlCommand = "UPDATE Orders SET WorkerID=0, Status='New' WHERE OrderID=" + orderID + ";";

                OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
                OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();
                PopulateAvailableOrdersGridView();
                PopulateInProgressOrdersGridView();
                PopulateDoneOrdersGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

