<%@ Page Title="" Language="C#" MasterPageFile="~/Global.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Gavan.Pictures._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/pictures.css" rel="stylesheet" type="text/css" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pictureContainer">
        <h1><asp:Label ID="header" runat="server"></asp:Label></h1>
         <div class="picture">
            <asp:Image ID="picture" runat="server" />
         </div>
        <ul id="details">
            <li>שם האומן: <asp:Label ID="author" runat="server"></asp:Label></li>
            <li><asp:Label ID="description" runat="server"></asp:Label></li>
            <li>צפיות: <asp:Label ID="views" runat="server"></asp:Label></li>
            <li>דירוג: <asp:Label ID="rank" runat="server"></asp:Label> </li>
        <%
            string id = Request.QueryString["id"];
        %>
        <% if (Session["eid"] != null)
           { %>
            <li><a href="delete.aspx?id=<%=id%>">מחק תמונה</a></li>
            <li><a href="edit.aspx?id=<%=id%>">ערוך פרטי תמונה</a></li>
          <%  }  %>
        </ul>

        <% if (Session["eid"] != null)
           { %>
            <form method="post" action="ranking.aspx">
                <select name="ranking" id="ranking">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                </select>
               <input type="submit" name="sub" id="sub" value="דרג"  />
            </form>
          <%  }  %>
              <form id="contentForm" runat="server">    
                <asp:Repeater ID="rptContent" runat="server">
                    <HeaderTemplate>
                    <div class="comments">
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                                  <li>
                                    <div id="comment<%#DataBinder.Eval(Container.DataItem, "id")%>" class="comment">
                                        <dl>
                                            <dt class="author"><span class="id"><%#DataBinder.Eval(Container.DataItem, "id")%></span>: מגיב:<%#this.getName(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"userID"))) %></dt>
                                            <dt class="message"><%#DataBinder.Eval(Container.DataItem,"message") %></dt>
                                            <% if (Session["eid"] != null)
                                               {%>
                                               <dt class="delete">
                                               <input type="button" id="delete" value="מחק תגובה" onclick="window.open('/Pictures/Comments/delete.aspx?id=<%#DataBinder.Eval(Container.DataItem,"id") %>','_self');" /></dt>
                                            <% } %>
                                        </dl>     
                                    </div>
                                  </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                     </div>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="pages">
                    <asp:Repeater ID="rptPages" runat="server" onitemcommand="rptPages_ItemCommand">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:LinkButton ID="btnPages"  CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server">
                                 <%# Container.DataItem %>
                                </asp:LinkButton>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                </form>
          <% if (Session["eid"] != null)
                { %>
            <form action="/Pictures/Comments/?act=send" id="comment" method="post">
                   <ul>
                        <li><label>תגובה:</label></li>
                        <li><textarea rows="10" cols="50" id="message" name="message"></textarea></li>
                        <li><input type="submit" id="Submit" name="Submit" value="שלח תגובה"/></li>
                   </ul>
            </form>
          <% } %>
    </div>
</asp:Content>