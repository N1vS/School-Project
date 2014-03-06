<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MakeOrder.aspx.cs" Inherits="MakeOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (Session["UserDefiner"]!="User")
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
    <br /><br />
    הכנס את כתובת היעד
    <br />
    <asp:TextBox ID="TextBoxAddress" runat="server">
    </asp:TextBox>
    <br /><br />
    הכנס את תיאור הפריט
    <br />
    <asp:TextBox ID="TextBoxItemDescription" runat="server">
    </asp:TextBox>
    <br /><br />
    הכנס את משקל הפריט
    <br />
    <asp:TextBox ID="TextBoxItemWeight" runat="server">
    </asp:TextBox>
    <br /><br />
    האם המשלוח דחוף?(תוספת תשלום)
    <asp:CheckBox ID="CheckBoxUrgent" runat="server" />
    <br /><br />
    <asp:Button ID="ButtonSubmit" runat="server" Text="בצע משלוח" onclick="ButtonSubmit_Click" />
    <%} %>
</asp:Content>
