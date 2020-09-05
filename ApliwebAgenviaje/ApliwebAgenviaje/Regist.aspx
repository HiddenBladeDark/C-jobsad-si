<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Regist.aspx.cs" Inherits="ApliwebAgenviaje.Regist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <asp:Image ID="Image2"  runat="server" ImageUrl="~/Content/images/agencia3.jpg" AlternateText="Logo" Height="308px" style="margin-right: 0px; margin-bottom: 0px" Width="1020px"/>
      <div class="panel panel-primary">
   <div class="panel-heading">  <p class="lead" style="text-align: center">COMPRA TU PAQUETE</p></div>

    <table class="nav-justified" style="width: 98%">
        
        <tr>
            <td class="text-center" colspan="2" style="height: 20px"><strong>VENDEDOR</strong></td>
            <td style="height: 20px"></td>
            <td rowspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="2" style="height: 20px">
                <asp:DropDownList ID="empledesple" runat="server" AutoPostBack="True" Height="19px" OnSelectedIndexChanged="empledesple_SelectedIndexChanged" Width="255px">
                </asp:DropDownList>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" rowspan="2">
                <asp:Panel ID="panelfac" runat="server" Height="270px" Visible="False" Width="563px" style="background-color: #EEEEEE">
                    <table class="nav-justified" style="height: 259px">
                        <tr>
                            <td class="text-center" colspan="4" style="height: 33px; color: #FFFFFF; font-weight: bold; background-color: #337AB7">FACTURA</td>
                        </tr>
                        <tr>
                            <td class="text-center" colspan="2" style="height: 37px"><strong>COD EMPLEADO</strong></td>
                            <td colspan="2" style="height: 37px">
                                <asp:TextBox ID="txtcod" runat="server" ReadOnly="True" Width="53px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center" colspan="2" style="height: 37px"><strong>COD F</strong><span style="font-weight: bold">ACTURA</span></td>
                            <td colspan="2" style="height: 37px">
                                <asp:DropDownList ID="factura" runat="server" Enabled="False" Height="27px" Width="215px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center" colspan="2" style="height: 37px; font-weight: bold;">CEDULA CLIENTE</td>
                            <td colspan="2" style="height: 37px">
                                <asp:TextBox ID="txtcedclient" runat="server" Width="215px" Height="27px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center" colspan="2" style="height: 22px"><strong>DETALLE PAQUETE</strong></td>
                            <td colspan="2" style="height: 22px">
                                <asp:DropDownList ID="paquetede" runat="server" AutoPostBack="True" Enabled="False" Height="24px" OnSelectedIndexChanged="paquetede_SelectedIndexChanged" Width="215px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 33px"></td>
                            <td style="width: 324px; height: 33px" class="text-center"><strong>VALOR PAQUETE</strong><asp:DropDownList ID="precioulti" runat="server" Enabled="False" Height="26px" Visible="False" Width="87px">
                                </asp:DropDownList>
                            </td>
                            <td style="height: 33px">
                                <asp:TextBox ID="txtvalpa" runat="server" Width="215px" Height="27px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="height: 33px"></td>
                        </tr>
                        <tr>
                            <td style="height: 20px"></td>
                            <td style="width: 324px; height: 20px;">
                                <asp:Button ID="Button1" runat="server" BorderStyle="Solid" CssClass="btn btn-primary btn-lg" Height="47px" OnClick="Button1_Click1" OnClientClick="~/About" style="font-weight: bold; color: #FFFFFF; background-color: #3399FF" Text="CONSULTA" />
                            </td>
                            <td style="height: 20px">
                                <asp:Button ID="Button2" runat="server" BorderStyle="Solid" CssClass="btn btn-primary btn-lg" Height="47px" OnClick="Button2_Click2" OnClientClick="~/About" style="font-weight: bold; color: #FFFFFF; background-color: #3399FF" Text="GENERAR" />
                            </td>
                            <td style="height: 20px"></td>
                        </tr>
                        <tr>
                            <td style="height: 20px"></td>
                            <td style="width: 324px; " rowspan="3">
                                &nbsp;</td>
                            <td style="height: 20px">&nbsp;</td>
                            <td style="height: 20px"></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                                                <asp:GridView ID="GridView1" runat="server" Height="189px" Width="204px">
                                                                </asp:GridView>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                             
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 90px">
                <asp:Panel ID="panelregis" runat="server" Height="270px" Visible="False" Width="584px" style="background-color: #EEEEEE; margin-top: 0px; margin-left: 28px;">
                    <table class="nav-justified" style="height: 257px; width: 100%;">
                        <tr>
                            <td class="text-center" colspan="4" style="height: 30px; color: #FFFFFF; background-color: #337AB7"><strong>REGISTRO EMPLEADO</strong></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 33px"><span style="font-weight: bold">INGRESE CEDULA EMPLEADO</span></td>
                            <td colspan="2" style="height: 33px">
                                <asp:TextBox ID="txtced" runat="server" style="margin-left: 101" Width="230px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 32px"><span style="font-weight: bold">INGRESE NOMBRE COMPLETO</span></td>
                            <td colspan="2" style="height: 32px">
                                <asp:TextBox ID="txtnom" runat="server" style="margin-left: 101" Width="230px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"><span style="font-weight: bold">INGRESE TELEFONO</span></td>
                            <td colspan="2">
                                <asp:TextBox ID="txttel" runat="server" style="margin-left: 101" Width="228px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 28px"><span style="font-weight: bold">INGRESE EMAIL</span></td>
                            <td colspan="2" style="height: 28px">
                                <asp:TextBox ID="txtemail" runat="server" style="margin-left: 101" Width="230px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 32px"></td>
                            <td colspan="2" style="height: 32px"></td>
                        </tr>
                        <tr>
                            <td style="height: 39px"></td>
                            <td class="text-center" style="width: 445px; " rowspan="2">
                                <strong>
                                <asp:Button ID="btngua" CssClass="btn btn-primary btn-lg" runat="server" BorderStyle="Solid" OnClick="Button1_Click" style="color: #FFFFFF; background-color: #3399FF; font-weight: bold;" Text="GUARDAR" Width="137px" />
                                </strong>
                            </td>
                            <td colspan="2" style="height: 39px"></td>
                        </tr>
                        <tr>
                            <td style="height: 30px"></td>
                            <td style="height: 30px"></td>
                            <td style="height: 30px"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        </table>
          </div>

      </div>



        <tr>
            <td style="height: 20px">
                <asp:Label ID="alerts" runat="server" Text="."></asp:Label>
            </td>
            <td style="height: 20px">
                &nbsp;</td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
    
    </div>
</asp:Content>


