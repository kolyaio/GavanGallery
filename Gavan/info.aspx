<%@ Page Title="Gavan - מידע" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="Gavan.info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/info.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="info">
    <% if(String.IsNullOrEmpty(Request.QueryString["id"])) {%>
    <asp:Repeater ID="rptContent" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><a href="info.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>"><%#DataBinder.Eval(Container.DataItem, "name") %></a></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
        </asp:Repeater>
        <div class="pages">
            <asp:Repeater ID="rptPages" runat="server" onitemcommand="rptPages_ItemCommand">
                <HeaderTemplate>
                <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:LinkButton id="btnPages" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server">
                            <%# Container.DataItem %>
                        </asp:LinkButton>
                    </li>    
                </ItemTemplate>
                <FooterTemplate>
                </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
            <% } else { %>
                    <h1><label runat="server" id="title"></label></h1>
                    <label runat="server" id="content"></label>
            <% } %>
        </div>
</asp:Content>
