﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.SangClient>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AdultResult
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="blankspan">
    </div>--%>
    <div style="background-color: #FFFFFF; font-family: Helvetica">
        <div style="width: 100%; background-color: #FFF; text-align: center">
            <img src="<%= Model.Hospital.HospitalLogo %>" alt="Imagen" />
        </div>
        <div style="width: 100%; background-color: #FFF; text-align: center">
            <img src="../../Content/images/ResultadosEvaluacion.jpg" alt="Imagen" /></div>
        <h1 style="color: black; text-align: center;">
            Disturbios del Sueño
        </h1>
        <table style="margin:0 auto; color: black">
            <tr>
                <th colspan="4">
                    Nombre: <%= Model.CompleteName %>
                </th>
            </tr>
            <tr>
                <th>
                    Dirección:
                </th>
                <th>
                    <%= Model.Address %>
                </th>
                <th>
                    Colonia:
                </th>
                <th>
                    <%= Model.Colony %>
                </th>
            </tr>
        </table>
        <br/>
        <table class="tableResult">
            <tr>
                <th>
                    Trastorno de inicio y continuidad del sueño
                </th>
            </tr>
            <tr>
                <td>
                    <div style="width: <%= Html.Encode(ViewData["d1"]) %>px; height: 36px; text-align: right;">
                        <img src="../../Content/images/down_arrow.png" alt="Arrow" />
                    </div>
                    <div style="width: 400px; height: 10px; font-size: 12px; text-align: center; color: Black;">
                        <div style="float: left; width: 80px; height: 20px; background-color: #75E109">
                            Riesgo bajo
                        </div>
                        <div style="float: left; width: 80px; height: 20px; background-color: #FFFF00">
                            Riesgo medio
                        </div>
                        <div style="float: left; width: 240px; height: 20px; background-color: red">
                            Riesgo alto
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <th>
                    Trastornos de movimiento durante el sueño
                </th>
            </tr>
            <tr>
                <td>
                    <div style="width: <%= Html.Encode(ViewData["d2"]) %>px; height: 36px; text-align: right;">
                        <img src="../../Content/images/down_arrow.png" alt="Arrow" />
                    </div>
                    <div style="width: 400px; height: 10px; font-size: 12px; text-align: center; color: Black;">
                        <div style="float: left; width: 80px; height: 20px; background-color: #75E109">
                            Riesgo bajo
                        </div>
                        <div style="float: left; width: 80px; height: 20px; background-color: #FFFF00">
                            Riesgo medio
                        </div>
                        <div style="float: left; width: 240px; height: 20px; background-color: red">
                            Riesgo alto
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <th>
                    Síndrome de apnea obstructiva del sueño
                </th>
            </tr>
            <tr>
                <td>
                    <div style="width: <%= Html.Encode(ViewData["d3"]) %>px; height: 36px; text-align: right;">
                        <img src="../../Content/images/down_arrow.png" alt="Arrow" />
                    </div>
                    <div style="width: 400px; height: 10px; font-size: 12px; text-align: center; color: Black;">
                        <div style="float: left; width: 80px; height: 20px; background-color: #75E109">
                            Riesgo bajo
                        </div>
                        <div style="float: left; width: 80px; height: 20px; background-color: #FFFF00">
                            Riesgo medio
                        </div>
                        <div style="float: left; width: 240px; height: 20px; background-color: red">
                            Riesgo alto
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <th>
                    Hipersomnia idiopática
                </th>
            </tr>
            <tr>
                <td>
                    <div style="width: <%= Html.Encode(ViewData["d5"]) %>px; height: 36px; text-align: right;">
                        <img src="../../Content/images/down_arrow.png" alt="Arrow" />
                    </div>
                    <div style="width: 400px; height: 10px; font-size: 12px; text-align: center; color: Black;">
                        <div style="float: left; width: 80px; height: 20px; background-color: #75E109">
                            Riesgo bajo
                        </div>
                        <div style="float: left; width: 80px; height: 20px; background-color: #FFFF00">
                            Riesgo medio
                        </div>
                        <div style="float: left; width: 240px; height: 20px; background-color: red">
                            Riesgo alto
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <th>
                    Trastornos respiratorios del sueño
                </th>
            </tr>
            <tr>
                <td>
                    <div style="float: left; width: 200px; height: 20px; background-color: #75E109; visibility: <%= Html.Encode(ViewData["d4Low"]) %>;
                        color: Black; text-align: center">
                        Riesgo bajo
                    </div>
                    <div style="float: left; width: 200px; height: 20px; background-color: red; visibility: <%= Html.Encode(ViewData["d4High"]) %>;
                        color: Black; text-align: center">
                        Riesgo alto
                    </div>
                </td>
            </tr>
            <tr>
                <th>
                    Padecimientos cardiacos
                </th>
            </tr>
            <tr>
                <td>
                    <div style="float: left; width: 200px; height: 20px; background-color: #75E109; visibility: <%= Html.Encode(ViewData["d8Low"]) %>;
                        color: Black; text-align: center">
                        Riesgo bajo
                    </div>
                    <div style="float: left; width: 200px; height: 20px; background-color: red; visibility: <%= Html.Encode(ViewData["d8High"]) %>;
                        color: Black; text-align: center">
                        Riesgo alto
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table class="tableResult">
            <tr>
                <th>
                    Epworth grado de somnolencia
                </th>
            </tr>
            <tr>
                <td>
                    <div style="width: <%= Html.Encode(ViewData["d7"]) %>px; height: 36px; text-align: right;">
                        <img src="../../Content/images/down_arrow.png" alt="Arrow" />
                    </div>
                    <div style="width: 480px; height: 10px; font-size: 12px; text-align: center; color: Black;">
                        <div style="float: left; width: 140px; height: 20px; background-color: #75E109">
                            Normal
                        </div>
                        <div style="float: left; width: 40px; height: 20px; background-color: #B3E109">
                            Leve
                        </div>
                        <div style="float: left; width: 120px; height: 20px; background-color: #FFFF00">
                            Moderado
                        </div>
                        <div style="float: left; width: 180px; height: 20px; background-color: red">
                            Severo
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <div style="width: 100%; background-color: #FFF; text-align: center">
            <img src="<%= Model.Hospital.DoctorName %>" alt="Imagen" /></div>
        <br />
        <p style="font-size: 20px"><a style="color: black;" href="<%= Html.Encode(ViewData["Coupon"]) %>" target="_blank"><%= Html.Encode(ViewData["CouponOk"])%></a></p>
    </div>
</asp:Content>
