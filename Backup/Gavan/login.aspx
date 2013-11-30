<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Gavan.login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="login">
		<form autocomplete="off" action="login.aspx" method="post" runat="server">
		    <dl>
			    <dd><label for="email">מייל:</label></dd>
			    <dt class="dtmail"><input type="text" name="email" id="email" size="30"/></dt>
			    <dd><label for="password">סיסמה:</label></dd>
			    <dt><input type="password" name="password" id="password" size="30" /></dt>
			    <dt><input type="submit" name="submit" id="submit" value="התחבר"/></dt>
			    <dt><a href="register.aspx">אינך רשום?</a></dt>
			    <dt><a href="forgot.aspx">שחכת את סיסמתך?</a></dt>
		    </dl>
	    </form>
    </div>
</asp:Content>