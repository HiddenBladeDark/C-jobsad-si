<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ApliwebAgenviaje.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <asp:Image ID="Image2"  runat="server" ImageUrl="~/Content/images/agencia1.jpg" AlternateText="Logo" Height="308px" style="margin-right: 0px; margin-bottom: 0px" Width="1020px"/>
      <div class="panel panel-primary">
   <div class="panel-heading">  <p class="lead" style="text-align: center">INGRESA A NUESTRA PLATAFORMA CON TU USUARIO!</p></div>

    
     
    <table class="nav-justified" style="width: 50%; margin-left: 206px; margin-top: 7px">

        <tr>
            <td style="width: 287px; height: 20px"></td>
            <td style="height: 20px; width: 117px;"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
       
        <tr>
            <td colspan="2" style="height: 43px" class="text-right">INGRESE SU CEDULA&nbsp;&nbsp;&nbsp; </td>
            <td colspan="2" style="height: 43px">
                <asp:TextBox ID="txtced" runat="server" Width="151px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="text-right">INGRESE SU NOMBRE COMPLETO&nbsp;&nbsp;&nbsp; </td>
            <td colspan="2">
                <asp:TextBox ID="txtnom" runat="server" Width="151px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 20px"></td>
            <td colspan="2" style="height: 20px">
                </td>
        </tr>
        <tr>
            <td style="width: 287px; height: 20px">&nbsp;</td>
            <td style="height: 20px; width: 117px;"></td>
            <td style="height: 20px">
                &nbsp;</td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 287px; height: 20px" class="text-right">&nbsp;</td>
            <td style="height: 20px; width: 117px;"><strong>
                <asp:Button ID="Button2" CssClass="btn btn-danger btn-ms" runat="server" Text="REGISTRATE"  OnClick="Button2_Click" />
                </strong></td>
            <td class="text-right" rowspan="2">&nbsp;</td>
            <td style="height: 20px" class="text-right"><strong>
                <asp:Button ID="Button1" CssClass="btn btn-success btn-ms"  runat="server" OnClick="Button1_Click"  Text="INGRESAR"  />
                </strong></td>
        </tr>
       </div>
</div>

        <tr>
           
            <td style="width: 287px; height: 125px"><strong>
                <asp:Label ID="alerts" runat="server" style="color: #FFFFFF; font-size: medium; background-color: #33CC33" Text="." Visible="False"></asp:Label>
                <asp:Label ID="alertaerror" runat="server" style="color: #FFFFFF; font-size: medium; background-color: #FF0000" Text="." Visible="False"></asp:Label>
                </strong></td>
            <td style="height: 125px; width: 117px;"></td>
            <td style="height: 125px"></td>
        </tr>
    </table>
       
    </div>


     </div>


</div>


</asp:Content>
