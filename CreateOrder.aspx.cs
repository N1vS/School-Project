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
            PopulateDestinationCitiesDropDown2();
            PopulateCollectingCitiesDropDown();
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

    public void PopulateDestinationCitiesDropDown2()
    {
        CityService cs = new CityService();
        this.DropDownListDestinationCities2.DataSource = cs.GetCitiesAndCenters();
        this.DropDownListDestinationCities2.DataTextField = "CityName";
        this.DropDownListDestinationCities2.DataValueField = "CityID";
        this.DropDownListDestinationCities2.DataBind();
        ListItem item = new ListItem("בחר עיר", "0");
        this.DropDownListDestinationCities2.Items.Add(item);
        this.DropDownListDestinationCities2.SelectedValue = "0";
    }

    public void PopulateCollectingCitiesDropDown()
    {
        CityService cs = new CityService();
        this.DropDownListCollectingCities.DataSource = cs.GetCitiesAndCenters();
        this.DropDownListCollectingCities.DataTextField = "CityName";
        this.DropDownListCollectingCities.DataValueField = "CityID";
        this.DropDownListCollectingCities.DataBind();
        ListItem item = new ListItem("בחר עיר", "0");
        this.DropDownListCollectingCities.Items.Add(item);
        this.DropDownListCollectingCities.SelectedValue = "0";
    }

    public int CalculatePrice(int num)
    {
        if (num == 1)
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
        else if (num == 2)
        {

            int collectingCityID = Convert.ToInt32(this.DropDownListCollectingCities.SelectedValue);
            City collectingCity = new City(collectingCityID);

            string itemWeight = this.TextBoxItemWeight2.Text;

            int destinationCityID = Convert.ToInt32(this.DropDownListDestinationCities2.SelectedValue);

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
            if (this.CheckBoxUrgent2.Checked)
            {
                price += 10;
            }
            if (price < 20)
                price = 20;
            int roundedPrice = Convert.ToInt32(price);
            return roundedPrice;
        }
        else return 0;
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

        int price = CalculatePrice(1);

        try
        {
            string sqlCommand = "INSERT INTO Orders (CollectingCityID,CollectingCityName,CollectingAddress,OrderingDate,DestinationCityID,DestinationCityName,DestinationAddress,DestinationDate,Item,ItemWeight,WorkerID,ClientID,Price,Status) VALUES (" + collectingCityID + ",'" + collectingCityName + "','" + collectingAddress + "','" + date + "'," + destinationCityID + ",'" + destinationCityName + "','" + destinationAddress + "','" + destinationDate + "','" + item + "'," + itemWeight + ",0," + clientID + "," + price + ",'New');";

            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            cmd.ExecuteNonQuery();
            myCon.Close();
            Response.Write("<script type=\"text/javascript\">alert('הזמנת המשלוח בוצעה בהצלחה')</script>");
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
            this.Label1.Text = "עלות המשלוח היא : "+CalculatePrice(1)+" שקלים";
        }
        catch
        {
            Response.Write("<script type=\"text/javascript\">alert('לא הוכנסו הנתונים המספיקים')</script>");
        }
    }

    protected void ButtonSubmit2_Click(object sender, EventArgs e)
    {
        int clientID = Convert.ToInt32(Session["UserID"]);

        Client orderingClient = new Client(clientID);
        City collectingCity = new City(orderingClient.GetCityID());
        string collectingCityName = this.DropDownListCollectingCities.SelectedItem.ToString();
        int collectingCityID = Convert.ToInt32(this.DropDownListCollectingCities.SelectedValue);
        string collectingAddress = this.TextBoxCollectingAddress.Text;

        string date = DateTime.Now.ToShortDateString();
        string item = this.TextBoxItemDescription2.Text;
        string itemWeight = this.TextBoxItemWeight2.Text;

        int destinationCityID = Convert.ToInt32(this.DropDownListDestinationCities.SelectedValue);
        string destinationCityName = this.DropDownListDestinationCities2.SelectedItem.ToString();
        string destinationAddress = this.TextBoxAddress2.Text;
        string destinationDate = DateTime.Now.AddDays(30).ToShortDateString();

        int price = CalculatePrice(2);

        try
        {
            string sqlCommand = "INSERT INTO Orders (CollectingCityID,CollectingCityName,CollectingAddress,OrderingDate,DestinationCityID,DestinationCityName,DestinationAddress,DestinationDate,Item,ItemWeight,WorkerID,ClientID,Price,Status) VALUES (" + collectingCityID + ",'" + collectingCityName + "','" + collectingAddress + "','" + date + "'," + destinationCityID + ",'" + destinationCityName + "','" + destinationAddress + "','" + destinationDate + "','" + item + "'," + itemWeight + ",0," + clientID + "," + price + ",'New');";

            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            cmd.ExecuteNonQuery();
            myCon.Close();
            Response.Write("<script type=\"text/javascript\">alert('הזמנת המשלוח בוצעה בהצלחה')</script>");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ButtonPrice2_Click(object sender, EventArgs e)
    {
        try
        {
            this.LabelPrice2.Text = "עלות המשלוח היא : " + CalculatePrice(2) + " שקלים";
        }
        catch
        {
            Response.Write("<script type=\"text/javascript\">alert('לא הוכנסו הנתונים המספיקים')</script>");
        }
    }


}