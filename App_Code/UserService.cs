using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

public class UserService
{
	public UserService()
	{
		
	}

    public DataSet ValidateUser(string UserName, string Password)
    {
        try
        {
            DataSet ds = new DataSet();
            string sqlCommand = "SELECT * FROM Clients WHERE UserName='" + UserName + "' AND Pass='" + Password + "'";
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            OleDbDataAdapter myAdapter = new OleDbDataAdapter(cmd);
            myCon.Open();
            myAdapter.Fill(ds);
            return ds;
            
        }
        catch (OleDbException ex)
        {
            throw ex;
        }     
    }
}