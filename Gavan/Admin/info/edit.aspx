<%@ Page Title="Gavan - עריכת דפי מידע" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"  ValidateRequest="false" CodeBehind="edit.aspx.cs" Inherits="Gavan.Admin.info.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/info_add.css" rel="stylesheet" type="text/css" />
    <script src="../../ckeditor/ckeditor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="info_add">
    <%
        int id = 0;
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            id = Convert.ToInt32(Request.QueryString["id"]);    
    %>
        <form action="edit_act.aspx" method="post">
            <dl>
                <dt><label>שם התוכן:</label><input type="text" id="name" name="name" value="<%=this.getDetails(id)[0]%>"/></dt>
                <dt><textarea id="content_area" name="content_area" rows="10" cols="80"><%=this.getDetails(id)[1]%></textarea></dt>
                <dt><input type="hidden" value="<%=id%>" name="id"  id="id"/></dt>
                <script type="text/javascript">
                    CKEDITOR.replace('content_area', {
                        language: 'he',
                        uiColor: '#a1cff3',
                        height: '300',
                        width: '800'
                    });
                </script>
                <dt><input name="submit" type="submit" value="עדכן" /></dt>
            </dl>
        </form>
    </div>
</asp:Content>
