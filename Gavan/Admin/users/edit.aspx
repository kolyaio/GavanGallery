<%@ Page Title="Gavan -  עריכת משתמשים" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="edit.aspx.cs" Inherits="Gavan.Admin.users.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/edit.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/login.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        int id = 0;
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            id = Convert.ToInt32(Request.QueryString["id"]);    
    %>
<div id="edit_form">
		<form action="edit_act.aspx" method="post" onsubmit="return checkForm()" autocomplete="off">
			<ul>
				<li class="name">
					<label for="full_Name">שם מלא:</label><br/ />
					<input type="text" name="name" id="name" value="<%=this.getDataFromDB(id)[0]%>" />
                    <input type="hidden" name="id" id="id" value="<%=Request.QueryString["id"] %>" />
				</li>
				<li class="studstaff">
                <% int status = Convert.ToInt32(this.getDataFromDB(id)[2]); %>

					<label for="studstaff">האם הנך הוא:</label><br/ />
					<input type="radio" name="studstaff"  value="1"  <% if (status == 1) { %>  checked="checked" <% } %>/>
					<label for="student">תלמיד</label><br />
					<input type="radio" name="studstaff" value="2"  <% if (status == 2) { %>  checked="checked" <% } %> />
					<label for="staff">איש צוות</label><br />
                    <input type="radio" name="studstaff" value="3"  <% if (status == 3) { %>  checked="checked" <% } %> />
					<label for="staff">מנהל אתר</label>
				</li>
                 <% int grade = Convert.ToInt32(this.getDataFromDB(id)[3]); %>
				<li id="gradeli">
						<label for="grade">כיתה:</label>
						<select name="grade" id="grade">
							<option value="1" <% if (grade == 1) { %>  selected="selected" <% } %>>א'</option>
							<option value="2"  <% if (grade == 2) { %>  selected="selected" <% } %>>ב'</option>
							<option value="3"  <% if (grade == 3) { %>  selected="selected" <% } %>>ג'</option>
							<option value="4"  <% if (grade == 4) { %>  selected="selected" <% } %>>ד'</option>
							<option value="5"  <% if (grade == 5) { %>  selected="selected" <% } %>>ה'</option>
							<option value="6"  <% if (grade == 6) { %>  selected="selected" <% } %>>ו'</option>
							<option value="7"  <% if (grade == 7) { %>  selected="selected" <% } %>>ז'</option>
							<option value="8"  <% if (grade == 8) { %>  selected="selected" <% } %>>ח'</option>
							<option value="9"  <% if (grade == 9) { %>  selected="selected" <% } %>>ט'</option>
							<option value="10"  <% if (grade == 10) { %>  selected="selected" <% } %>>י'</option>
							<option value="11"  <% if (grade == 11) { %>  selected="selected" <% } %>>יא'</option>
							<option value="12"  <% if (grade == 12) { %>  selected="selected" <% } %>>יב'</option>
						</select>
				</li>
				<li>
					<label for="email">מייל:</label><br/ />
					<input type="text" name="email" id="email" value="<%=this.getDataFromDB(id)[1]%>" />
				</li>
				<li>
					<label for="password">סיסמה:</label><br/ />
					<input type="password" name="password" id="password" />
				</li>
				<li>
					<label for="confirmpass">אישור סיסמה:</label><br/ />
					<input type="password" name="confirmpass" id="confirmpass" />
				</li>
				<li>
					<ul class="buttons">
						<li><input type="submit" name="Submit" id="Submit" value="ערוך"  /></li>
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
