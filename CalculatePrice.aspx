<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CalculatePrice.aspx.cs" Inherits="CalculatePrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
בחר את עיר המוצא
<br />
    <asp:DropDownList ID="DropDownListCollectingCities" runat="server">
    </asp:DropDownList>
    <br /><br />
    בחר את עיר היעד
    <br />
    <asp:DropDownList ID="DropDownListDestinationCities" runat="server">
    </asp:DropDownList>
    <br /><br />
    הכנס את משקל הפריט
    <br />
    <asp:TextBox ID="TextBoxWeight" runat="server" />
    <br /><br />
    <asp:Button ID="Button1" runat="server" Text="חשב" onclick="Button1_Click" />
</asp:Content>
