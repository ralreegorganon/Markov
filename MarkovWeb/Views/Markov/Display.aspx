<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Behold, your masterpiece:</h2>
<p>
    <%= Html.TextArea("Output", TempData["output"] as string, 20, 80, null)%>
</p>

<%= Html.ActionLink("Create another!","Create") %>
</asp:Content>
