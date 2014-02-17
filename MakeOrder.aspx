<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MakeOrder.aspx.cs" Inherits="MakeOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%if (Session["UserName"] == null)
  { %>
  
      אנא התחבר על מנת לקבל את שירותינו

     
     <% } %>

     <%else
    { %>
    חקדחןכדםםןיקעםןעקשךל
     <%} %>
</asp:Content>

