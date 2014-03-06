using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Client
/// </summary>
public class Client
{

    private int clientID, cityID;
    private string email, address, phone, cityName;

	public Client()
	{

	}
    public Client(int ClientID)
    {
        this.clientID = ClientID;
        ClientService cs=new ClientService();
        DataSet ds = cs.GetClientDetailsByID(ClientID);
        this.cityID = Convert.ToInt32(ds.Tables[0].Rows[0]["CityID"]);
        this.email = ds.Tables[0].Rows[0]["Email"].ToString();
        this.address = ds.Tables[0].Rows[0]["Address"].ToString();
        this.phone = ds.Tables[0].Rows[0]["Phone"].ToString() ;

    }

    #region Properties

    public int GetClientID() { return this.cityID; }
    public void SetClientID(int ClientID) { this.clientID = ClientID; }

    public int GetCityID() { return this.cityID; }
    public void SetCityID(int CityID) { this.cityID = CityID; }

    public string GetPhoneNumber() { return this.phone; }
    public void SetPhoneNumber(string number) { this.phone = number; }

    public string GetEmail() { return this.email; }
    public void SetEmail(string Email) { this.email = Email; }

    public string GetAddress() { return this.address; }
    public void SetAddress(string Address) { this.address = Address; }

    #endregion
}