<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.SangClient>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AdultCuestionary2
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="blankspan">
    </div>
    
        <% using (Html.BeginForm())
           { %>
        <div class="cuestionario">
        <img src="../../Content/images/Cuestionario.png" alt="Imagen" />
        <p>
        Responde de acuerdo a lo que te ha pasado el último mes</p>
        <table class="tableCuestion">
            <tr>
                <th>
                 Pregunta
                </th>
                <th>
                    0-15 min.
                </th>
                <th>
                    16-30 min.
                </th>
                <th>
                    31-45 min.
                </th>
                <th>
                    46-60 min.
                </th>
                <th>
                    Más de 60 min.
                </th>
            </tr>
            <tr>
                <td>
                    En promedio, ¿Cuántos minutos tardas en quedarte dormido?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q1", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q1", "25")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q1", "50")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q1", "75")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q1", "100")%>
                </td>
            </tr>
        </table>
        <p>
            Con que frecuencia en el último mes (Marca la opción que te identifique, solo una por línea)</p>
        <table class="tableCuestion">
            <tr>
                <th>
                Preguntas
                </th>
                <th>
                    Nunca
                </th>
                <th>
                    Casi nunca
                </th>
                <th>
                    Algunas veces
                </th>
                <th>
                    Frecuentemente
                </th>
                <th>
                    Casi siempre
                </th>
                <th>
                    Siempre
                </th>
            </tr>
            <tr>
                <td>
                    Cuando tratas de relajarte por la tarde o dormir en la noche, ¿tienes una sensación
                    de malestar o inquietud en las piernas que se calma si caminas o las mueves?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q2", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q2", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q2", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q2", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q2", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q2", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Mientras estabas dormido(a), sentiste o te dijeron que estabas muy inquieto(a),
                    (hablaste, te moviste mucho, estuviste tenso)?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q3", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q3", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q3", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q3", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q3", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q3", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Te sentiste cansado(a) en la mañana a pesar de dormir lo suficiente?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q4", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q4", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q4", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q4", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q4", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q4", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Despertaste sintiendo que te faltaba el aire o ahogándote?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q5", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q5", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q5", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q5", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q5", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q5", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Te sentiste cansado(a) o con sueño durante el día?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q6", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q6", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q6", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q6", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q6", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q6", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Te costo trabajo quedarte dormido?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q7", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q7", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q7", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q7", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q7", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q7", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Despertaste durante la noche y te costo trabajo volverte a dormir?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q8", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q8", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q8", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q8", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q8", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q8", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Sientes en algún momento del día que no puedes mantenerte despierto(a)?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q9", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q9", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q9", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q9", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q9", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q9", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Sentiste o te dijeron que roncaste mientras estabas dormido(a)?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q10", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q10", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q10", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q10", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q10", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q10", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Tomaste siestas (de más de 5 minutos) durante el día?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q11", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q11", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q11", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q11", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q11", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q11", "100")%>
                </td>
            </tr>
            <tr>
                <td>
                    ¿Te faltaron horas de sueño para sentirte bien?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q12", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q12", "20")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q12", "40")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q12", "60")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q12", "80")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q12", "100")%>
                </td>
            </tr>
        </table>
        <p>Si no ha estado haciendo alguna de estas actividades recientemente, conteste cómo cree que reaccionaría en ésa situación:</p>
        <table class="tableCuestion">
            <tr>
                <th>
                    ¿Qué tan frecuentemente cabecéa o se queda dormido Ud. en cada una de las siguientes situaciones (durante el día)? Si no ha estado haciendo alguna de estas actividades recientemente, conteste cómo cree que reaccionaría en ésa situación:
                </th>
                <th>
                    Nunca
                </th>
                <th>
                    Solo algunas veces
                </th>
                <th>
                    Muchas veces
                </th>
                <th>
                    Casi siempre
                </th>
            </tr>
            <tr>
                <td>
                    Sentado leyendo:
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q13", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q13", "1")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q13", "2")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q13", "3")%>
                </td>
            </tr>
            <tr>
                <td>
                    Viendo la televisión:
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q14", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q14", "1")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q14", "2")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q14", "3")%>
                </td>
            </tr>
            <tr>
                <td>
                    Sentado, inactivo en un lugar público (ej.: en el cine):
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q15", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q15", "1")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q15", "2")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q15", "3")%>
                </td>
            </tr>
            <tr>
                <td>
                    Como pasajero en un viaje de una hora (o más) sin paradas:
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q16", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q16", "1")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q16", "2")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q16", "3")%>
                </td>
            </tr>
            <tr>
                <td>
                    Acostado descansando por la tarde:
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q17", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q17", "1")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q17", "2")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q17", "3")%>
                </td>
            </tr>
            <tr>
                <td>
                    Sentado platicando con alguien:
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q18", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q18", "1")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q18", "2")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q18", "3")%>
                </td>
            </tr>
            <tr>
                <td>
                    Sentado cómodamente después de comer, sin haber tomado bebidas alcohólicas:
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q19", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q19", "1")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q19", "2")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q19", "3")%>
                </td>
            </tr>
            <tr>
                <td>
                    Viajando en un transporte detenido en el tráfico:
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q20", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q20", "1")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q20", "2")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q20", "3")%>
                </td>
            </tr>
        </table>

        <table class="tableCuestion">
        <tr>
         <th>Pregunta</th>
         <th>No</th>
         <th>Si</th>
        </tr>
         <tr>
                <td>
                    ¿Tiene algún padecimiento cardiaco?
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q21", "0")%>
                </td>
                <td style="text-align:center">
                    <%= Html.RadioButton("Q21", "100")%>
                </td>
            </tr>
        </table>

        <input type="submit" value="Enviar" />
        </div>
        <%} %>

</asp:Content>
