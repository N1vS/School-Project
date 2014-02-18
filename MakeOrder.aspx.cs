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
        PopulateCitiesGridView();
    }

    public void PopulateCitiesGridView()
    {
        CityService cs = new CityService();
        DataSet ds = cs.GetCitiesAndCenters();
        this.GridView1.DataSource = ds;
        this.GridView1.DataBind();
    }
}