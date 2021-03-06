﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

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
            string sqlCommand = "SELECT CityName FROM Cities WHERE CityID=" + CityID + ";";
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
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
    public int GetCenterIDByCityID(int CityID)
    {
        string sqlCommand = "SELECT CenterID FROM Cities WHERE CityID=" + CityID;
        try
        {
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            int centerID;
            myCon.Open();
            centerID = Convert.ToInt32(cmd.ExecuteScalar());
            myCon.Close();
            return centerID;
        }
        catch (OleDbException ex)
        {
            throw ex;
        } 
    }
}