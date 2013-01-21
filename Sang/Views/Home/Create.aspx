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
    <div class="cuestionario">
        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>
        <%: Html.HiddenFor(model => model.SangUserId) %>
        <%: Html.HiddenFor(model => model.HospitalId) %>
        <%: Html.HiddenFor(model => model.nMattressUsers) %>
        <%: Html.HiddenFor(model => model.UserType) %>
        <%: Html.HiddenFor(model => model.Gender) %>

        <img style="margin:10px" src="../../Content/images/PantallaDatos_small.png" alt="Imagen" />
        <table style="margin:0 auto;">
            <tr>
                <th>
                    Nombre completo:
                </th>
            </tr>
            <tr>
                <td>
                    <%: Html.LabelFor(model => model.UserName) %>
                    <strong>*</strong>
                    <%: Html.ValidationMessageFor(model => model.UserName) %>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.FirstName) %>
                    <strong>*</strong>
                    <%: Html.ValidationMessageFor(model => model.FirstName) %>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.LastName) %>
                    <strong>*</strong>
                    <%: Html.ValidationMessageFor(model => model.LastName) %>
                </td>
            </tr>
            <tr>
                <td>
                    <%: Html.EditorFor(model => model.UserName) %>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.FirstName) %>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.LastName) %>
                </td>
            </tr>
            <tr>
                <td>
                    <%: Html.LabelFor(model => model.BirthDate) %>
                    <strong>*</strong>
                    <%: Html.ValidationMessageFor(model => model.BirthDate) %>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.Gender) %>
                    <strong>* <span style="font-size:12px;">Requerido</span></strong>
                </td>
            </tr>
            <tr>
                <td>
                    <%: Html.TextBoxFor(model => model.BirthDate, new { id="from"})%>
                </td>
                <td>
                    <p>
                        <%= Html.RadioButton("cGender", "Masculino")%>
                        Masculino
                        <%= Html.RadioButton("cGender", "Femenino")%>
                        Femenino</p>
                </td>
            </tr>
            <tr>
                <th>
                    Datos Adicionales:
                </th>
            </tr>
            <tr>
                <td>
                    <%: Html.LabelFor(model => model.SecondaryEmail) %>
                    <%: Html.ValidationMessageFor(model => model.SecondaryEmail) %>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.HomePhone) %>
                    <%: Html.ValidationMessageFor(model => model.HomePhone) %>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.MovilPhone) %>
                    <strong>*</strong>
                    <%: Html.ValidationMessageFor(model => model.MovilPhone) %>
                    <%: Html.ValidationMessageFor(model => model.Lada) %>
                </td>
            </tr>
            <tr>
                <td>
                    <%: Html.EditorFor(model => model.SecondaryEmail) %>
                </td>
                <td>
                    <%: Html.TextBoxFor(model => model.Lada, new { style="width:50px;"})%>
                    <%: Html.EditorFor(model => model.HomePhone) %>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.MovilPhone) %>
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                        <%: Html.EditorFor(model => model.NewsLetter) %>
                        <%: Html.LabelFor(model => model.NewsLetter) %></p>
                </td>
                <td>
                    <p>¿Número de personas que usan el colchon? <%= Html.DropDownList("nMattress")%></p>
                </td>
                <td>
                    <p>
                        <u>
                            <input type="submit" value="Enviar" style="background: transparent; color: White;
                                border: none; font-weight: lighter; font-size:24px; cursor: pointer" /></u>
                    </p>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <p>
                        <%: Html.EditorFor(model => model.PrivacyNotice)%>
                        <%: Html.LabelFor(model => model.PrivacyNotice) %> * <%: Html.ValidationMessageFor(model => model.PrivacyNotice) %></p>
                </td>
            </tr>
        </table>
        <% } %>
    </div>
</asp:Content>
