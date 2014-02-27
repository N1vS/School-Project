<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Login ID="Login1" runat="server" BorderStyle="None" 
        FailureText="התחברות נכשלה" Height="198px" LoginButtonText="התחבר" 
        onauthenticate="Login1_Authenticate" onloginerror="Login1_LoginError" 
        PasswordLabelText="סיסמה :" PasswordRequiredErrorMessage="הכנס סיסמה" 
        RememberMeText="זכור אותי לפעם הבאה" TitleText="התחברות" 
        UserNameLabelText="שם משתמש :" UserNameRequiredErrorMessage="הכנס שם משתמש" 
        Width="398px" onloggedin="Login1_LoggedIn" VisibleWhenLoggedIn="False">
    </asp:Login>
</asp:Content>

