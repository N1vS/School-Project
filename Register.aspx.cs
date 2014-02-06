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
        this.DropDownListCities.DataBind();
    }

}