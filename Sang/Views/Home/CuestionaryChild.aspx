<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.SangChild>"
    LCID="1034" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CuestionaryChild
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="blankspan">
    </div>
    <div class="cuestionario">
        <img src="../../Content/images/Cuestionario.png" alt="Imagen" />
        <p>
            Para registrar y posteriormente enviarte la evaluación, necesitamos que nos facilites
            los siguientes datos:
        </p>
        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>
        <%--<div class="editor-label">
            <%: Html.LabelFor(model => model.SangClientId) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.SangClientId) %>
            <%: Html.ValidationMessageFor(model => model.SangClientId) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
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
            <%: Html.LabelFor(model => model.Age) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Age) %>
            <%: Html.ValidationMessageFor(model => model.Age) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.CuestionaryResult) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.CuestionaryResult) %>
            <%: Html.ValidationMessageFor(model => model.CuestionaryResult) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.RegisterDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.RegisterDate) %>
            <%: Html.ValidationMessageFor(model => model.RegisterDate) %>
        </div>--%>
        <table>
            <tr>
                <td>
                    <%: Html.LabelFor(model => model.Name) %>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.Name) %>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.FirstName) %>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.FirstName) %>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.LastName) %>
                </td>
                <td>
                    <%: Html.EditorFor(model => model.LastName) %>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.Name) %>
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
                    <%: Html.LabelFor(model => model.Age) %>
                </td>
                <td>
                    <%: Html.DropDownList("childAge")%>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%: Html.ValidationMessageFor(model => model.Age) %>
                </td>
            </tr>
        </table>
        <table class="tableCuestion">
            <tr>
                <td>
                </td>
                <th>
                    Frecuentemente
                </th>
                <th>
                    Algunas veces
                </th>
                <th>
                    Rara vez
                </th>
                <th>
                    Casi nunca
                </th>
            </tr>
            <tr>
                <th>
                    ¿Con que frecuencia te quedas dormido o te sientes adormilado durante las clases?
                </th>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q1", "4")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q1", "3")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q1", "2")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q1", "1")%>
                </td>
            </tr>
            <tr>
                <th>
                    ¿Con que frecuencia te quedas dormido o te sientes adormilado mientras haces tarea?
                </th>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q2", "4")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q2", "3")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q2", "2")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q2", "1")%>
                </td>
            </tr>
            <tr>
                <th>
                    ¿Con que frecuencia estas distraído o poco atento la mayor parte del tiempo?
                </th>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q3", "4")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q3", "3")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q3", "2")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q3", "1")%>
                </td>
            </tr>
            <tr>
                <th>
                    ¿Con que frecuencia estás todo el día cansado y de malas?
                </th>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q4", "4")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q4", "3")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q4", "2")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q4", "1")%>
                </td>
            </tr>
            <tr>
                <th>
                    ¿Con que frecuencia se te dificulta levantarte de la cama por la mañana?
                </th>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q5", "4")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q5", "3")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q5", "2")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q5", "1")%>
                </td>
            </tr>
            <tr>
                <th>
                    ¿Con que frecuencia te vuelves a dormir en la mañana, después de haberte levantado?
                </th>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q6", "4")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q6", "3")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q6", "2")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q6", "1")%>
                </td>
            </tr>
            <tr>
                <th>
                    ¿Con que frecuencia necesitas que alguien te levante en la mañana?
                </th>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q7", "4")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q7", "3")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q7", "2")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q7", "1")%>
                </td>
            </tr>
            <tr>
                <th>
                    ¿Con que frecuencia piensas que necesitas dormir más?
                </th>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q8", "4")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q8", "3")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q8", "2")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q8", "1")%>
                </td>
            </tr>
            <tr>
                <th>
                    ¿Con que frecuencia te vuelves a dormir en la mañana después de haberte despertado?
                </th>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q9", "4")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q9", "3")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q9", "2")%>
                </td>
                <td style="text-align: center">
                    <%= Html.RadioButton("Q9", "1")%>
                </td>
            </tr>
        </table>
        <p>
            <input type="submit" name="button" value="Enviar" /></p>
        <%} %>
    </div>
</asp:Content>
