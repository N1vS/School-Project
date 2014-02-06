using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Client
/// </summary>
public class Client
{

    private int clientID, cityID, phone;
    private string email, street;

	public Client()
	{

	}


    #region Properties

    public int GetClientID() { return this.cityID; }
    public void SetClientID(int ClientID) { this.clientID = ClientID; }

    public int GetCityID() { return this.cityID; }
    public void SetCityID(int CityID) { this.cityID = CityID; }

    public int GetPhoneNumber() { return this.phone; }
    public void SetPhoneNumber(int number) { this.phone = number; }

    public string GetEmail() { return this.email; }
    public void SetEmail(string Email) { this.email = Email; }

    public string GetStreet() { return this.street; }
    public void SetStreet(string Street) { this.street = Street; }

    #endregion
}