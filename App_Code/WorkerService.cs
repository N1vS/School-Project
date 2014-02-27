using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for WorkerService
/// </summary>
public class WorkerService
{
	public WorkerService()
	{

	}
    public string ValidateWorker(string workerName, string Password)
    {
        try
        {
            string sqlCommand = "SELECT FirstName FROM Workers WHERE WorkerName='" + workerName + "' AND Pass='" + Password + "'";
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            string name = cmd.ExecuteScalar().ToString();
            if (name != null)
            {
                myCon.Close();
                return name;
            }
            myCon.Close();
            return null;

        }
        catch (OleDbException ex)
        {
            throw ex;
        }

    }
}