<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebForms.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mainContainer">
        <h2>Registracija</h2>

        <asp:TextBox runat="server" ID="tb_username" CssClass="form-control" Placeholder="E-mail" />
        <asp:RequiredFieldValidator ControlToValidate="tb_username" ErrorMessage="Unesite E-mail adresu" Display="None" runat="server" />
        <asp:RegularExpressionValidator ControlToValidate="tb_username" ErrorMessage="E-mail adresa je pogrešna" Display="None" runat="server" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$" />

        <asp:TextBox runat="server" ID="tb_password" CssClass="form-control" Placeholder="Lozinka" TextMode="Password" />
        <asp:RequiredFieldValidator ControlToValidate="tb_password" ErrorMessage="Unesite lozinku" Display="None" runat="server" />

        <asp:TextBox runat="server" ID="tb_password_again" CssClass="form-control" Placeholder="Ponovno lozinka" TextMode="Password" />
        <asp:RequiredFieldValidator ControlToValidate="tb_password_again" ErrorMessage="Unesite lozinku ponovno" Display="None" runat="server" />
        <asp:CompareValidator ControlToValidate="tb_password_again" ControlToCompare="tb_password" ErrorMessage="Lozinke se ne podudaraju" Display="None" runat="server" />

        <asp:Button Text="Registriraj se" runat="server" ID="btn_register" OnClick="btn_register_Click" CssClass="btn btn-primary" />

        <h4 id="message" runat="server"></h4>
        <asp:ValidationSummary runat="server" CssClass="validationSummary" />
    </div>
</asp:Content>
