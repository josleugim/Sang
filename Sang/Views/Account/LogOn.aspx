<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Iniciar sesión
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<p>
        Escriba su nombre de usuario y contraseña. <%: Html.ActionLink("Registrarse", "Register") %> si no tiene una cuenta.
    </p>--%>

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

    <% using (Html.BeginForm()) { %>
        
        <div class="blankspan"></div>
        <div class="evaluacion">
            <img src="../../Content/images/IniciarSesion.png" alt="Imagen" />
        
        <table style="margin:0 auto">
         <tr>
          <th colspan="3"><p><%: Html.ValidationSummary(true, "No se ha iniciado la sesión. Corrija los errores e inténtelo de nuevo.") %></p></th>
         </tr>
         <tr>
          <td><%: Html.LabelFor(m => m.Email) %></td>
          <td><%: Html.TextBoxFor(m => m.Email) %></td>
          <td><%: Html.ValidationMessageFor(m => m.Email) %></td>
         </tr>
         <tr>
          <td><%: Html.LabelFor(m => m.Password) %></td>
          <td><%: Html.PasswordFor(m => m.Password) %></td>
          <td><%: Html.ValidationMessageFor(m => m.Password) %></td>
         </tr>
         <tr>
          <td colspan="3"><p><input type="submit" value="Iniciar sesión" /></p>      </td>
         </tr>
         <tr>
          <td colspan="3"><p><strong><%= Html.Encode(ViewData["message"]) %></strong></p></td>
         </tr>
        </table>
        
                <%--<div class="editor-label">
                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                    <%: Html.LabelFor(m => m.RememberMe) %>
                </div>--%> 
        </div>
    <% } %>
</asp:Content>
