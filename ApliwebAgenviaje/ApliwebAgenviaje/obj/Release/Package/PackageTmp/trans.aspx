<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="trans.aspx.cs" Inherits="ApliwebAgenviaje.trans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <asp:Image ID="Image2"  runat="server" ImageUrl="~/Content/images/agencia6.jpg" AlternateText="Logo" Height="308px" style="margin-right: 0px; margin-bottom: 0px" Width="1020px"/>
      <div class="panel panel-primary">
   <div class="panel-heading">  <p class="lead" style="text-align: center">CONSULTA TRANSPORTE</p></div>




    <table class="nav-justified" style="height: 220px; width: 82%; margin-left: 83px">
   
    <tr>
        <td style="width: 589px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 589px; height: 39px"><strong>CONSULTA TRANSPORTE</strong></td>
        <td style="height: 39px">
            <asp:TextBox ID="txttra" runat="server" Width="210px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 589px; height: 39px"></td>
        <td style="height: 39px"></td>
    </tr>
    <tr>
        <td style="width: 589px">&nbsp;</td>
        <td class="text-center">
            <asp:Button ID="btncon" runat="server" CssClass="btn btn-primary btn-lg" Height="45px" style="background-color: #0099FF; color: #FFFFFF;" Text="CONSULTAR" Width="152px" />
        </td>
    </tr>


</table>

    <tr>
        <td style="height: 20px; width: 589px"></td>
        <td style="height: 20px"></td>
    </tr>
                   </div>
</div>




</asp:Content>
