using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for City
/// </summary>
public class City
{
    private int cityID, centerID;
    private string cityName;


	public City()
	{

	}

    public City(int CityID, int CenterID, string CityName)
    {
        this.cityID = CityID;
        this.centerID = CenterID;
        this.cityName = CityName;
    }

    public string GetCenterName()
    {
        try
        {
            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand("GetCenterNameByID", myCon);
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbParameter parameter = new OleDbParameter("CityID", OleDbType.Integer);
            parameter.Direction = ParameterDirection.InputOutput;
            parameter.Value = this.centerID;
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

    #region Properties
    public int GetCityID() { return this.cityID; }
    public void SetCityID(int CityID) { this.cityID = CityID; }

    public int GetCenterID() { return this.centerID; }
    public void SetCenterID(int CenterID) { this.centerID = CenterID; }

    public string GetCityName() { return this.cityName; }
    public void SetCityName(string Name) { this.cityName = Name; }
    #endregion

}