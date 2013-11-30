<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="pictures.aspx.cs" Inherits="Gavan.pictures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/pictures.css" rel="stylesheet" type="text/css" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pictureContainer">
         <div class="picture">
            <asp:Image ID="picture" runat="server" />
         </div>
        <h1><asp:Label ID="header" runat="server"></asp:Label></h1>
        <p>שם האומן:<asp:Label ID="author" runat="server"></asp:Label></p>
        <p><asp:Label ID="description" runat="server"></asp:Label></p>
        <p>צפיות:<asp:Label ID="views" runat="server"></asp:Label></p>
        <p>דרג:</p>
        <form action="pictures.aspx" method="post">
           <label>1</label> <input type="radio" name="rank" value="1" />
           <label>2</label> <input type="radio" name="rank" value="2" />
           <label>3</label> <input type="radio" name="rank" value="3" />
           <label>4</label> <input type="radio" name="rank" value="4" />
           <label>5</label> <input type="radio" name="rank" value="5" />
           <input type="submit" name="sub" />
        </form>

    </div>
</asp:Content>
