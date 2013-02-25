<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Gracias
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="evaluacion">
        <img src="../../Content/images/Cuestionario.png" alt="Imagen" />
        <h2>
            Ha concluido la evaluación.</h2>
        <p>
            En 24 horas recibirá un correo electrónico con los resultados.</p>
    </div>
</asp:Content>
