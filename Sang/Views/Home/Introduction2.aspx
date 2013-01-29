<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Introduction2
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="blankspan">
    </div>
    <% using (Html.BeginForm())
       { %>
    <div class="evaluacion">
    <img src="../../Content/images/Evaluacion.png" alt="Imagen" />

    <%--<%: Html.HiddenFor(model => model.SangUserId) %>
    <%: Html.HiddenFor(model => model.nMattressUsers) %>
    <%: Html.HiddenFor(model => model.UserType) %>
    <%: Html.HiddenFor(model => model.HospitalId) %>--%>

        <table style="margin: 0 auto">
            <%--<tr>
                <th colspan="2">
                    Seleccione un modelo:
                </th>
                <td>
                    <%= Html.DropDownList("ModelMattressID")%>
                </td>
            </tr>--%>
            <%--<tr>
                <th colspan="2">
                    ¿Cuantas personas utilizan el colchon?
                </th>
                <td>
                    <%= Html.DropDownList("nMattress")%>
                </td>
            </tr>--%>
            <tr>
                <th colspan="3">
                    Ahora indique si el <strong>segundo</strong> usuario del colchón es mayor o menor de edad.
                    <br/>
                    Antes de comenzar el cuestionario, para una evaluación más precisa y personalizada,
                    <br />
                    necesitamos saber si el usuario del colchón es mayor o menor de edad.
                </th>
            </tr>
            <tr>
                <th>
                    Mayor de edad
                    <%= Html.RadioButton("MenorEdad", "No")%>
                </th>
                <th>
                    Menor de edad
                    <%= Html.RadioButton("MenorEdad", "Si")%>
                </th>
                <td>
                    <%:Html.ValidationMessage("MenorEdad", "Requerido")%>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: right">
                    <input type="submit" name="button" value="Continuar" />
                </td>
            </tr>
        </table>
    </div>
    <% } %>

</asp:Content>
