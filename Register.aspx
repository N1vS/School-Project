<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 25%;
            height: 97px;
            margin-right: 0px;
        }
        .style3
        {
            width: 79px;
        }
        .style4
        {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">













    <table class="style1" dir="rtl">
        <tr>
            <td class="style4">
                שם משתמש :</td>
            <td class="style3">
                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                סיסמה :</td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                אימות סיסמה :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPass2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td class="style4">
                אימייל :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                טלפון :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                עיר :
            </td>
            <td class="style3">
                <asp:DropDownList ID="DropDownListCities" runat="server" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Street :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxStreet" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />













</asp:Content>

