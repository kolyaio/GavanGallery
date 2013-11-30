<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="Gavan.upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="Stylesheet" type="text/css" href="Styles/upload.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div id="upload">
    <div id="message" runat="server"></div>
		<form action="upload.aspx" id="uploadForm" method="post" enctype="multipart/form-data" runat="server">
			<dl>
                <dd><label>שם התמונה:</label></dd>
                <dt><input type="text" name="picname" id="picname"/></dt>
                <dd><label>תיאור תמונה:</label></dd>
                <dt><textarea id="description" name="description" cols="30" rows="8"></textarea></dt>
				<dd><label for="uploafile">העלאת תמונה</label></dd>
				<dt><input type="file" name="fileload" id="fileload" class="fileload"  runat="server" /></dt>
				<dt><input type="submit" name="Submit" id="Submit" value="העלה" onserverclick="Submit_ServerClick" runat="server" /></dt>
			</dl>
		</form>
	</div>
</asp:Content>