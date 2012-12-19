<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.Newsletter>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ThanksNewsletter
    <!-- Analytics -->
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-36828589-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="blankspan">
    </div>
    <div class="decision">
    <br />
    <br />
        <h2>
            Gracias
            <%= Model.CompleteName %>,</h2>
        <p>
            Por registrarte a nuestro newsletter, pronto recibirá un email de agradecimiento.</p>
        <p>
            <%
                try
                {
                    WebMail.SmtpServer = "mail.sang.mx";
                    WebMail.SmtpPort = 25;
                    WebMail.EnableSsl = false;
                    WebMail.UserName = "newsletter@sang.mx";
                    WebMail.Password = "n3wsLA";
                    WebMail.From = "newsletter@sang.mx";
                    WebMail.Send(Model.Email, "Säng te da la bienvenida.", "Gracias " + Model.CompleteName +
                        ", por suscribirse a nuestro Newsletter. Le enviaremos un correo a la dirección facilitada confirmando su registro y con ello recibirá periódicamente nuestro Newsletter con información que esperamos le sea de utilidad.");
                }
                catch (Exception e)
                {
                    Response.Write("No se pudo enviar el correo debido al siguiente error: " + e.Message.ToString());
                }
            %>
        </p>
    </div>
</asp:Content>
