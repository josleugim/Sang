<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Error
</asp:Content>
<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="evaluacion">
        <br />
        <h2>
            Lo sentimos; se produjo un error al procesar la solicitud.
        </h2>
        <p>
            Contáctenos a mail@sang.mx y con gusto lo atenderemos.</p>
    </div>
</asp:Content>
