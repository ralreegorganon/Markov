<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MarkovWeb.Models.MarkovChain>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create your masterpiece!</h2>
    <% using (Html.BeginForm()) {%>
        <fieldset>
            <legend>Markov Generator</legend>
            
                <p><label for="StartWord">Starting Word:</label></p>
                <%= Html.TextBox("StartWord") %>

                <p><label for="SourceText">Source Text:</label></p>
                <%= Html.TextArea("SourceText",string.Empty,20,80,40) %>

                <p><input type="submit" value="Create" /></p>
        </fieldset>
    <% } %>
</asp:Content>

