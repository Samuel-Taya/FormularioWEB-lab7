<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebFormularioHTML.WebForm1" %>

<!DOCTYPE html>
<html>
<head>
    <title> Registro</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!--JQuery-->
    <script type="text/javascript" src="/Scripts/jquery-3.4.1.min.js"></script>
    <!-- Bootstrap core CSS -->
    <link rel="stylesheet" href="/Content/bootstrap.min.css" />
    <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="/Scripts/modernizr-2.8.3.js"></script>

    <script type="text/javascript">
        function validar() {
            var nombre = document.getElementById("fname").value;
            var apellido = document.getElementById("lname").value;
            var email = document.getElementById("mail").value;
            var M = document.getElementById("male").checked;
            var F = document.getElementById("female").checked;
            var ciudad = document.getElementById("DropDownList1").value;

            var valnombre = /^[a-zA-Z\s]{1,40}$/;
            var valapellido = /^[a-zA-Z]{1,20}$/;
            var valemail = /^[a-zA-Z0-9_.+-]+@unsa.edu.pe$/;

            if (!valnombre.test(nombre)) {
                alert("Error en Nombre");
                return false;
            }
            if (!valapellido.test(apellido)) {
                alert("Error en Apellidos");
                return false;
            }
            if (M == false && F == false) {
                alert("Sexo no indicado");
                return false;
            }
            if (!valemail.test(email)) {
                alert("Email incorrecto");
                return false;
            }
            if (ciudad == "") {
                alert("Seleccionar una Ciudad");
                return false;
            }
            var fechaRegistro = new Date();
            alert("Registrado a las: " + fechaRegistro);
            return false;
        }
        function limpiar_contenido() {
            var vacio = "";
            document.getElementById("fname").value = vacio;
            document.getElementById("lname").value = vacio;
            document.getElementById("male").checked = false
            document.getElementById("female").checked = false;
            document.getElementById("mail").value = vacio;
            document.getElementById("adress").value = vacio;
            document.getElementById("DropDownList1").value = vacio;
            document.getElementById("req").value = vacio;
            return false;
        }
    </script>
</head>
<body>
    <div class="container-fluid text-center">
    <header>
        <h1>Registro de Alumnos</h1>
    </header>
    <form id="form1" runat="server">
        <br> 
        <!--Nombre-->
        <label for="fname">Nombre:</label>
        <asp:TextBox ID="fname" runat="server" type="text"></asp:TextBox>
         <br> <br> 
        <!--Apellidos-->
        <label for="lname">Apellidos:</label>
        <asp:TextBox ID="lname" runat="server" type="text"></asp:TextBox>
         <br>  <br> 
        <!--sexo-->
        <label>Sexo:</label>
        <div>
            <div>
                <asp:RadioButton ID="male" runat="server" GroupName="sexo"/>
                <label for="male">Masculino</label>
            </div>
            <div>
                <asp:RadioButton ID="female" runat="server" GroupName="sexo"/>
                <label for="female">Femenino</label>
            </div>
        </div>
         <br>
        <!--email-->
        <label for="mail">Email:</label>
        <asp:TextBox ID="mail" runat="server" type="text"></asp:TextBox>
         <br>  <br> 
        <!--Direccion-->
        <label for="adress">Direccion:</label>
        <asp:TextBox ID="adress" runat="server" type="text"></asp:TextBox>
         <br>  <br> 
        <!--ciudad-->
        <label for="city">Ciudad:</label>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
         <br>  <br> 
        <!--area de texto multilinea-->
        <label for="req">Requerimiento:</label>
        <asp:TextBox ID="req" runat="server" Rows="4" class="form-control" placeholder="Requerimiento"></asp:TextBox>
         <br>  <br> 
        <div class="botones">
        <!--boton de limpiar-->
        <asp:Button id="buttonLimpiar" UseSubmitBehavior="false"  runat="server" Text="Limpiar" class="btn btn-primary" OnClientClick="return limpiar_contenido();"/>
        <!--boton de envio-->
        <asp:Button id="buttonEnviar" runat="server" Text="Enviar" OnClientClick="return validar();" class="btn btn-success" OnClick="Enviar"/>
        </div>
    </form>
    </div>
</body>
</html>