<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagerPage.aspx.cs" Inherits="ManagerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
לפניך  רשימת העובדים אשר אינם פעילים:
    <br /><br />
    <asp:GridView ID="GridViewWorkers" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewWorkers_RowCommand">
        <Columns>
            <asp:BoundField DataField="WorkerID" HeaderText="קוד עובד" />
            <asp:BoundField DataField="FirstName" HeaderText="שם פרטי" />
            <asp:BoundField DataField="LastName" HeaderText="שם משפחה" />
            <asp:BoundField DataField="Phone" HeaderText="טלפון" />
            <asp:BoundField DataField="Address" HeaderText="כתובת" />
            <asp:BoundField DataField="ID" HeaderText="ת.ז" />
            <asp:ButtonField ButtonType="Button" CommandName="MakeWorkerActive" Text="הפוך לפעיל" />
        </Columns>
    </asp:GridView>
    <%if(this.GridViewWorkers.Rows.Count==0){ %>
    אין עובדים שאינם פעילים כרגע.
    <%} %>

    <br /><br /><br /><br />
    לפניך רשימת ההזמנות שעדיין לא בוצעו:
    <br /><br />
    <asp:GridView runat="server" ID="GridViewUnCompletedOrders" 
        AutoGenerateColumns="False" 
        onrowcommand="GridViewUnCompletedOrders_RowCommand">
    <Columns>
        <asp:BoundField DataField="OrderID" HeaderText="מזהה הזמנה" />
        <asp:BoundField DataField="CollectingCityName" HeaderText="עיר איסוף" />
        <asp:BoundField DataField="CollectingAddress" HeaderText="כתובת איסוף" />
        <asp:BoundField DataField="DestinationCityName" HeaderText="עיר יעד" />
        <asp:BoundField DataField="DestinationAddress" HeaderText="כתובת יעד" />
        <asp:BoundField DataField="OrderingDate" HeaderText="תאריך היווצרות ההזמנה" />
        <asp:BoundField DataField="Item" HeaderText="הפריט" />
        <asp:BoundField DataField="ItemWeight" HeaderText="משקל פריט" />
        <asp:ButtonField ButtonType="Button" CommandName="UnActiveOrder" 
            Text="בטל הזמנה זו" />
    </Columns>
</asp:GridView>




</asp:Content>

