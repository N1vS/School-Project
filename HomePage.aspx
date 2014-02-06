<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<p dir="rtl">
אתר חברת השליחויות של ניב.
</p>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CityName" HeaderText="עיר" />
            <asp:BoundField DataField="CenterName" HeaderText="איזור" />
        </Columns>
    </asp:GridView>


</asp:Content>

