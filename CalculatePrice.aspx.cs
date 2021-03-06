﻿using System;
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
        this.DropDownListCollectingCities.DataSource = cs.GetAllCities();
        this.DropDownListCollectingCities.DataTextField = "CityName";
        this.DropDownListCollectingCities.DataValueField = "CenterID";
        this.DropDownListCollectingCities.DataBind();
    }

    public void PopulateDestinationCitiesDropDown()
    {
        CityService cs = new CityService();
        this.DropDownListDestinationCities.DataSource = cs.GetAllCities();
        this.DropDownListDestinationCities.DataTextField = "CityName";
        this.DropDownListDestinationCities.DataValueField = "CenterID";
        this.DropDownListDestinationCities.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool urgent = this.CheckBoxUrgent.Checked;
        int collectingCenterID = int.Parse(this.DropDownListCollectingCities.SelectedValue);
        int destinationCenterID = int.Parse(this.DropDownListDestinationCities.SelectedValue);
        int temp = destinationCenterID - collectingCenterID;
        try
        {
            if (this.TextBoxWeight.Text != null)
            {
                int weight = Convert.ToInt32(this.TextBoxWeight.Text);
                if (temp < 0)
                    temp *= -1;
                temp += 1;
                double price;
                if (this.CheckBoxUrgent.Checked)
                {
                    price = 5 * Math.Log(weight) + 20 + (temp * 10);
                }
                else
                {
                    price = 5 * Math.Log(weight) + 10 + (temp * 10);
                }
                if (price < 20)
                    price = 20;
                Response.Write("<script type=\"text/javascript\">alert('עלות המשלוח היא " + price + " ש\"ח')</script>");
                PopulateCollectingCitiesDropDown();
                PopulateDestinationCitiesDropDown();
            }

        }
        catch { Response.Write("<script type=\"text/javascript\">alert('קלט לא תקין')</script>"); }
    }
}