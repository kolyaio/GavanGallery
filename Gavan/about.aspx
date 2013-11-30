<%@ Page Title="Gavan - אודות" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Gavan.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
             <link rel="Stylesheet" type="text/css" href="/styles/about.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<% int id = 3; %>
       <h1 id="aboutHeader"><%=this.getDetails(id)[0]%></h1>
       <div id="about">
            <%=this.getDetails(id)[1]%>
       </div>
</asp:Content>
