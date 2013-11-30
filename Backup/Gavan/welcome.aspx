<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="Gavan.welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <p>שלום <%=name%>, <br />
        אנחנו שמחים שהצטרפת לאתרנו. <br />
        בתודה, <br />
        צוות האתר
        </p>
        <p>אתה תועבר לעמוד הראשי בעוד <span id="counter">5</span> שניות</p>
        <script type="text/javascript" src="Scripts/counter.js"> </script>
        <%  Response.AppendHeader("REFRESH", "5;URL=" + "/"); %>
</asp:Content>