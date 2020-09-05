<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ApliwebAgenviaje._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1><strong>Agencia Viaje LAB.SCSJ</strong></h1>
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
        <li data-target="#myCarousel" data-slide-to="3"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">
        <div class="item active">
                    <asp:Image ID="Image2"  runat="server" ImageUrl="~/Content/images/japan.jpg" AlternateText="Logo" Height="429px" style="margin-right: 0px; margin-bottom: 0px" Width="1117px"/>

        </div>
        <div class="item">
                    <asp:Image ID="Image1"  runat="server" ImageUrl="~/Content/images/agencia1.jpg" AlternateText="Logo" Height="429px" style="margin-right: 0px; margin-bottom: 0px" Width="1075px"/>

        </div>
       <div class="item">
                    <asp:Image ID="Image3"  runat="server" ImageUrl="~/Content/images/agencia2.jpg" AlternateText="Logo" Height="429px" style="margin-right: 0px; margin-bottom: 0px" Width="1075px"/>

        </div>
        <div class="item">
                    <asp:Image ID="Image4"  runat="server" ImageUrl="~/Content/images/agencia3.jpg" AlternateText="Logo"  Height="429px" style="margin-right: 0px; margin-bottom: 0px" Width="1075px"/>

        </div>
    </div>

    <!-- Controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right"></span>
        <span class="sr-only">Next</span>
    </a>
</div>




        <div class="panel panel-primary">
        <div class="panel-heading"><p style="height: 29px"><strong>Nuestros aliados principales</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Image ID="Image5"  runat="server" ImageUrl="~/Content/images/logo1.png" AlternateText="Logo"  Height="37px" style="margin-right: 0px; margin-bottom: 0px" Width="79px"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image6"  runat="server" ImageUrl="~/Content/images/logo2.png" AlternateText="Logo"  Height="42px" style="margin-right: 0px; margin-bottom: 0px" Width="70px"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Image ID="Image7"  runat="server" ImageUrl="~/Content/images/logo3.png" AlternateText="Logo"  Height="47px" style="margin-right: 0px; margin-bottom: 0px" Width="90px"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="Image8"  runat="server" ImageUrl="~/Content/images/logo4.png" AlternateText="Logo"  Height="46px" style="margin-right: 0px; margin-bottom: 0px" Width="83px"/>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Image ID="Image9"  runat="server" ImageUrl="~/Content/images/logo-white.png" AlternateText="Logo"  Height="44px" style="margin-right: 0px; margin-bottom: 0px" Width="67px"/>
       </p>

        </div>
    </div>
        </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Sobre Nosotros</h2>
            <p>
                Somos una empresa dedicada a ofrecer las mejores ofertas en paqueteria de viajes, para que disfrutes en familia, ahorrandote un peso en estar buscando cada beneficio en diferentes paginas, aqui encontraras todo lo relacionado!!!</p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Nos dedicamos</h2>
            <p>
                Nos dedicamos en ofrecerte los mejores paquetes en oferta y baratos, aprovecha!!!</p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Contactanos</h2>
            <p>
                <a href="mailto:AgenciaViajeLAB.SCSJ@hotmail.com">AgenciaViajeLAB.SCSJ@hotmail.com</a></p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
