<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateOrder.aspx.cs" Inherits="CreateOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%if (Session["UserDefiner"] != "User")
  { %>
    אנא התחבר כמשתמש על מנת לקבל את שירותינו
    <br />
    <br />
    <br />
    לפניך מוצגת רשימת הערים בה החברה פועלת
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CityName" HeaderText="עיר" />
            <asp:BoundField DataField="CenterName" HeaderText="איזור" />
        </Columns>
    </asp:GridView>
    <% } %>
    <%else
    { %>

    <asp:DropDownList runat="server" ID="DropDownListChooseOrder" AutoPostBack="true">
    <asp:ListItem Text="משלוח מהבית (כתובת הרשמה)" Value="Home"></asp:ListItem>
    <asp:ListItem Text="משלוח מכתובת אחרת" Value="Other"></asp:ListItem>
    </asp:DropDownList>
    <br /><br />

    <%if (this.DropDownListChooseOrder.SelectedValue == "Home")
      { %>

    בחר את עיר היעד
    <br />
    <asp:DropDownList ID="DropDownListDestinationCities" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    הכנס את הכתובת אליה תרצה לשלוח (רחוב + מספר)
    <br />
    <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
    <br />
    <br />
    הכנס את תיאור הפריט
    <br />
    <asp:TextBox ID="TextBoxItemDescription" runat="server"></asp:TextBox>
    <br />
    <br />
    הכנס את משקל הפריט
    <br />
    <asp:TextBox ID="TextBoxItemWeight" runat="server"></asp:TextBox>
    <br />
    <br />
    האם המשלוח דחוף?(תוספת תשלום)
    <asp:CheckBox ID="CheckBoxUrgent" runat="server" />
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="ButtonPrice" runat="server" OnClick="ButtonPrice_Click" Text="חשב מחיר" />
    <br />
    <br />
    <asp:Button ID="ButtonSubmit" runat="server" Text="בצע משלוח" OnClick="ButtonSubmit_Click" />
    <%}
      else if (this.DropDownListChooseOrder.SelectedValue == "Other")
      {%>

      בחר את עיר המוצא
      <br />
      <asp:DropDownList ID="DropDownListCollectingCities" runat="server">
      </asp:DropDownList>
      <br /><br />
      רשום את כתובת המוצא (רחוב + מספר)
      <br />
      <asp:TextBox runat="server" ID="TextBoxCollectingAddress" />
      <br /><br />

       בחר את עיר היעד
    <br />
    <asp:DropDownList ID="DropDownListDestinationCities2" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    הכנס את הכתובת אליה תרצה לשלוח (רחוב + מספר)
    <br />
    <asp:TextBox ID="TextBoxAddress2" runat="server"></asp:TextBox>
    <br />
    <br />
    הכנס את תיאור הפריט
    <br />
    <asp:TextBox ID="TextBoxItemDescription2" runat="server"></asp:TextBox>
    <br />
    <br />
    הכנס את משקל הפריט
    <br />
    <asp:TextBox ID="TextBoxItemWeight2" runat="server"></asp:TextBox>
    <br />
    <br />
    האם המשלוח דחוף?(תוספת תשלום)
    <asp:CheckBox ID="CheckBoxUrgent2" runat="server" />
    <br />
    <br />
    <br />
    <asp:Label ID="LabelPrice2" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="ButtonPrice2" runat="server" Text="חשב מחיר" 
        onclick="ButtonPrice2_Click" />
    <br />
    <br />
    <asp:Button ID="ButtonSubmit2" runat="server" Text="בצע משלוח" 
        onclick="ButtonSubmit2_Click"/>




    <%}
    } %>
</asp:Content>

