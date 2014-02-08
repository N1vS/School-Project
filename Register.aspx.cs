using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        PopulateCitiesDropDown();
    }

    public void PopulateCitiesDropDown()
    {
        CityService cs = new CityService();
        this.DropDownListCities.DataSource = cs.GetAllCities();
        this.DropDownListCities.DataTextField = "CityName";
        this.DropDownListCities.DataValueField = "CityID";
        this.DropDownListCities.DataBind();
    }

    protected void ButtonSend_Click(object sender, EventArgs e)
    {
        string userName = this.TextBoxUserName.Text;
        string pass = this.TextBoxPass.Text;
        string passVerification = this.TextBoxPass2.Text;
        string email = this.TextBoxEmail.Text;
        string phone = this.DropDownList1.Text + this.TextBoxPhone.Text;
        string city = this.DropDownListCities.Text;
        string street = this.TextBoxStreet.Text;
        int cityID = Convert.ToInt32(this.DropDownListCities.SelectedValue);

        City userCity = new City();
        userCity.SetCityID(cityID);
        userCity.SetCityName(city);
        CityService cs = new CityService();
        userCity.SetCenterID(cs.GetCenterIDByCityID(cityID));

        string sqlCommand="INSERT INTO Clients VALUES('CityID="+cityID+",UserName="+userName+",Pass="+pass+",Phone="+phone+",Email="+email+",Street="+street+"');";//FIX it

    }
}