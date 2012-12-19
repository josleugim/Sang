<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.SangClient>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="blankspan">
    </div>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <div class="cuestionario">
        <img style="margin: 10px" src="../../Content/images/Info.png" alt="Imagen" />
        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>
        <%: Html.HiddenFor(model => model.SangClientID) %>
        <%: Html.HiddenFor(model => model.SangUserId)%>
        <%: Html.HiddenFor(model => model.UserName)%>
        <%: Html.HiddenFor(model => model.FirstName)%>
        <%: Html.HiddenFor(model => model.LastName)%>
        <%: Html.HiddenFor(model => model.CompleteName)%>
        <%: Html.HiddenFor(model => model.BirthDate)%>
        <%: Html.HiddenFor(model => model.Gender)%>
        <%: Html.HiddenFor(model => model.nMattressUsers)%>
        <%: Html.HiddenFor(model => model.Disorder1)%>
        <%: Html.HiddenFor(model => model.Disorder2)%>
        <%: Html.HiddenFor(model => model.Disorder3)%>
        <%: Html.HiddenFor(model => model.Disorder4)%>
        <%: Html.HiddenFor(model => model.Disorder5)%>
        <%: Html.HiddenFor(model => model.Disorder6)%>
        <%: Html.HiddenFor(model => model.Disorder7)%>
        <%: Html.HiddenFor(model => model.Disorder8)%>
        <%: Html.HiddenFor(model => model.RegisterDate)%>
        <table class="tableCuestion">
            <tr>
                <td>
                    <p>
                        <%: Html.LabelFor(model => model.Age) %>
                        :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.Age) %>
                </td>
                <td>
                    <p>
                        <%: Html.LabelFor(model => model.SecondaryEmail) %>
                        :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.SecondaryEmail) %>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.Age) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.SecondaryEmail) %>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        <%: Html.LabelFor(model => model.Address) %>
                        :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.Address) %>
                </td>
                <td>
                    <p>
                        <%: Html.LabelFor(model => model.Colony) %>
                        :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.Colony) %>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.Address) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.Colony) %>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        <%: Html.LabelFor(model => model.PostalCode) %>
                        :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.PostalCode) %>
                </td>
                <td>
                    <p>
                        <%: Html.LabelFor(model => model.Township) %>
                        :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.Township) %>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.PostalCode) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.Township) %>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        <%: Html.LabelFor(model => model.ShortState) %>
                        :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.ShortState) %>
                </td>
                <td>
                    <p>
                        <%: Html.LabelFor(model => model.HomePhone) %>
                        :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.HomePhone) %>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.ShortState) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.HomePhone) %>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        <%: Html.LabelFor(model => model.MovilPhone) %>
                        :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.MovilPhone) %>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.NewsLetter) %>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.NewsLetter) %>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.MovilPhone) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.NewsLetter) %>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:right">
                    <p>
                        <input type="submit" value="Continuar" />
                    </p>
                </td>
            </tr>
        </table>
        <% } %>
    </div>
</asp:Content>
