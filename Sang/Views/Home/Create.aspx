<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.SangClient>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
        <!-- DatePicker -->
    <script src="../../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.ui.widget.js" type="text/javascript"></script>
        <!-- DatePicker -->
    <script type="text/javascript">
        $(function () {
            $("#from").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 2,
                onSelect: function (selectedDate) {
                    $("#to").datepicker("option", "minDate", selectedDate);
                }
            });
        });
    </script>
    <div class="blankspan">
    </div>
    <% using (Html.BeginForm()){ %>
    <div class="cuestionario">
    <img style="margin: 10px" src="../../Content/images/Info.png" alt="Imagen" />

    <%: Html.HiddenFor(model => model.SangUserId) %>
    <%: Html.HiddenFor(model => model.nMattressUsers) %>
    <%: Html.HiddenFor(model => model.UserType) %>
    <%: Html.HiddenFor(model => model.HospitalId) %>

    <table class="tableCuestion">
     <tr>
      <td>
                    <p><%: Html.LabelFor(model => model.UserName) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.UserName) %>
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.FirstName) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.FirstName) %>
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.LastName) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.LastName) %>
                </td>
     </tr>
     <tr>
      <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.UserName) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.FirstName) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.LastName) %>
                </td>
     </tr>
     <tr>
      <td>
                    <p><%: Html.LabelFor(model => model.BirthDate) %> :</p>
                </td>
                <td>
                    <%: Html.TextBoxFor(model => model.BirthDate, new { id="from"})%>
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.SecondaryEmail) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.SecondaryEmail) %>
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.Address) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.Address) %>
                </td>
     </tr>
     <tr>
      <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.BirthDate) %>
                    <%--<input type="text" id="from" name="from" />--%>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.SecondaryEmail) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.Address) %>
                </td>
     </tr>
     <tr>
      <td>
                   <p><%: Html.LabelFor(model => model.Colony) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.Colony) %>
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.PostalCode) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.PostalCode) %>
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.Township) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.Township) %>
                </td>
     </tr>
     <tr>
      <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.Colony) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.PostalCode) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.Township) %>
                </td>
     </tr>
     <tr>
      <td>
                    <p><%: Html.LabelFor(model => model.ShortState) %> :</p>
                </td>
                <td>
                    <%= Html.DropDownList("estado")%>
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.HomePhone) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.HomePhone) %>
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.MovilPhone) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.MovilPhone) %>
                </td>
     </tr>
     <tr>
      <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.ShortState) %>
                </td>
                <td colspan="2">
                 <p>(ej. 55 56357709)</p>
                    <%: Html.ValidationMessageFor(model => model.HomePhone) %>
                </td>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.MovilPhone) %>
                </td>
     </tr>
    </table>

        <table>
            <tr>
               <td>
                    <p><%: Html.LabelFor(model => model.nMattressUsers) %> :</p>
                </td>
                <td>
                    <%= Html.DropDownList("nMattress")%>
                </td>
                <td>
                </td>
                <%--<td>
                    <p><%: Html.LabelFor(model => model.Age) %> :</p>
                </td>
                <td>
                    <%= Html.DropDownList("cAge")%>
                </td>
                <td>
                </td>--%>
            </tr>
            <tr>
            <td>
                    <p><%: Html.LabelFor(model => model.Gender) %> :</p>
                </td>
                <td>
                    <p>
                        Masculino
                        <%= Html.RadioButton("cGender", "Masculino")%></p>
                        <p> Femenino
                        <%= Html.RadioButton("cGender", "Femenino")%></p>
                </td>
                <td>
                 
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.NewsLetter) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.NewsLetter) %>
                </td>
                <td>
                    <%: Html.ValidationMessageFor(model => model.NewsLetter) %>
                </td>
                <td>
                    <p><%: Html.LabelFor(model => model.PrivacyNotice) %> :</p>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.PrivacyNotice)%>
                </td>
                <td>
                    <%: Html.ValidationMessageFor(model => model.PrivacyNotice)%>
                </td>
            </tr>
        </table>

        <%--<div class="editor-label">
            <%: Html.LabelFor(model => model.SangUserId) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.SangUserId) %>
            <%: Html.ValidationMessageFor(model => model.SangUserId) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.UserName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.UserName) %>
            <%: Html.ValidationMessageFor(model => model.UserName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FirstName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.FirstName) %>
            <%: Html.ValidationMessageFor(model => model.FirstName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.LastName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.LastName) %>
            <%: Html.ValidationMessageFor(model => model.LastName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.CompleteName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.CompleteName) %>
            <%: Html.ValidationMessageFor(model => model.CompleteName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.BirthDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.BirthDate) %>
            <%: Html.ValidationMessageFor(model => model.BirthDate) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Gender) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Gender) %>
            <%: Html.ValidationMessageFor(model => model.Gender) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Age) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Age) %>
            <%: Html.ValidationMessageFor(model => model.Age) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nMattressUsers) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nMattressUsers) %>
            <%: Html.ValidationMessageFor(model => model.nMattressUsers) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Disorder1) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Disorder1) %>
            <%: Html.ValidationMessageFor(model => model.Disorder1) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Disorder2) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Disorder2) %>
            <%: Html.ValidationMessageFor(model => model.Disorder2) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Disorder3) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Disorder3) %>
            <%: Html.ValidationMessageFor(model => model.Disorder3) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Disorder4) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Disorder4) %>
            <%: Html.ValidationMessageFor(model => model.Disorder4) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Disorder5) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Disorder5) %>
            <%: Html.ValidationMessageFor(model => model.Disorder5) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Disorder6) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Disorder6) %>
            <%: Html.ValidationMessageFor(model => model.Disorder6) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Disorder7) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Disorder7) %>
            <%: Html.ValidationMessageFor(model => model.Disorder7) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Disorder8) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Disorder8) %>
            <%: Html.ValidationMessageFor(model => model.Disorder8) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.SecondaryEmail) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.SecondaryEmail) %>
            <%: Html.ValidationMessageFor(model => model.SecondaryEmail) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Address) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Address) %>
            <%: Html.ValidationMessageFor(model => model.Address) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Colony) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Colony) %>
            <%: Html.ValidationMessageFor(model => model.Colony) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.PostalCode) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.PostalCode) %>
            <%: Html.ValidationMessageFor(model => model.PostalCode) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Township) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Township) %>
            <%: Html.ValidationMessageFor(model => model.Township) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ShortState) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ShortState) %>
            <%: Html.ValidationMessageFor(model => model.ShortState) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.HomePhone) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.HomePhone) %>
            <%: Html.ValidationMessageFor(model => model.HomePhone) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.MovilPhone) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.MovilPhone) %>
            <%: Html.ValidationMessageFor(model => model.MovilPhone) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.NewsLetter) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.NewsLetter) %>
            <%: Html.ValidationMessageFor(model => model.NewsLetter) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.RegisterDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.RegisterDate) %>
            <%: Html.ValidationMessageFor(model => model.RegisterDate) %>
        </div>--%>

        <p>
            <input type="submit" value="Crear" />
        </p>
    </div>
    <% } %>
</asp:Content>
