<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.SangUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Gracias por registrarte
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="blankspan">
    </div>
    <div class="evaluacion">
        <br />
        <br />
        <h1>
            Gracias por registrarte</h1>
        <p>
            Pronto recibirás una confirmación a tu correo
            <%: Model.Email %>, da clic en el link que te enviamos para activar tu cuenta.</p>
    </div>
</asp:Content>
