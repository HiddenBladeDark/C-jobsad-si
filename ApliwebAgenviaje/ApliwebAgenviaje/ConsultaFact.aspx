<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaFact.aspx.cs" Inherits="ApliwebAgenviaje.ConsultaFact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <asp:Image ID="Image2"  runat="server" ImageUrl="~/Content/images/agencia9.jpg" AlternateText="Logo" Height="308px" style="margin-right: 0px; margin-bottom: 0px" Width="1020px"/>
      <div class="panel panel-primary">
   <div class="panel-heading">  <p class="lead" style="text-align: center">CONSULTA TU FACTURA</p></div>


    <table class="nav-justified" style="height: 220px; width: 82%; margin-left: 90px">
       
        <tr>
            <td style="width: 575px; height: 20px;"></td>
            <td style="height: 20px"><strong>INGRESA TU CEDULA</strong></td>
        </tr>
        <tr>
            <td class="text-center" style="width: 575px" rowspan="10">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="554px" Height="302px">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td style="height: 38px">
                <asp:TextBox ID="txtced" runat="server" Width="198px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 38px"></td>
        </tr>
        <tr>
            <td style="height: 38px"></td>
        </tr>
        <tr>
            <td style="height: 38px"></td>
        </tr>
        <tr>
            <td class="text-center" style="height: 38px">
                
                <asp:Button ID="Button1"  runat="server" CssClass="btn btn-primary btn-lg" style="color: #FFFFFF; background-color: #3399FF" Text="CONSULTAR" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td style="height: 38px"></td>
        </tr>
        <tr>
            <td style="height: 38px">
                
            </td>
        </tr>
        <tr>
            <td style="height: 38px"></td>
        </tr>
        <tr>
            <td style="height: 38px"></td>
        </tr>
           </table>
          </div>
      </div>
        <tr>
            <td style="height: 38px">
            </td>
        </tr>
     
        <tr>
            <td style="width: 575px; height: 28px">&nbsp;</td>
            <td class="text-center" style="height: 28px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 575px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    
</div>
</asp:Content>
