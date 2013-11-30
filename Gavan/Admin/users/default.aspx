<%@ Page Title="Gavan - פאנל משתמשים" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Gavan.Admin.users._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../Styles/users.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="usersForm" runat="server">
<asp:Repeater ID="rptContent" runat="server">
    <HeaderTemplate> 
        <table id="usersMembers"> 
        <tr>
            <th>ID</th>
            <th>שם</th>
            <th>מייל</th>
            <th>תפקיד</th>
            <th>כיתה</th>
            <th>עריכה</th>
            <th>מחיקה</th>
        </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%#DataBinder.Eval(Container.DataItem, "id") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "name") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "email") %></td>
            <td><%# this.makeRanks(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "status")))%></td>
            <td><%# this.makeAlefbet(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "grade")))%></td>
            <td><a href="delete.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>">מחיקה</a></td>
            <td><a href="edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>">עריכה</a></td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table> 
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
</form>
</asp:Content>
