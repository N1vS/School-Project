using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class ComplainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SendButton_Click(object sender, EventArgs e)
    {
        try
        {
            string userDefiner = "Anonymus";
            int userID = 0;
            if (Session["UserDefiner"] != null)
                userDefiner = Session["UserDefiner"].ToString();

            string sqlCommand = "INSERT INTO Complains (TheComplain,UserID,UserDefiner) VALUES('" + this.ComplainTextBox.Text + "'," + userID + ",'" + userDefiner + "');";

            OleDbConnection myCon = new OleDbConnection(Connect.getConnectionString());
            OleDbCommand cmd = new OleDbCommand(sqlCommand, myCon);
            myCon.Open();
            cmd.ExecuteNonQuery();
            myCon.Close();
            Response.Write("<script type=\"text/javascript\">alert('התלונה נשלחה בהצלחה')</script>)");
        }
        catch (OleDbException ex)
        {
            throw ex;
        }
    }
}