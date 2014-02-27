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
        this.DropDownListDestinationCities.DataValueField = "CenterID";
        this.DropDownListDestinationCities.DataBind();
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {

        Response.Write("<script type=\"text/javascript\">if(confirm(\"אנא אשר את ביצוע השליחה\")==true){<%MakeTheOrder()%>}</script>");
        
    }
    private void MakeTheOrder()
    {


    }
}