<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BDCrudTest.Paginas.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Bienvenido
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat ="server">
        <br />
        <div class ="mx-auto" style="width:300px">
            <h2>Listado de categorías</h2>
        </div>
        <br />
        <div class ="container"">
            <div class-="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="btnCrear" CssClass="btn btn-success form-control-sm" Text="Crear categoría" OnClick="btnCrear_Click"/>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="table small">
                <asp:GridView runat="server" ID="coCategori" class="table table-borderless table-hover">
                    <Columns>
                         <asp:TemplateField HeaderText="Funciones">
                             <ItemTemplate>
                                 <asp:Button runat="server" Text="Leer" CssClass="btn form-control-sm btn-info" ID="btnLeer" OnClick="btnLeer_Click" />
                                 <asp:Button runat="server" Text="Actualizar" CssClass="btn form-control-sm btn-warning" ID="btnUpdate" OnClick="btnUpdate_Click"/>
                                 <asp:Button runat="server" Text="Eliminar" CssClass="btn form-control-sm btn-danger" ID="btnDelete" OnClick="btnDelete_Click"/>
                                 <asp:Button runat="server" Text="Ver productos" CssClass="btn form-control-sm btn-info" ID="btnVerProduct" OnClick="btnVerProduct_Click"/>
                             </ItemTemplate>
                         </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!--Comenzamos otro espacio para poder mostrar el listado de los productos-->
         <br />
        <div class ="mx-auto" style="width:300px">
            <h2>Listado de productos</h2>
        </div>
        <br />
        <div class ="container"">
        </div>
        <br />
        <div class="container">
            <div class="table small">
                <asp:GridView runat="server" ID="TablaProductos" class="table table-borderless table-hover">
                    <Columns>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>

</asp:Content>
