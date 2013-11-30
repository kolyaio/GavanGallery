<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="forgot.aspx.cs" Inherits="Gavan.forgot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="Stylesheet" type="text/css" href="styles/forgot.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	<div id="forgot">
		<h1>שחכת את סיסמתך?</h1>
			<form id="Form1" action="forgot.aspx" method="post" runat="server">
				<dl>
					<dd><label for="email">הקלד את המייל שלך:<br /></label></dd>
					<dd style="font-size: 12px;margin-top: 5px;margin-bottom: 10px;">סיסמתך תשלח אליך לדואר האלקטרוני אם הוא קיים.</dd>
					<dt style="margin-bottom: 10px;"><input type="text" name="email" id="email" size="30" /></dt>
					<dt><input type="submit" name="submit" id="submit" value="שלח" /></dt>
				</dl>
			</form>
		</div>
</asp:Content>