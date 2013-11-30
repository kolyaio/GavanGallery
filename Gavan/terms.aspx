<%@ Page Title="Gavan - תנאי שימוש" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="terms.aspx.cs" Inherits="Gavan.terms" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link rel="Stylesheet" type="text/css" href="styles/terms.css"/>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<% int id = 2; %>
    	<h1 id="termsHeader"><%=this.getDetails(id)[0]%></h1>
       <%=this.getDetails(id)[1]%>
</asp:Content>
