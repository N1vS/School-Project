using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for CityService
/// </summary>
public class CityService
{
	public CityService()
	{

	}

    public DataSet GetAllCities()
    {
        try
        {
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand("GetAllCities", myCon); 
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            myCon.Open();
            OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            myAdapter.SelectCommand = cmd;
            myAdapter.Fill(ds);
            myCon.Close();
            return ds;
        }
        catch (OleDbException ex)
        {
            throw ex;
        }
        

    }
    public string GetCityByID(int CityID)
    {
        try
        {
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand("GetCityByID", myCon); 
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbParameter parameter = new OleDbParameter("CityID", OleDbType.Integer);
            parameter.Direction = ParameterDirection.InputOutput;
            parameter.Value = CityID;
            cmd.Parameters.Add(parameter);
            DataSet ds = new DataSet();
            myCon.Open();
            string name = cmd.ExecuteScalar().ToString();
            myCon.Close();
            return name;
        }
        catch (OleDbException ex)
        {
            throw ex;
        }
    }
    public DataSet GetCitiesAndCenters()
    {
        try
        {
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand("GetAllCitiesAndCenters", myCon);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            myCon.Open();
            OleDbDataAdapter myAdapter = new OleDbDataAdapter();
            myAdapter.SelectCommand = cmd;
            myAdapter.Fill(ds);
            myCon.Close();
            return ds;
        }
        catch (OleDbException ex)
        {
            throw ex;
        }
        



    }

}