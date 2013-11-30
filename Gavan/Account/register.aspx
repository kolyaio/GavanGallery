<%@ Page Title="Gavan - הרשמה" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Gavan.Account.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="Stylesheet" type="text/css" href="Styles/register.css"/>
        <script src="../Scripts/jquery.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="register_form">
	<h1>טופס הרשמה</h1>
		<form id="Form1" action="register.aspx" method="post" onsubmit="return checkForm()" runat="server" autocomplete="off">
			<ul>
				<li class="name">
					<label for="full_Name">שם מלא:</label><br />
					<input type="text" name="name" id="name" />
				</li>
				<li class="studstaff">
					<label for="studstaff">האם הנך הוא:</label><br />
					<input type="radio" name="studstaff"  value="1" checked="checked" />
					<label for="student">תלמיד</label>
					<input type="radio" name="studstaff" value="2" />
					<label for="staff">איש צוות</label>
				</li>
				<li id="gradeli">
						<label for="grade">כיתה:</label>
						<select name="grade" id="grade">
							<option value="1">א'</option>
							<option value="2">ב'</option>
							<option value="3">ג'</option>
							<option value="4">ד'</option>
							<option value="5">ה'</option>
							<option value="6">ו'</option>
							<option value="7">ז'</option>
							<option value="8">ח'</option>
							<option value="9">ט'</option>
							<option value="10">י'</option>
							<option value="11">יא'</option>
							<option value="12">יב'</option>
						</select>
				</li>
				<li>
					<label for="email">מייל:</label><br />
					<input type="text" name="email" id="email" />
				</li>
				<li>
					<label for="password">סיסמה:</label><br />
					<input type="password" name="password" id="password" />
				</li>
				<li>
					<label for="confirmpass">אישור סיסמה:</label><br />
					<input type="password" name="confirmpass" id="confirmpass" />
				</li>
				<li>
					<input type="checkbox" name="agree" id="agree" value="1" /><label for="terms">אני מסכים ל<a href="../terms.aspx" target="_blank">תקנון</a></label>
				</li>
				<li>
					<ul class="buttons">
						<li><input type="submit" name="Submit" id="Submit" value="הרשם" onserverclick="Submit_ServerClick"  runat="server" /></li>
						<li><input type="reset" name="reset" id="reset" value="אפס" /></li>
					</ul>
                    <div class="clear"></div>
				</li>
			</ul>
            <div class="clear"></div>
            <div class="empty"></div>
		</form>
	</div>
    <script type="text/javascript" src="../Scripts/checkForm.js"></script> 
</asp:Content>