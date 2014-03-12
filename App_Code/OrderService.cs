using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for OrderService
/// </summary>
public class OrderService
{
	public OrderService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet GetAvailableOrders()
    {
        try
        {
            DataSet ds=new DataSet();
            string sqlCommand = "SELECT * FROM Orders WHERE Status='New';";
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(ds);
            myCon.Close();
            return ds;

        }
        catch (OleDbException ex)
        {
            throw ex;
        }
    }
    public DataSet GetOrdersInProgressForWorker(int workerID)
    {
        try
        {
            DataSet ds = new DataSet();
            string sqlCommand = "SELECT * FROM Orders WHERE Status='InProgress' AND WorkerID="+workerID+";";
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(ds);
            myCon.Close();
            return ds;

        }
        catch (OleDbException ex)
        {
            throw ex;
        }
    }

    public DataSet GetCompletedOrdersForWorker(int workerID)
    {
        try
        {
            DataSet ds = new DataSet();
            string sqlCommand = "SELECT * FROM Orders WHERE Status='Done' AND WorkerID=" + workerID + ";";
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(ds);
            myCon.Close();
            return ds;
        }
        catch (OleDbException ex)
        {
            throw ex;
        }

    }

}