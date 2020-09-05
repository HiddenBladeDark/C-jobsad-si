<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ApliwebAgenviaje.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <asp:Image ID="Image2"  runat="server"   ImageUrl="~/Content/images/agencia5.jpg" AlternateText="Logo" Height="308px" style="margin-right: 0px; margin-bottom: 0px" Width="1020px"/>
      <div class="panel panel-primary">
   <div class="panel-heading">  <p class="lead" style="text-align: center">CONSULTA TU HOTEL IDEAL</p></div>
    <table class="nav-justified" style="height: 220px; width: 86%; margin-left: 74px">
        
        <tr>


            <td style="height: 42px; font-size: x-large;" class="text-center" colspan="2"><strong>SERVICE-HOTEL</strong></td>
           
        </tr>
            

        <tr>
            
            <td class="text-center" style="width: 459px; " rowspan="2">
                 
                <asp:Image ID="Image10" ImageUrl="~/Content/images/agenciacoste.jpg"  runat="server" Height="163px" Width="459px" style="margin-left: 0px; margin-bottom: 14px" />
                <br />
                <p style="font-size: medium; height: 73px; margin-top: 0;" class="bg-primary">
                    <strong>Ubicado en las mejores playas del país, cuenta con varios servicios especiales para ofrecerte, adquiera su paquete ideal.</strong></p>
                <div class="text-center">
                <asp:GridView ID="GridView1" runat="server" Width="459px" CellPadding="3" Height="104px" style="margin-top: 32px; color: #000000;" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </div>
            </td>
            <td style="height: 180px" class="text-center">
                <div class="dropdown show">
                    <strong>
                    <asp:Label ID="Label1" runat="server" style="font-size: large" Text="Selecione lo que te guste"></asp:Label>
                    </strong>
                    </div>
                <asp:DropDownList ID="select" runat="server" AutoPostBack="True" Height="37px" OnSelectedIndexChanged="select_SelectedIndexChanged" Width="223px" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">Seleccione un paquete!!!</asp:ListItem>
                </asp:DropDownList>
                
                <asp:TextBox ID="txthot" runat="server" Width="80px" ReadOnly="True" Visible="False" ></asp:TextBox>
                <asp:TextBox ID="txtnom" runat="server" Width="77px" ReadOnly="True" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtdeta" runat="server" Width="77px" ReadOnly="True" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtval" runat="server" Width="77px" ReadOnly="True" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="selectde" runat="server" AutoPostBack="True" Width="108px" OnSelectedIndexChanged="selectde_SelectedIndexChanged" AppendDataBoundItems="True" Visible="False">
                    <asp:ListItem Value="0">Seleccione un paquete!!!</asp:ListItem>
                </asp:DropDownList>

            </td>
        </tr>
        
        <tr>

            <td style="height: 29px" class="text-right">
                
                <asp:Button ID="Button1" CssClass="btn btn-primary btn-lg" runat="server" style="color: #FFFFFF; background-color: #3399FF" Text="CONSULTAR" OnClick="Button1_Click" Width="151px" />

            </td>
        </tr>
        <tr>
            <td class="text-center" style="width: 459px; height: 41px;"><strong>
                <asp:Label ID="alert" runat="server" style="color: #FFFFFF; background-color: #CC0000" Text="." Visible="False"></asp:Label>
                <asp:Label ID="wel" runat="server" CssClass="label-success" style="color: #FFFFFF" Text="." Visible="False"></asp:Label>
                </strong></td>
            <td style="height: 41px" class="text-right">

                
                <asp:Button ID="btnsave" runat="server" CssClass="btn btn-success btn-lg" style="color: #FFFFFF; background-color: #5cb85c" Text="ADQUIRIR"  Width="151px" OnClick="btnsave_Click" />
            </td>
        </tr>
        <tr>
            <td class="text-center" style="width: 459px; height: 64px;"></td>
            <td style="height: 64px" class="text-right">
                &nbsp;</td>
        </tr>
         </table>
          </div>





       <div class="panel panel-primary">
   <div class="panel-heading">  <p class="lead" style="text-align: center">CONSULTA TU HOTEL IDEAL</p></div>
    <table class="nav-justified" style="height: 220px; width: 86%; margin-left: 74px">
        
        <tr>


            <td style="height: 42px; font-size: x-large; font-weight: bold;" class="text-center" colspan="2">Hotel ValParaiso</td>
           
        </tr>
            

        <tr>
            
            <td class="text-center" style="width: 459px; " rowspan="2">
                 
                <asp:Image ID="Image1" ImageUrl="~/Content/images/agenciaparaiso.jpg"  runat="server" Height="163px" Width="459px" style="margin-left: 0px; margin-bottom: 14px" />
                <br />
                <p style="font-size: medium; height: 73px; margin-top: 0;" class="bg-primary">
                    <strong>Ubicado en la ciudad de la eterna primavera, cuenta con una gran piscina para disfrutas los mejores paisajes que te ofrece el Hotel ValParaiso.</strong></p>
                <div class="text-center">
                    <asp:GridView ID="datos2" runat="server" Height="146px" Width="432px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
            </td>
            <td style="height: 180px" class="text-center">
                <div class="dropdown show">
                    <strong>
                    <asp:Label ID="Label2" runat="server" style="font-size: large" Text="Selecione lo que te guste"></asp:Label>
                    </strong>
                    </div>
                <asp:DropDownList ID="selectedhotel2" runat="server" AutoPostBack="True" Height="33px" Width="223px" OnSelectedIndexChanged="selectedhotel2_SelectedIndexChanged" AppendDataBoundItems="True">
                    <asp:ListItem Value="0">Seleccione un paquete!!!</asp:ListItem>
                </asp:DropDownList>
                
                <asp:TextBox ID="txtid2" runat="server" Width="80px" Visible="False" ></asp:TextBox>
                <asp:TextBox ID="txtnom2" runat="server" Width="86px" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtdesc2" runat="server" Width="77px" ReadOnly="True" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtval2" runat="server" Width="77px" ReadOnly="True" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="Selectedhotel2deta" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Selectedhotel2deta_SelectedIndexChanged" AppendDataBoundItems="True" Visible="False">
                    <asp:ListItem Value="0">Seleccione un paquete!!!</asp:ListItem>
                </asp:DropDownList>

            </td>
        </tr>
        
        <tr>

            <td style="height: 29px" class="text-right">
                
                <asp:Button ID="btnconsul2" runat="server" CssClass="btn btn-primary btn-lg" runat="server" style="color: #FFFFFF; background-color: #3399FF" Text="CONSULTAR" Width="151px" OnClick="btnconsul2_Click" />
                
                

            </td>
        </tr>
        <tr>
            <td class="text-center" style="width: 459px; height: 41px;"><strong>
                <asp:Label ID="Label3" runat="server" style="color: #FFFFFF; background-color: #CC0000" Text="." Visible="False"></asp:Label>
                <asp:Label ID="Label4" runat="server" CssClass="label-success" style="color: #FFFFFF" Text="." Visible="False"></asp:Label>
                </strong></td>
            <td style="height: 41px" class="text-right">

                
                <asp:Button ID="btnadqui2" runat="server" CssClass="btn btn-success btn-lg" style="color: #FFFFFF; background-color: #5cb85c" Text="ADQUIRIR"  Width="151px" OnClick="btnadqui2_Click" />

                
            </td>
        </tr>
        <tr>
            <td class="text-center" style="width: 459px; height: 64px;"></td>
            <td style="height: 64px" class="text-right">
                &nbsp;</td>
        </tr>
         </table>
          </div>


      </div>
        <tr>
            <td style="width: 575px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
   
 
    </div>
</asp:Content>
