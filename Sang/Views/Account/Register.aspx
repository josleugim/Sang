<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Registrarse
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

    <% using (Html.BeginForm()) { %>
        <div class="blankspan"></div>
        <div class="evaluacion">
        <img src="../../Content/images/Registro.png" alt="Imagen" />
            
            <%--<p>Use el formulario siguiente para crear una cuenta nueva. Es necesario que las contraseñas tengan al menos <%: Membership.MinRequiredPasswordLength %> caracteres.</p>--%>
            
            <table style="margin:0 auto; width:800px">
             <tr>
              <td colspan="3"><p>La garantía introducida es válida, para registrar y posteriormente enviarte la evaluación, necesitamos que nos facilites los siguientes datos.</p></td>
              <td rowspan="5"><%: Html.ValidationSummary(true, "* No se creó la cuenta. Corrija los errores e inténtelo de nuevo.") %></td>
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
              <td><%: Html.LabelFor(m => m.ConfirmPassword) %></td>
              <td><%: Html.PasswordFor(m => m.ConfirmPassword) %></td>
              <td><%: Html.ValidationMessageFor(m => m.ConfirmPassword) %></td>
             </tr>
             <tr>
             <td></td>
              <td>
               <input type="submit" value="Registrarse" />
              </td>
              <td></td>
             </tr>
            </table>
        </div>
        
    <% } %>
</asp:Content>
