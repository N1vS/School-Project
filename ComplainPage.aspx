<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ComplainPage.aspx.cs" Inherits="ComplainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    אנא כתוב את תלונותיך כאן (מקסימום 200 תווים)
    <br /><br />
    <asp:TextBox ID="ComplainTextBox" runat="server" Height="100px" TextMode="MultiLine" Width="400px" MaxLength="200"></asp:TextBox>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ComplainTextBox" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="[\d\w]{10,200}">אנא הכנס טקסט שגודלו 10-200 תווים</asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ComplainTextBox" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">אנא הכנס טקסט שגודלו 10-200 תווים</asp:RequiredFieldValidator>
    <br /><br />
    <asp:Button ID="SendButton" Text="שלח" runat="server" OnClick="SendButton_Click" />
</asp:Content>

