using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for ClientService
/// </summary>
public class ClientService
{
	public ClientService()
	{
	}
    public DataSet GetClientDetailsByID(int clientID)
    {
        try
        {
            DataSet ds = new DataSet();
            string sqlCommand = "SELECT * FROM Clients WHERE ClientID=" + clientID + ";";
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