<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginWorker.aspx.cs" Inherits="LoginWorker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Login ID="Login1" runat="server" FailureText="התחברות נכשלה" 
        LoginButtonText="התחבר" onauthenticate="Login1_Authenticate"  PasswordLabelText="סיסמה:" 
        RememberMeText="זכור אותי לפעם הבאה" TitleText="התחברות" 
        UserNameLabelText="שם משתמש - עובד:" 
        PasswordRequiredErrorMessage="הכנס סיסמה" 
        UserNameRequiredErrorMessage="הכנס שם משתמש">
    </asp:Login>

</asp:Content>

