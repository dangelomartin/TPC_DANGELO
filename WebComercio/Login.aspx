<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebComercio.Login" %>

<!DOCTYPE html>

<html class="bg-black" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso al Sistema</title>
    <meta charset="utf-8"/>
	<meta name="viewport" content="width=device-widtg,initial-scale=1, shrink-to-fit=no"/>
	<meta http-equiv="x-ua-compatible" content="ie-edge"/>
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/> 
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />
</head>
<body class="bg-black">
    <div class="form-box" id="login-box">
        <div class="header">Iniciar Sesion</div>
        <form id="form1" runat="server">
            <div class="body bg-gray">
                <div class="form-group">
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese Usuario...."></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" placeholder="Ingrese Contraseña...."></asp:TextBox>
                </div>
            </div>
            <div class="footer">
                <asp:Button ID="btnIngresar" runat="server" Text="Iniciar Secion" CssClass="btn btn-block bg-olive" OnClick="btnIngresar_Click"/>
            </div>
        </form>
    </div>
    <script src="js/jquery-3.3.1.slim.min.js"></script>
	<script src="js/jquery-ui.min.js" type="text/javascript"></script>
	<script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/AdminLTE/app.js" type="text/javascript"></script>
</body>
</html>
