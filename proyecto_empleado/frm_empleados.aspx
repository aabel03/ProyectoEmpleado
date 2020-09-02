<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_empleados.aspx.cs" Inherits="proyecto_empleado.frm_empleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Proyecto Empleados</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <style type="text/css" >
  H2 { text-align: center}
 </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>            
            <div class="container"style=" width: 800px; height: 400px; margin: 0 auto">
            
                 <asp:Button ID="btn_nuevo_empleado" Text="Nuevo Empleado"  runat="server" class="btn btn-success" OnClick="btn_nuevo_empleado_Click"  /> 
    
            
                
                <div id="container" style=" width: 800px; height: 400px; margin: 0 auto">
                    <h2 >Lista de Empleados</h2> 
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"  CssClass ="tabla- tabla-tabla-seccionada-tabla-flotante"
                        
                         OnRowCommand ="GridView1_RowCommand1"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting"  >
                        
                           <Columns> 
                               <asp:TemplateField HeaderText="clave" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Clave_Emp" Text='<%# Eval("Clave_Emp") %>' runat="server" />
                                    </ItemTemplate>                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre Completo">
                                    <ItemTemplate>
                                        <asp:Label ID="nombre" Text='<%# Eval("nombre") %>' runat="server" />
                                    </ItemTemplate>                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Nacimiento">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("fecha_nacimiento") %>' runat="server" />
                                    </ItemTemplate>                                    
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Departamento">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Descripcion") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Sueldo">
                                    <ItemTemplate>
                                        <asp:Label Text='<%# Eval("Sueldo") %>' runat="server" />
                                    </ItemTemplate>                                    
                                </asp:TemplateField>
                                <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                                    <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" OnClientClick="return confirm('¿Desea eliminar el Empleado?');" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                                </ItemTemplate> 
                                    
                            </asp:TemplateField>

                           </Columns>
                           <HeaderStyle CssClass = "thead-dark" />
                    </asp:GridView>

                </div>
                
            
        </div>
        </div>
    </form>
</body>
</html>
