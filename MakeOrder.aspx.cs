using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class MakeOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateDestinationCitiesDropDown();
    }


    public void PopulateDestinationCitiesDropDown()
    {
        CityService cs = new CityService();
        this.DropDownListDestinationCities.DataSource = cs.GetCitiesAndCenters();
        this.DropDownListDestinationCities.DataTextField = "CityName";
        this.DropDownListDestinationCities.DataValueField = "CityID";
        this.DropDownListDestinationCities.DataBind();
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        int clientID = Convert.ToInt32(Session["UserID"]);

        Client orderingClient = new Client(clientID);
        City collectingCity = new City(orderingClient.GetCityID());
        string collectingCityName = collectingCity.GetCityName();
        int collectingCityID = orderingClient.GetCityID();
        string collectingAddress = orderingClient.GetAddress();

        string date = DateTime.Now.ToShortDateString();
        string item = this.TextBoxItemDescription.Text;
        string itemWeight = this.TextBoxItemWeight.Text;

        int destinationCityID = Convert.ToInt32(this.DropDownListDestinationCities.SelectedValue);
        string destinationCityName = this.DropDownListDestinationCities.SelectedItem.ToString();
        string destinationAddress = this.TextBoxAddress.Text;
        string destinationDate = DateTime.Now.AddDays(30).ToShortDateString();

        //חישוב המחיר
        CityService cs=new CityService();

        int collectingCenterID = collectingCity.GetCenterID();
        int destinationCenterID = cs.GetCenterIDByCityID(destinationCityID);
        int temp = destinationCenterID - collectingCenterID;

        if (temp < 0)
            temp *= -1;
        temp += 1;
        double price;
        price= 5 * Math.Log(double.Parse(itemWeight)) + 10 + (temp * 10);
        if (this.CheckBoxUrgent.Checked)
        {
            price += 10;
        }
        if (price < 20)
            price = 20;

        string sqlCommand = "INSERT INTO Orders (CollectingCityID,CollectingCityName,CollectingAddress,OrderingDate,DestinationCityID,DestinationCitName,DestinationAddress,DestinationDate,Item,ItemWeight,WorkerID,ClientID,Price,Status) VALUES (" + collectingCityName + ",'" + collectingCityName + "','" + collectingAddress + "','" + date + "'," + destinationCityID + ",'" + destinationCityName + "','" + destinationAddress + "','" + destinationDate + "','" + item + "'," + itemWeight + ",0," + clientID + "," + price + ",'New';";


    }
}