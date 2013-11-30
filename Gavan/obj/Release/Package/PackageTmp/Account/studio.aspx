<%@ Page Title="Gavan - הסטודיו שלי" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="studio.aspx.cs" Inherits="Gavan.Account.studio" %>
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
				            <dt <% if (Request.QueryString["sort"] == null) { %>  class="sort-selected" <% } %>><a href="default.aspx">הכי חדש</a></dt>
				            <dt <% if (Request.QueryString["sort"] == "oldest") { %>  class="sort-selected" <% } %>><a href="default.aspx?sort=oldest">הכי ישן</a></dt>
				            <dt <% if (Request.QueryString["sort"] == "mostrank") { %> class="sort-selected" <% } %>><a href="default.aspx?sort=mostrank">הכי מדורגים</a></dt>
				            <dt <% if (Request.QueryString["sort"] == "mostpop") { %>  class="sort-selected" <% } %>><a href="default.aspx?sort=mostpop">הכי פופולאריים</a></dt>
				            <dt <% if (Request.QueryString["sort"] == "byalphaup") { %>  class="sort-selected" <% } %>><a href="default.aspx?sort=byalphaup">לפי הא'-ב' סדר עולה</a></dt>
				            <dt <% if (Request.QueryString["sort"] == "byalphadown") { %>  class="sort-selected" <% } %>><a href="default.aspx?sort=byalphadown">לפי הא'-ב' סדר יורד</a></dt>
			            </dl>
                    </li>
				</ul>
			</div>
            <div id="buttons">
                    <input type="button" name="upload" id="upload" value="העלאה תמונה" onclick="window.location = 'upload.aspx';" />
                    <input type="button" name="edit" id="edit" value="ערוך פרטים" onclick="window.location = 'edit.aspx';" />
            </div>
    <form id="contentForm" runat="server">    
    <asp:Repeater ID="rptContent" runat="server">
        <HeaderTemplate>
        <div class="images">
            <ul>
                <dl>
        </HeaderTemplate>
        <ItemTemplate>
                        <dt><a href="http://<%=Request.Url.Authority %>/Pictures/?id=<%#DataBinder.Eval(Container.DataItem,"id") %>"><img src="http://<%=Request.Url.Authority %>/<%#DataBinder.Eval(Container.DataItem,"path") %>" width="200" height="200" alt="<%#DataBinder.Eval(Container.DataItem,"name") %>" /></a></dt>
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
