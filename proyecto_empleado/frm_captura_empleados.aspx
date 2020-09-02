<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_captura_empleados.aspx.cs" Inherits="proyecto_empleado.frm_captura_empleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
  <script src="../validaciones.js" type="text/javascript"></script>  
</head>
<body>
    <form id="form1" runat="server" class="needs-validation">
        <div class="form-group">
                        
            <h2>Captura o Modifica Empleado</h2>
            <div class="col-md-4 mb-3"  >

                <label>Clave </label>
                <asp:TextBox id="txt_clave" runat="server" CssClass="form-control"  onkeypress="return solonumeros(event)"  >

                </asp:TextBox>
            </div>
            
            <div class="invalid-feedback">Dato Obligatorio</div>
            <div class="col-md-4 mb-3" >

                <label>Nombre </label>
                <asp:TextBox id="txt_nombre" runat="server" CssClass="form-control" onkeypress= "return sololetras(event)" >

                </asp:TextBox>
            </div>
            <div class="col-md-4 mb-3" >

                <label>Apellido Paterno </label>
                <asp:TextBox id="txt_apellido_p" runat="server" CssClass="form-control" onkeypress= "return sololetras(event)"  >

                </asp:TextBox>
            </div>
            <div class="col-md-4 mb-3" >

                <label>Apellido Materno </label>
                <asp:TextBox id="txt_apellido_m" runat="server" CssClass="form-control" onkeypress= "return sololetras(event)"  >

                </asp:TextBox>
            </div>
            <div class="col-md-4 mb-3" >

                <label>Departamento </label>
                <asp:DropDownList ID="cmb_departamentos" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="cmb_departamentos_SelectedIndexChanged" AppendDataBoundItems="True" >
                    
                </asp:DropDownList>
            </div>
             <div class="col-md-4 mb-3" >

                <label>Sueldo </label>
                <asp:TextBox id="txt_sueldo" runat="server"  CssClass="form-control" onkeypress="return filterFloat(event,this)" >

                </asp:TextBox>
            </div>
            <div class="col-md-4 mb-3" >
                 <label>Fecha Nacimiento </label>
                <asp:Calendar ID="dtp_fecha_nacimiento" runat="server" OnSelectionChanged="dtp_fecha_nacimiento_SelectionChanged"></asp:Calendar  >
            </div>
            <div class="""> <asp:Button ID="btn_guardar" Text="Guardar"  runat="server" CssClass="btn btn-success" OnClick="btn_guardar_Click"  /> 

           
              <asp:Button ID="btn_cancelar" Text="Cancelar"  runat="server"  CssClass="btn btn-danger" OnClick="btn_cancelar_Click"  /> 

            </div>
        </div>

    </form>
</body>
</html>
