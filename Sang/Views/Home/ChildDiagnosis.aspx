<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.SangChild>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ChildDiagnosis
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="blankspan">
    </div>
    <div class="cuestionario">
        <div style="width: 100%; background-color: #FFF; text-align: center">
            <img src="../../Content/images/Logoabc_hospital.jpg" alt="Imagen" /></div>
        <table class="tableCuestion">
            <tr>
                <td>
                    Nombre del tutor:
                </td>
                <td>
                    <%: Html.DisplayTextFor(model => model.SangClient.CompleteName) %>
                </td>
                <td>Email:</td>
                <td><%: Html.DisplayTextFor(model => model.SangClient.SangUser.Email) %></td>
            </tr>
            <tr>
                <td>
                    Nombre:
                </td>
                <td>
                    <%: Html.DisplayTextFor(model => model.CompleteName) %>
                </td>
                <td>
                    Edad:
                </td>
                <td>
                    <%: Html.DisplayTextFor(model => model.Age) %>
                </td>
            </tr>
        </table>
        <h1 class="ribbon">
            <strong class="ribbon-contentenido">Diagnóstico</strong>
        </h1>
        <table class="tableResult">
            <tr>
                <td>
                    <div style="width: <%= Html.Encode(ViewData["waranty"]) %>px; height: 36px; text-align: right;">
                        <img src="../../Content/images/down_arrow.png" alt="Arrow" />
                    </div>
                    <div style="width: 360px; height: 10px; font-size: 12px; text-align: center; color: Black;">
                        <div style="float: left; width: 160px; height: 90px; background-color: #75E109; font-weight: lighter;
                            font-size: 22px">
                            <br />
                            Normal
                        </div>
                        <div style="float: left; width: 30px; height: 90px; background-color: #00A8E6; font-weight: lighter;
                            font-size: 17px">
                            L
                            <br />
                            e
                            <br />
                            v
                            <br />
                            e
                        </div>
                        <div style="float: left; width: 80px; height: 90px; background-color: #FFFF00; font-weight: lighter;
                            font-size: 17px">
                            <br />
                            Moderado
                        </div>
                        <div style="float: left; width: 90px; height: 90px; background-color: red; font-weight: lighter;
                            font-size: 22px">
                            <br />
                            Severo
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <p>
            <%= Html.Encode(ViewData["Sugest"])%></p>
        <p>
            El Estudio de Calidad del Sueño (Sleep Image) es una estudio no invasivo, que se
            realiza en la comodidad de su casa mientras duerme. Este novedoso estudio indica,
            basado en variables fisiológicas, el tiempo que permanece dormido, la profundidad
            del sueño y la presencia de trastornos respiratorios o de movimientos durante este.
            El estudio está aprobado para menores de edad.</p>
        <div style="margin: 0 auto; font-size: 22px; font-weight: lighter">
            <p>
                <%: Html.ActionLink("Regresar", "Options") %></p>
        </div>
    </div>
</asp:Content>
