<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Gavan.Pictures.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/edit.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div id="editPicture">
    <%
        int PictureID = 0;
        if(!String.IsNullOrEmpty(Request.QueryString["id"]))
            PictureID = Convert.ToInt32(Request.QueryString["id"]);
    %>
		<form action="edit_act.aspx" id="formEdit" method="post">
			<dl>
                <dd><label>שם התמונה:</label></dd>
                <dt><input type="text" name="picname" id="picname" value="<%=this.getDetails(PictureID)[0]%>" /></dt>
                <dd><label>תיאור תמונה:</label></dd>
                <dt><textarea id="description" name="description" cols="30" rows="8"><%=this.getDetails(PictureID)[1]%></textarea></dt>
                <dt><input type="hidden" value="<%=PictureID%>" name="id"  id="id"/></dt>
				<dt><input type="submit" name="Submit" id="Submit" value="עדכן" /></dt>
			</dl>
		</form>
	</div>
</asp:Content>
