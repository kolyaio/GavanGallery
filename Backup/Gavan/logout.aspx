<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="Gavan.logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="logout">
            <h3>התנקת בהצלחה!</h3>
            <p>אתה תועבר לעמוד הראשי בעוד <span id="counter">5</span> שניות</p>
            <script type="text/javascript" src="Scripts/counter.js"> </script>
            <%  Response.AppendHeader("REFRESH", "5;URL=" + "/"); %>
        </div>
</asp:Content>
