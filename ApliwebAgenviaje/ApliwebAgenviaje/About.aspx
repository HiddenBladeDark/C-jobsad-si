<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ApliwebAgenviaje.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <asp:Image ID="Image2"  runat="server" ImageUrl="~/Content/images/agencia8.jpg" AlternateText="Logo" Height="308px" style="margin-right: 0px; margin-bottom: 0px" Width="1020px"/>
      <div class="panel panel-primary">
   <div class="panel-heading">  <p class="lead" style="text-align: center">CONSULTA TU AEROLINEA IDEAL</p></div>

    <table class="nav-justified" style="height: 220px; width: 82%; margin-left: 90px">
       
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" style="height: 37px"><strong>CONSULTA AEROLINEA</strong></td>
            <td style="height: 37px">
                <asp:TextBox ID="TextBox1" runat="server" Width="198px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 37px"></td>
            <td style="height: 37px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="text-center">
                <asp:Button ID="Button1" CssClass="btn btn-primary btn-lg" runat="server" style="color: #FFFFFF; background-color: #3399FF" Text="CONSULTAR" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
          </div>
      </div>
</asp:Content>
