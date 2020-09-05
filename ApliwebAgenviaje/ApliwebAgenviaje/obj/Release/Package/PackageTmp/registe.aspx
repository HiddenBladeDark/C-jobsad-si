<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registe.aspx.cs" Inherits="ApliwebAgenviaje.registe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <asp:Image ID="Image2"  runat="server" ImageUrl="~/Content/images/agencia4.jpg" AlternateText="Logo" Height="308px" style="margin-right: 0px; margin-bottom: 0px" Width="1020px"/>
      <div class="panel panel-primary">
   <div class="panel-heading">  <p class="lead" style="text-align: center">REGISTRATE EN NUESTRA AGENCIA DE VIAJE PARA RECIBIR DESCUENTOS EXCLUSIVOS </p></div>

    
     
    <table class="nav-justified" style="width: 74%; margin-left: 90px; margin-top: 7px">

        <tr>
            <td style="width: 287px; height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
       
        <tr>
            <td colspan="2" style="height: 20px">INGRESE SU CEDULA</td>
            <td colspan="2" style="height: 20px">
                <asp:TextBox ID="txtced" runat="server" Width="225px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">INGRESE SU NOMBRE COMPLETO</td>
            <td colspan="2">
                <asp:TextBox ID="txtnom" runat="server" Width="225px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">INGRESE SU TELEFONO</td>
            <td colspan="2">
                <asp:TextBox ID="txttel" runat="server" Width="225px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 287px; height: 20px">INGRESE SU EMAIL</td>
            <td style="height: 20px"></td>
            <td style="height: 20px">
                <asp:TextBox ID="txtema" runat="server" Width="225px"></asp:TextBox>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 287px; height: 20px"></td>
            <td style="height: 20px"></td>
            <td class="text-right" rowspan="2"><strong>
                <asp:Button ID="Button1" CssClass="btn btn-success btn-ms"  runat="server" OnClick="Button1_Click"  Text="REGISTRATE" />
                </strong></td>
            <td style="height: 20px"></td>
        </tr>
       </div>
</div>

        <tr>
           
            <td style="width: 287px; height: 125px"><strong>
                <asp:Label ID="alerts" runat="server" style="color: #FFFFFF; font-size: medium; background-color: #33CC33" Text="." Visible="False"></asp:Label>
                <asp:Label ID="alertaerror" runat="server" style="color: #FFFFFF; font-size: medium; background-color: #FF0000" Text="." Visible="False"></asp:Label>
                </strong></td>
            <td style="height: 125px"></td>
            <td style="height: 125px"></td>
        </tr>
    </table>
       
    </div>
       
</div>
    </div>
       
</asp:Content>
