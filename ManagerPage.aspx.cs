using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class ManagerPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateWorkersGridView();
        PopulateOrdersGridView();
    }

    public void PopulateWorkersGridView()
    {
        WorkerService ws = new WorkerService();
        this.GridViewWorkers.DataSource = ws.GetUnActiveWorkers();
        this.GridViewWorkers.DataBind();
    }

    public void PopulateOrdersGridView()
    {
        OrderService os = new OrderService();
        this.GridViewUnCompletedOrders.DataSource = os.GetUnCompletedOrders();
        this.GridViewUnCompletedOrders.DataBind();

    }

    protected void GridViewWorkers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="MakeWorkerActive")
        {
            try
            {
                object row = e.CommandArgument;
                int rowNumber = Convert.ToInt32(row);
                int workerID = Convert.ToInt32(((GridView)sender).Rows[rowNumber].Cells[0].Text);
                string sqlCommand = "UPDATE Workers SET Activity='Active' WHERE WorkerID=" + workerID + ";";

                OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
                OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();
                PopulateWorkersGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
    protected void GridViewUnCompletedOrders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "UnActiveOrder")
        {
            try
            {
                object row = e.CommandArgument;
                int rowNumber = Convert.ToInt32(row);
                int orderID = Convert.ToInt32(((GridView)sender).Rows[rowNumber].Cells[0].Text);
                string sqlCommand = "UPDATE Orders SET Status='Done' WHERE OrderID="+orderID+";";

                OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
                OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();
                PopulateOrdersGridView();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }

}