<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClientOrders.aspx.cs" Inherits="ClientOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br /><br /><br />
לפניך מוצגת רשימה של הזמנות אשר אישרת ועדיין לא ביצעת, אנא אשר את ההזמנות שביצעת.
<br /><br />
<asp:GridView runat="server" ID="GridViewInProgressOrders" 
        AutoGenerateColumns="False" 
        onrowcommand="GridViewInProgressOrders_RowCommand">
    <Columns>
        <asp:BoundField DataField="OrderID" HeaderText="מזהה הזמנה" />
        <asp:BoundField DataField="CollectingCityName" HeaderText="עיר איסוף" />
        <asp:BoundField DataField="CollectingAddress" HeaderText="כתובת איסוף" />
        <asp:BoundField DataField="DestinationCityName" HeaderText="עיר יעד" />
        <asp:BoundField DataField="DestinationAddress" HeaderText="כתובת יעד" />
        <asp:BoundField DataField="OrderingDate" HeaderText="תאריך היווצרות ההזמנה" />
        <asp:BoundField DataField="Item" HeaderText="הפריט" />
        <asp:BoundField DataField="ItemWeight" HeaderText="משקל פריט" />
        <asp:ButtonField ButtonType="Button" CommandName="CancelOrder" 
            Text="איני רוצה שהזמנה זו תתבצע" />
    </Columns>
</asp:GridView>

<br /><br /><br />
לפניך מוצגת רשימת ההזמנות שביצעת, אם חלה טעות ולא ביצעת את ההזמנה אנא דווח
<br /><br />
<asp:GridView runat="server" ID="GridViewDoneOrders" 
        AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="OrderID" HeaderText="מזהה הזמנה" />
        <asp:BoundField DataField="CollectingCityName" HeaderText="עיר איסוף" />
        <asp:BoundField DataField="CollectingAddress" HeaderText="כתובת איסוף" />
        <asp:BoundField DataField="DestinationCityName" HeaderText="עיר יעד" />
        <asp:BoundField DataField="DestinationAddress" HeaderText="כתובת יעד" />
        <asp:BoundField DataField="OrderingDate" HeaderText="תאריך היווצרות ההזמנה" />
        <asp:BoundField DataField="Item" HeaderText="הפריט" />
        <asp:BoundField DataField="ItemWeight" HeaderText="משקל פריט" />
    </Columns>
</asp:GridView>

</asp:Content>

