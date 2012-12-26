<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Sang.Models.Purchase>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <div class="blankspan">
    </div>
    <div class="cuestionario">
        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>
        <%: Html.HiddenFor(model => model.WarrantyId) %>
        <img style="margin: 10px" src="../../Content/images/RegistrodeGarantia_small.png"
            alt="Imagen" />
        <table style="margin: 0 auto;">
            <tr>
                <th>
                    Datos Colchón:
                </th>
            </tr>
            <tr>
                <td>
                    <%: Html.LabelFor(model => model.BillNumber) %>
                    <strong>*</strong>
                    <%: Html.ValidationMessageFor(model => model.BillNumber)%>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.ModelMattress.ModelName) %>
                    <strong>*</strong>
                </td>
                <td>
                    <%: Html.LabelFor(model => model.MattressSize) %>
                    <strong>*</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <%: Html.EditorFor(model => model.BillNumber)%>
                </td>
                <td>
                    <%: Html.DropDownList("MattressId")%>
                </td>
                <td>
                    <%= Html.DropDownList("Size")%>
                </td>
            </tr>
            <tr>
                <td>
                    <%: Html.LabelFor(model => model.Store) %>
                    <%: Html.ValidationMessageFor(model => model.Store) %>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <%: Html.EditorFor(model => model.Store) %>
                </td>
            </tr>
            <tr>
                <th>
                    Dirección:
                </th>
            </tr>
            <tr>
                <td>
                    Calle: <strong>*</strong>
                </td>
                <td>
                </td>
                <td>
                    Número Ext: <strong>*</strong>
                </td>
                <td>
                    Número Int:
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%: Html.TextBox("calle", null, new { style="width:100%"})%>
                </td>
                <td style="text-align: center">
                    <%: Html.TextBox("nExt", null, new { style="width:50px"})%>
                </td>
                <td style="text-align: center">
                    <%: Html.TextBox("nInt", null, new { style="width:50px"})%>
                </td>
            </tr>
            <tr>
                <td>
                    Colonia: <strong>*</strong>
                </td>
                <td>
                    Delegación/Municipio: <strong>*</strong>
                </td>
                <td>
                    Estado:<strong>*</strong>
                </td>
            </tr>
            <tr>
                <td>
                    <%: Html.TextBox("colonia")%>
                </td>
                <td>
                    <%: Html.TextBox("delMuni")%>
                </td>
                <td>
                    <%: Html.DropDownList("estado")%>
                </td>
            </tr>
            <tr>
                <td>
                    Código postal: <strong>*</strong>
                </td>
                <td rowspan="2">
                    <p>
                        <u>
                            <input type="submit" value="Enviar" style="background: transparent; color: White;
                                border: none; font-weight: lighter; font-size:24px; cursor: pointer" />
                        </u>
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <%: Html.TextBox("cp")%>
                </td>
            </tr>
        </table>
        <%--<div class="editor-label">
                <%: Html.LabelFor(model => model.ModelMattress.ModelName) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("MattressId")%>
                <%: Html.ValidationMessageFor(model => model.ModelMattresstId) %>
            </div>--%>
        <%--<div class="editor-label">
            <%: Html.LabelFor(model => model.WarrantyId) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.WarrantyId) %>
            <%: Html.ValidationMessageFor(model => model.WarrantyId) %>
        </div>--%>
        <%--<div class="editor-label">
                <%: Html.LabelFor(model => model.BillNumber) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.BillNumber) %>
                <%: Html.ValidationMessageFor(model => model.BillNumber) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MattressSize) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("Size")%>
                <%: Html.ValidationMessageFor(model => model.MattressSize) %>
            </div>--%>
        <%--<div class="editor-label">
                <%: Html.LabelFor(model => model.Store) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.Store) %>
                <%: Html.ValidationMessageFor(model => model.Store) %>
            </div>--%>
        <%--<div class="editor-label">
            <%: Html.LabelFor(model => model.RegisterDate) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.RegisterDate) %>
            <%: Html.ValidationMessageFor(model => model.RegisterDate) %>
        </div>--%>
        <% } %>
        <%--<div>
            <%: Html.ActionLink("Back to List", "Index") %>
        </div>--%>
    </div>
</asp:Content>
