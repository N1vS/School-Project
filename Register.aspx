<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 221px;
            
        }
        .style8
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p id="P1" dir="rtl" runat="server" style="font-size:45;">הרשמה</p>
    <table class="style8">
        <tr>
            <td class="style6">
                שם משתמש :</td>
            <td class="style3">
                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                סיסמה :</td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                אימות סיסמה :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPass2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td class="style7">
                אימייל :
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="style6">
                טלפון :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                <asp:Label runat="server" ID="LabelMakaf" Text="-"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True">02</asp:ListItem>
                    <asp:ListItem Value="03">03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>050</asp:ListItem>
                    <asp:ListItem>052</asp:ListItem>
                    <asp:ListItem>053</asp:ListItem>
                    <asp:ListItem>054</asp:ListItem>
                    <asp:ListItem>055</asp:ListItem>
                    <asp:ListItem>057</asp:ListItem>
                    <asp:ListItem>058</asp:ListItem>
                    <asp:ListItem>077</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                עיר :
            </td>
            <td class="style3">
                <asp:DropDownList ID="DropDownListCities" runat="server" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                רחוב :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxStreet" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="ButtonSend" runat="server" Text="הרשם" />
            </td>
        </tr>
    </table>

    
</asp:Content>

