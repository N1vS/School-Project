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
    <%} %>

</asp:Content>

