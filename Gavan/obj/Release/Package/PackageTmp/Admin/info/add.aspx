﻿<%@ Page Title="Gavan -  הוספת דפי מידע" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"  ValidateRequest="false" CodeBehind="add.aspx.cs" Inherits="Gavan.Admin.info.add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/info_add.css" rel="stylesheet" type="text/css" />
    <script src="../../ckeditor/ckeditor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="info_add">
        <form action="add_send.aspx" method="post">
            <dl>
                <dt><label>שם התוכן:</label><input type="text" id="name" name="name" /></dt>
                <dt><textarea id="content_area" name="content_area" rows="10" cols="80"></textarea></dt>
                <script type="text/javascript">
                    CKEDITOR.replace('content_area', {
                        language: 'he',
                        uiColor: '#a1cff3',
                        height: '300',
                        width: '800'
                    });
                   
                </script>
                <dt><input name="submit" type="submit" value="שלח" /></dt>
            </dl>
        </form>
    </div>
</asp:Content>
