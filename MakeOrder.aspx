<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MakeOrder.aspx.cs" Inherits="MakeOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%if (Session["UserName"] == null)
      { %>
    אנא התחבר על מנת לקבל את שירותינו
    <% } %>
    <%else
        { %>
    חקדחןכדםםןיקעםןעקשךל
    
    <br />
    <br />
    <br />

    בחר את העיר אליה תרצה לשלוח את הפריט
    <br />
    <asp:DropDownList ID="DropDownListDestinationCities" runat="server">
    </asp:DropDownList>
    <br />
    <br />

    הכנס את הכתובת אליה תרצה לשלוח את הפריט (רחוב + מספר)
    <br />
    <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>

    <br />
    <br />
    
    הכנס את תיאור הפריט
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    <br />
    <br />
    
    הכנס את משקל הפריט
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

    <br />
    <br />
    <br />

    <asp:Button ID="SubmitButton" runat="server" onclick="SubmitButton_Click" Text="הזמן משלוח" />

    <%} %>

</asp:Content>
