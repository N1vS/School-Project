using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for UserService
/// </summary>
public class UserService
{
	public UserService()
	{
		
	}

    public bool ValidateUser(string UserName, string Password)
    {
        try
        {
            string sqlCommand = string.Format("SELECT * FROM Clients WHERE UserName='{0}' AND Pass='{1}'", UserName, Password);
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            if (cmd.ExecuteScalar()==null)
            {
                myCon.Close();
                return false;
            }
            myCon.Close();
            return true;
            
        }
        catch (OleDbException ex)
        {
            throw ex;
        }
        


    }


}