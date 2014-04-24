using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class CreateOrder : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateDestinationCitiesDropDown();
            PopulateCitiesGridView();
        }
    }

    public void PopulateCitiesGridView()
    {
        CityService cs = new CityService();
        DataSet ds = cs.GetCitiesAndCenters();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }
    public void PopulateDestinationCitiesDropDown()
    {
        CityService cs = new CityService();
        this.DropDownListDestinationCities.DataSource = cs.GetCitiesAndCenters();
        this.DropDownListDestinationCities.DataTextField = "CityName";
        this.DropDownListDestinationCities.DataValueField = "CityID";
        this.DropDownListDestinationCities.DataBind();
        ListItem item = new ListItem("בחר עיר", "0");
        this.DropDownListDestinationCities.Items.Add(item);
        this.DropDownListDestinationCities.SelectedValue = "0";
    }

    public int CalculatePrice()
    {
        int clientID = Convert.ToInt32(Session["UserID"]);

        Client orderingClient = new Client(clientID);
        City collectingCity = new City(orderingClient.GetCityID());

        string itemWeight = this.TextBoxItemWeight.Text;

        int destinationCityID = Convert.ToInt32(this.DropDownListDestinationCities.SelectedValue);

        //חישוב המחיר
        CityService cs = new CityService();

        int collectingCenterID = collectingCity.GetCenterID();
        int destinationCenterID = cs.GetCenterIDByCityID(destinationCityID);
        int temp = destinationCenterID - collectingCenterID;

        if (temp < 0)
            temp *= -1;
        temp += 1;
        double price;
        price = 5 * Math.Log(double.Parse(itemWeight)) + 10 + (temp * 10);
        if (this.CheckBoxUrgent.Checked)
        {
            price += 10;
        }
        if (price < 20)
            price = 20;
        int roundedPrice = Convert.ToInt32(price);
        return roundedPrice;
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

        int price = CalculatePrice();

        try
        {
            string sqlCommand = "INSERT INTO Orders (CollectingCityID,CollectingCityName,CollectingAddress,OrderingDate,DestinationCityID,DestinationCityName,DestinationAddress,DestinationDate,Item,ItemWeight,WorkerID,ClientID,Price,Status) VALUES (" + collectingCityID + ",'" + collectingCityName + "','" + collectingAddress + "','" + date + "'," + destinationCityID + ",'" + destinationCityName + "','" + destinationAddress + "','" + destinationDate + "','" + item + "'," + itemWeight + ",0," + clientID + "," + price + ",'New');";

            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            cmd.ExecuteNonQuery();
            myCon.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void ButtonPrice_Click(object sender, EventArgs e)
    {
        try
        {
            this.Label1.Text = "The delivery price is : " + CalculatePrice() + " Sheqels";
        }
        catch
        {
            Response.Write("<script type=\"text/javascript\">alert('לא הוכנסו הנתונים המספיקים')</script>");
        }
    }
}