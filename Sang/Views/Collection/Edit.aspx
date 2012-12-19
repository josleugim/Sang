<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.Collection>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Collection</legend>

        <%: Html.HiddenFor(model => model.CollectionID) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.CollectionName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.CollectionName) %>
            <%: Html.ValidationMessageFor(model => model.CollectionName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.RegisterDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.RegisterDate) %>
            <%: Html.ValidationMessageFor(model => model.RegisterDate) %>
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
