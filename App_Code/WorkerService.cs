using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

public class WorkerService
{
	public WorkerService()
	{

	}
    public int ValidateWorker(string workerName, string Password)
    {
        try
        {
            string sqlCommand = "SELECT WorkerID FROM Workers WHERE WorkerName='" + workerName + "' AND Pass='" + Password + "'";
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            int name = Convert.ToInt32(cmd.ExecuteScalar());
            if (name != null)
            {
                myCon.Close();
                return name;
            }
            myCon.Close();
            return 0;

        }
        catch (OleDbException ex)
        {
            throw ex;
        }

    }
    public DataSet GetUnActiveWorkers()
    {
        try
        {
            DataSet ds = new DataSet();
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand("GetUnActiveWorkers", myCon);
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter myAdapter = new OleDbDataAdapter(cmd);
            myCon.Open();
            myAdapter.Fill(ds);
            myCon.Close();
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}