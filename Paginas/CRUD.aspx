<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="BDCrudTest.Paginas.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">ID categoría</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbIDCategori"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre categoría</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbnombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Es activa ?</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="DropDownActiva">
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Update" Visible="false" OnClick="BtnUpdate_Click"/>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_Click"/>
            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnVolver" Text="Volver" Visible="True" OnClick="BtnVolver_Click"/>
        </div>
    </form>
</asp:Content>