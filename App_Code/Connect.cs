using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Connect
/// </summary>
public class Connect
{
    const string filename = "Delivery Company Database.mdb";
    public static string getConnectionString()
    {
        string location = HttpContext.Current.Server.MapPath("~/App_Data/" + filename);
        string connection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + location;
        return connection;
    }
}