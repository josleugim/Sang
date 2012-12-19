<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.Collection>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Collection</legend>

    <div class="display-label">CollectionName</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.CollectionName) %>
    </div>

    <div class="display-label">RegisterDate</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.RegisterDate) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.CollectionID }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
