<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="studio.aspx.cs" Inherits="Gavan.studio" %>
<%@ Import Namespace="System.Data"%>
<%@ Import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/studio.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="order">
				<ul>
					<li><span class="titleOrder">מיון:</span></li>
                    <li>
			            <dl>
				            <dt><a href="studio.aspx">הכי חדש</a></dt>
				            <dt><a href="studio.aspx?sort=oldest">הכי ישן</a></dt>
				            <dt><a href="#mostrank">הכי מדורגים</a></dt>
				            <dt><a href="#mostpop">הכי פופולאריים</a></dt>
				            <dt><a href="studio.aspx?sort=byalphaup">לפי הא'-ב' סדר עולה</a></dt>
				            <dt><a href="studio.aspx?sort=byalphadown">לפי הא'-ב' סדר יורד</a></dt>
			            </dl>
                    </li>
				</ul>
			</div>
    <form id="contentForm" runat="server">    
    <asp:Repeater ID="rptContent" runat="server">
        <HeaderTemplate>
        <div class="images">
            <ul>
                <dl>
        </HeaderTemplate>
        <ItemTemplate>
            <dt><img src="<%#DataBinder.Eval(Container.DataItem,"path") %>" width="200" height="200" alt="<%#DataBinder.Eval(Container.DataItem,"name") %>" /></dt>
        </ItemTemplate>
        <FooterTemplate>
                </dl>
            </ul>
        </div>
        </FooterTemplate>
    </asp:Repeater>
    <div class="pages">
        <asp:Repeater ID="rptPages" runat="server" onitemcommand="rptPages_ItemCommand">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="btnPages"  CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server">
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
            <div class="clear"></div>
</asp:Content>
