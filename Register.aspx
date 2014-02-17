<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 221px;
        }
        .style8
        {
            width: 100%;
        }
        .style9
        {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p id="P1" dir="rtl" runat="server" style="font-size: 70px; font-family: Petel">
        הרשמה</p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <table class="style8" style="font-family: Arial">
        <tr>
            <td class="style9">
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="TextBoxUserName" Display="Dynamic" 
                    ErrorMessage="הכנס שם משתמש בן 6-24 תווים" ForeColor="Red" MaximumValue="24" 
                    MinimumValue="6">*</asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ControlToValidate="TextBoxUserName"
                    ErrorMessage="הכנס שם משתמש" ForeColor="Red" Display="Dynamic">  *</asp:RequiredFieldValidator>
                שם משתמש :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:RangeValidator ID="RangeValidator2" runat="server" 
                    ControlToValidate="TextBoxPass" Display="Dynamic" 
                    ErrorMessage="הכנס סיסמה בת 6-24 תווים" ForeColor="Red" MaximumValue="6" 
                    MinimumValue="24">*</asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPass"
                    ErrorMessage="הכנס סיסמה" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                סיסמה :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:RangeValidator ID="RangeValidator3" runat="server" 
                    ControlToValidate="TextBoxPass2" Display="Dynamic" 
                    ErrorMessage="הכנס אימות סיסמה בן 6-24 תווים" ForeColor="Red" MaximumValue="6" 
                    MinimumValue="24">*</asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPass2"
                    ErrorMessage="הכנס אימות סיסמה" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                אימות סיסמה :
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPass2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBoxEmail" Display="Dynamic" 
                    ErrorMessage="הכנס אימייל תקין" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxEmail"
                    ErrorMessage="הכנס אימייל" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                אימייל :
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBoxPhone" Display="Dynamic" 
                    ErrorMessage="הכנס טלפון תקין" ForeColor="Red" ValidationExpression="d{7}">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPhone"
                    ErrorMessage="הכנס טלפון" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
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
            <td class="style9">
                עיר :
            </td>
            <td class="style3">
                <asp:DropDownList ID="DropDownListCities" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxAddress"
                    ErrorMessage="הכנס רחוב" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
                כתובת : (רחוב + מספר)</td>
            <td class="style3">
                <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style9">
            </td>
            <td>
                <asp:Button ID="ButtonSend" runat="server" Text="הרשם" OnClick="ButtonSend_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
