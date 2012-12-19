<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Sang.Models.Collection>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            CollectionName
        </th>
        <th>
            RegisterDate
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.CollectionName) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.RegisterDate) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.CollectionID }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.CollectionID }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.CollectionID }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
