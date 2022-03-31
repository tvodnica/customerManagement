<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForms.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mainContainer">

        <h2>Prijava</h2>

        <asp:TextBox runat="server" ID="tb_username" CssClass="form-control" Placeholder="E-mail" />
        <asp:RequiredFieldValidator ErrorMessage="Unesite E-mail adresu" ControlToValidate="tb_username" runat="server" Display="None" />
        <asp:RegularExpressionValidator ControlToValidate="tb_username" ErrorMessage="E-mail adresa je pogrešna" Display="None" runat="server" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$" />

        <asp:TextBox runat="server" ID="tb_password" CssClass="form-control" Placeholder="Lozinka" TextMode="Password" />
        <asp:RequiredFieldValidator ErrorMessage="Unesite lozinku" ControlToValidate="tb_password" runat="server" Display="None" />

        <asp:Button Text="Prijavi se" runat="server" ID="btn_login" OnClick="btn_login_Click" CssClass="btn btn-primary" />
        
        <h4 id="message" runat="server"></h4>
        <asp:ValidationSummary runat="server" CssClass="validationSummary" />

    </div>
</asp:Content>
