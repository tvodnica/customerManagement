<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataPage.aspx.cs" Inherits="WebForms.DataPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RWA Projekt</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/DataPage.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a href="" class="navbar-brand">RWA Projekt - WF</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a href="http://localhost:63558/">Početna</a></li>
                        <li>
                            <asp:LinkButton Text="Odjava" runat="server" ID="btn_logout" OnClick="btn_logout_Click" />
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <div id="mainContainer" class="container">
            <div id="viewOptions" class="jumbotron">
                <div class="oneViewOption">
                    <label>Broj kupaca koji se prikazuju (1-50)</label>
                    <asp:TextBox runat="server" ID="tb_number"
                        CssClass="form-control" TextMode="Number" Text="10" />
                </div>
                <div class="oneViewOption">
                    <label>Država kupaca koji se prikazuju</label>
                    <asp:DropDownList runat="server" ID="ddl_drzava" CssClass="form-control" AutoPostBack="true"
                        OnSelectedIndexChanged="ddl_drzava_SelectedIndexChanged" />
                </div>
                <div class="oneViewOption">
                    <label>Grad kupaca koji se prikazuju</label>
                    <asp:DropDownList runat="server" ID="ddl_grad" CssClass="form-control" />
                </div>
                <div class="oneViewOption">
                    <asp:Button Text="Prikaži kupce" runat="server" ID="btn_showKupci"
                        OnClick="btn_showKupci_Click" CssClass="btn btn-primary" />
                </div>
            </div>
            <asp:ValidationSummary runat="server" CssClass="validationSummary" />


            <asp:GridView ID="gv_kupci" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                CssClass="table table-striped" DataSourceID="SqlDataSource1" DataKeyNames="IDKupac" OnSelectedIndexChanged="gv_kupci_SelectedIndexChanged">

                <Columns>

                    <asp:BoundField DataField="IDKupac" HeaderText="IDKupac" Visible="false" ReadOnly="True" />
                    <asp:BoundField DataField="Ime" HeaderText="Ime" SortExpression="Ime" />
                    <asp:BoundField DataField="Prezime" HeaderText="Prezime" SortExpression="Prezime" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Telefon" HeaderText="Telefon" />
                    <asp:BoundField DataField="GradID" HeaderText="GradID" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Odaberi" CssClass="btn btn-warning btn-sm">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="Button1" CssClass="btn btn-sm btn-danger" runat="server" CausesValidation="True" ValidateRequestMode="Enabled" CommandName="Update" Text="Ažuriraj" />
                            <asp:Button ID="Button2" CssClass="btn btn-sm btn-primary" runat="server" CausesValidation="False" CommandName="Cancel" Text="Odustani" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button1" CssClass="btn btn-sm btn-primary" runat="server" CausesValidation="False" CommandName="Edit" Text="Uredi" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>"
                SelectCommand="SELECT * FROM [Kupac] WHERE ([GradID] = @GradID)" ConflictDetection="CompareAllValues"
                DeleteCommand="DELETE FROM [Kupac] WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))"
                InsertCommand="INSERT INTO [Kupac] ([Ime], [Prezime], [Email], [Telefon], [GradID]) VALUES (@Ime, @Prezime, @Email, @Telefon, @GradID)" OldValuesParameterFormatString="original_{0}"
                UpdateCommand="UPDATE [Kupac] SET [Ime] = @Ime, [Prezime] = @Prezime, [Email] = @Email, [Telefon] = @Telefon, [GradID] = @GradID WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_IDKupac" Type="Int32" />
                    <asp:Parameter Name="original_Ime" Type="String" />
                    <asp:Parameter Name="original_Prezime" Type="String" />
                    <asp:Parameter Name="original_Email" Type="String" />
                    <asp:Parameter Name="original_Telefon" Type="String" />
                    <asp:Parameter Name="original_GradID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Ime" Type="String" />
                    <asp:Parameter Name="Prezime" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Telefon" Type="String" />
                    <asp:Parameter Name="GradID" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddl_grad" Name="GradID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Ime" Type="String" />
                    <asp:Parameter Name="Prezime" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Telefon" Type="String" />
                    <asp:Parameter Name="GradID" Type="Int32" />
                    <asp:Parameter Name="original_IDKupac" Type="Int32" />
                    <asp:Parameter Name="original_Ime" Type="String" />
                    <asp:Parameter Name="original_Prezime" Type="String" />
                    <asp:Parameter Name="original_Email" Type="String" />
                    <asp:Parameter Name="original_Telefon" Type="String" />
                    <asp:Parameter Name="original_GradID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
