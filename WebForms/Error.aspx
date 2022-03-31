<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebForms.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RWA Project - ERROR</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/error.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>GREŠKA</h1>
            <h3>Dogodila se sljedeća pogreška:</h3>
            <h4 runat="server" id="errorMessage">Nešto je pošlo po zlu :(</h4>
            <a href="/" class="btn btn-primary">Povratak</a> 
        </div>
    </form>
</body>
</html>
