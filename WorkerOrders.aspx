<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WorkerOrders.aspx.cs" Inherits="WorkerOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
לפניך מוצגת רשימה של הזמנות זמינות, בחר הזמנה אשר אתה רוצה לבצע.
<br /><br />
<asp:GridView runat="server" ID="GridViewAvailableOrders" 
        AutoGenerateColumns="False" 
        onrowcommand="GridViewAvailableOrders_RowCommand">
    <Columns>
        <asp:BoundField DataField="CollectingCityName" HeaderText="עיר איסוף" />
        <asp:BoundField DataField="CollectingAddress" HeaderText="כתובת איסוף" />
        <asp:BoundField DataField="DestinationCityName" HeaderText="עיר יעד" />
        <asp:BoundField DataField="DestinationAddress" HeaderText="כתובת יעד" />
        <asp:BoundField DataField="OrderingDate" HeaderText="תאריך היווצרות ההזמנה" />
        <asp:BoundField DataField="Item" HeaderText="הפריט" />
        <asp:BoundField DataField="ItemWeight" HeaderText="משקל פריט" />
        <asp:ButtonField ButtonType="Button" CommandName="ApplyOrder" 
            Text="קבל הזמנה" />
    </Columns>
</asp:GridView>
<br /><br /><br />
לפניך מוצגת רשימה של הזמנות אשר אישרת ועדיין לא ביצעת, אנא אשר את ההזמנות שביצעת.
<br /><br />
<asp:GridView runat="server" ID="GridViewInProgressOrders" 
        AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="CollectingCityName" HeaderText="עיר איסוף" />
        <asp:BoundField DataField="CollectingAddress" HeaderText="כתובת איסוף" />
        <asp:BoundField DataField="DestinationCityName" HeaderText="עיר יעד" />
        <asp:BoundField DataField="DestinationAddress" HeaderText="כתובת יעד" />
        <asp:BoundField DataField="OrderingDate" HeaderText="תאריך היווצרות ההזמנה" />
        <asp:BoundField DataField="Item" HeaderText="הפריט" />
        <asp:BoundField DataField="ItemWeight" HeaderText="משקל פריט" />
        <asp:ButtonField ButtonType="Button" CommandName="OrderDone" 
            Text="ביצעתי הזמנה" />
    </Columns>
</asp:GridView>




</asp:Content>

