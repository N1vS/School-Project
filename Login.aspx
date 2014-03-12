<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:DropDownList ID="DropDownListLoginChoose" runat="server" AutoPostBack="true">
<asp:ListItem Value="User" Text="התחבר כמשתמש"></asp:ListItem>
<asp:ListItem Value="Worker" Text="התחבר כעובד"></asp:ListItem>
</asp:DropDownList>
<br />
<%if (this.DropDownListLoginChoose.SelectedValue == "User")
  { %>
    <asp:Login ID="Login1" runat="server" BorderStyle="None" 
        FailureText="התחברות נכשלה" Height="198px" LoginButtonText="התחבר" 
        onauthenticate="Login1_Authenticate" onloginerror="Login1_LoginError" 
        PasswordLabelText="סיסמה :" PasswordRequiredErrorMessage="הכנס סיסמה" 
        RememberMeText="זכור אותי לפעם הבאה" TitleText="התחברות" 
        UserNameLabelText="שם משתמש :" UserNameRequiredErrorMessage="הכנס שם משתמש" 
        Width="398px" onloggedin="Login1_LoggedIn" VisibleWhenLoggedIn="False">
    </asp:Login>
    <%}
  else if (this.DropDownListLoginChoose.SelectedValue == "Worker")
  { %>  
    <asp:Login ID="Login2" runat="server" BorderStyle="None" 
        FailureText="התחברות נכשלה" Height="198px" LoginButtonText="התחבר" 
        onauthenticate="Login2_Authenticate" onloginerror="Login2_LoginError" 
        PasswordLabelText="סיסמה :" PasswordRequiredErrorMessage="הכנס סיסמה" 
        RememberMeText="זכור אותי לפעם הבאה" TitleText="התחברות" 
        UserNameLabelText="שם משתמש - עובד :" UserNameRequiredErrorMessage="הכנס שם משתמש" 
        Width="398px" onloggedin="Login2_LoggedIn" VisibleWhenLoggedIn="False">
    </asp:Login>
    <%} %>
</asp:Content>

