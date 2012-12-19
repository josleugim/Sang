<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Options
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="blankspan">
    </div>
    <div class="decision">
        <table style="margin: 0 auto;">
            <tr>
                <td>
                    <img src="../../Content/images/Texto1.png" alt="Imagen" />
                </td>
                <td>
                    <img src="../../Content/images/Texto2.png" alt="Imagen" />
                </td>
                <td>
                    <img src="../../Content/images/Texto3.png" alt="Imagen" />
                </td>
            </tr>
        </table>
        <div style="margin:0 auto; width:1000px">
            <p>
                En Säng nos preocupamos por tu descanso y por ello hemos diseñado, con los más reconocidos
                expertos en México, un cuestionario muy simple que permite identificar posibles
                problemas durante tu descanso. El cuestionario sera evaluado por un experto y podrás
                consultar tus resultados al siguiente día hábil. En el caso que necesites atención
                especializada te ponemos en contacto con los especialistas y te daremos beneficios
                exclusivos.</p>
        </div>
        <table style="margin: 0 auto">
            <tr>
                <th>
                    <%= Html.ActionLink("Ir a la evaluación","Introduction") %>
                </th>
                <th>
                  <a href="Introduction" target="_self"><img src="../../Content/images/Boton.png" alt="Imagen" /></a>
                </th>
                <th>
                </th>
                <th>
                </th>
                <th>
                </th>
                <th>
                    <%= Html.ActionLink("Ir a la garantía","Introduccion") %>
                </th>
                <th><a href="#" target="_self"><img src="../../Content/images/Boton.png" alt="Imagen" /></a></th>
            </tr>
        </table>
    </div>
</asp:Content>
