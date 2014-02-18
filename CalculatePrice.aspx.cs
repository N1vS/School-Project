using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CalculatePrice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateCollectingCitiesDropDown();
            PopulateDestinationCitiesDropDown();
        }
    }

    public void PopulateCollectingCitiesDropDown()
    {
        CityService cs = new CityService();
        this.DropDownListCollectingCities.DataSource = cs.GetCitiesAndCenters();
        this.DropDownListCollectingCities.DataTextField = "CityName";
        this.DropDownListCollectingCities.DataValueField = "CenterID";
        this.DropDownListCollectingCities.DataBind();
    }

    public void PopulateDestinationCitiesDropDown()
    {
        CityService cs = new CityService();
        this.DropDownListDestinationCities.DataSource = cs.GetCitiesAndCenters();
        this.DropDownListDestinationCities.DataTextField = "CityName";
        this.DropDownListDestinationCities.DataValueField = "CenterID";
        this.DropDownListDestinationCities.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool urgent = this.CheckBoxUrgent.Checked;
        int collectingCenterID = int.Parse(this.DropDownListCollectingCities.SelectedValue);
        int destinationCenterID = int.Parse(this.DropDownListDestinationCities.SelectedValue);
        int sub = destinationCenterID - collectingCenterID;
        int price=0;
        if (this.TextBoxWeight.Text != null)
        {

            int weight = Convert.ToInt32(this.TextBoxWeight.Text);
            switch (sub)
            {
                case 0: price =Convert.ToInt32(5*Math.Log(weight)+15);
                    break;
                case 1:
                case -1: price =Convert.ToInt32( 5*Math.Log(weight)+20);
                    break;
                case 2:
                case -2: price = Convert.ToInt32(5*Math.Log(weight)+30);
                    break;
                default:
                    break;
            }
            if (urgent)
                price =Convert.ToInt32(price*1.3);
            Response.Write("<script type=\"text/javascript\">alert('עלות המשלוח היא " + price + " ש\"ח')</script>");
            PopulateCollectingCitiesDropDown();
            PopulateDestinationCitiesDropDown();
        }
    }
}