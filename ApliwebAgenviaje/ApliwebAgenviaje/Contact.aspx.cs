using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApliwebAgenviaje.com;
using System.Data;
using System.Data.SqlClient;
using LibAgencia;
using ApliwebAgenviaje.com.somee.hotelvalparaiso;

namespace ApliwebAgenviaje
{
    public partial class Contact : Page
    {



        //combobox comodidad
        private void selecttipocomodidad()
        {
            com.somee.serviceshotel.WServiceHotel objcon = new com.somee.serviceshotel.WServiceHotel();
            select.DataSource = objcon.ListarServicios();


            selectde.DataSource = objcon.ListarServicios();

            selectde.DataTextField = "Descripcion";
            selectde.DataValueField = "precio";

            selectde.DataBind();
        }

        //combobox servicio
        private void selecttiposervi()
        {
            com.somee.serviceshotel.WServiceHotel objcon = new com.somee.serviceshotel.WServiceHotel();
            select.DataSource = objcon.ListarServicios();
        
            select.DataTextField = "NombreServicio";
            select.DataValueField = "CodServicio";
            


            //limpiar
            select.DataBind();



        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreComple"] == null)
            {
                Response.Redirect("Default.aspx");
            }else
            {

            }

            if (!IsPostBack)
            {
                selecttiposervi();
                selecttipocomodidad();
                selectvalparaiso();
                selecttiposerviparaiso();
            }
        }


        //combobox principal hotel 1
        protected void select_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selecttipocomodidad();

                selectde.SelectedIndex = select.SelectedIndex;

                com.somee.serviceshotel.WServiceHotel objcon = new com.somee.serviceshotel.WServiceHotel();
                int codigo = Convert.ToInt32(select.SelectedValue);
                string nombre = select.SelectedItem.Text;
                string detalle = selectde.SelectedItem.Text;
                int precio = Convert.ToInt32(selectde.SelectedValue);

                objcon.ObtenerServicio(nombre);
                objcon.ObtenerServicio(detalle);
                txthot.Text = codigo.ToString();
                txtnom.Text = nombre.ToString();
                txtdeta.Text = detalle.ToString();
                txtval.Text = precio.ToString();

            }catch(Exception ex)
            {
                alert.Visible = true;
                alert.Text = "Producto vencido";
            }
        }


        //consultar servicios hotel 1
        protected void Button1_Click(object sender, EventArgs e)
        {
            com.somee.serviceshotel.WServiceHotel objcon = new com.somee.serviceshotel.WServiceHotel();

            DataTable TablaConsul;

            if (string.IsNullOrEmpty(txtnom.Text))
            {
                TablaConsul = objcon.ListarServicios();
            }
            else
            {
                TablaConsul = objcon.ObtenerServicio(txtnom.Text);

            }
            GridView1.DataSource = TablaConsul;
            GridView1.DataBind();

        }



        //combobox secundario hotel 1
        protected void selectde_SelectedIndexChanged(object sender, EventArgs e)
        {



            select.SelectedIndex = selectde.SelectedIndex;

            com.somee.serviceshotel.WServiceHotel objcon = new com.somee.serviceshotel.WServiceHotel();
            int codigo = Convert.ToInt32(select.SelectedValue);
            string nombre = select.SelectedItem.Text;
            string detalle = selectde.SelectedItem.Text;
            int precio = Convert.ToInt32(selectde.SelectedValue);

            objcon.ObtenerServicio(nombre);
            objcon.ObtenerServicio(detalle);
            txthot.Text = codigo.ToString();
            txtnom.Text = nombre.ToString();
            txtdeta.Text = detalle.ToString();
            txtval.Text = precio.ToString();
        }




        //guardar datos capturados
        protected void btnsave_Click(object sender, EventArgs e)
        {


            this.alert.Visible = false;
            this.wel.Visible = false;
            
                string name = txtnom.Text.Trim();
            int valor = Convert.ToInt32(txtval.Text.Trim());
            string descp = txtdeta.Text.Trim();
            int id = Convert.ToInt32(txthot.Text.Trim());

            int stado = 1;


            
                LibAgenciaViaje objsave = new LibAgenciaViaje();

                objsave.Nameservi = name;
                objsave.Valorservi = valor;
                objsave.Descripcion = descp;
                objsave.Id_detalle = id;
                objsave.SetState = stado;
                if (name == "")
                {
                    alert.Visible = true;
                    this.alert.Text = "no existe nombre servicio";

                    return;
                }
                if (valor == 0)
                {
                    alert.Visible = true;
                    this.alert.Text = "no hay valor";

                    return;
                }
                if (descp == "")
                {
                    alert.Visible = true;
                    this.alert.Text = "no hay descripcion";

                    return;
                }
                if (id == 0)
                {
                    alert.Visible = true;
                    this.alert.Text = "no hay id";

                    return;
                }


                if (!objsave.savedetal())
                {
                    this.alert.Visible = true;
                    this.alert.Text = objsave.GetError;

                }
                else
                {
                    this.wel.Visible = true;
                    this.wel.Text = "Paqueteria adquerida, dirigiendose a venta...";
                    Response.Redirect("~/Regist");
                }



            try
            {
            }
            catch (Exception ex)
            {
                this.alert.Visible = true;
                this.alert.Text = ex.Message;
            }

        }












        // HOTEL VAL PARAISO CODE



        //metodo combobox hotel 2 principal
        private void selectvalparaiso()
        {
            try
            {
                HotelWS objconsul = new HotelWS();

                selectedhotel2.DataSource = objconsul.ListarServicios();


                selectedhotel2.DataSource = objconsul.ListarServicios();

                selectedhotel2.DataTextField = "descripcion";
                selectedhotel2.DataValueField = "cod_servicio";

                selectedhotel2.DataBind();
            }catch(Exception ex)
            {
                alert.Text = "Error con el servidor, por favor cierra la pagina y abrirela de nuevo, disculpe las molestias";
            }
        }



        //metodo combobox hotel 2 secundario
        private void selecttiposerviparaiso()
        {
            HotelWS objconsul = new HotelWS();
            Selectedhotel2deta.DataSource = objconsul.ListarServicios();

            Selectedhotel2deta.DataTextField = "disponibilidad";
            Selectedhotel2deta.DataValueField = "costo";



            //limpiar
            Selectedhotel2deta.DataBind();



        }




        //consultar hotel 2
        protected void btnconsul2_Click(object sender, EventArgs e)
        {
            HotelWS objconsul = new HotelWS();

            DataSet datosvalpara;

            if (string.IsNullOrEmpty(txtid2.Text))
            {
                datosvalpara = objconsul.ListarServicios();
            }
            else
            {
                datosvalpara = objconsul.BuscarServicios(txtid2.Text);

            }
            datos2.DataSource = datosvalpara;
            datos2.DataBind();

        }




        //combobox hotel 2 principal
        protected void selectedhotel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                selecttiposerviparaiso();

                Selectedhotel2deta.SelectedIndex = selectedhotel2.SelectedIndex;

                HotelWS objconsul = new HotelWS();
                int codigo = Convert.ToInt32(selectedhotel2.SelectedValue);
                string nombre = selectedhotel2.SelectedItem.Text;
                string detalle = Selectedhotel2deta.SelectedItem.Text;
                int precio = Convert.ToInt32(Selectedhotel2deta.SelectedValue);

               
                txtid2.Text = codigo.ToString();
                txtnom2.Text = nombre.ToString();
                txtdesc2.Text = detalle.ToString();
                txtval2.Text = precio.ToString();
            
            }
            catch (Exception ex)
            {
                alert.Visible = true;
                alert.Text = "Producto vencido";
            }
        }



        //combobox hotel 2 secundario
        protected void Selectedhotel2deta_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedhotel2.SelectedIndex = Selectedhotel2deta.SelectedIndex;

            HotelWS objconsul = new HotelWS();
            int codigo = Convert.ToInt32(selectedhotel2.SelectedValue);
            string nombre = selectedhotel2.SelectedItem.Text;
            string detalle = Selectedhotel2deta.SelectedItem.Text;
            int precio = Convert.ToInt32(Selectedhotel2deta.SelectedValue);

            objconsul.BuscarServicios(nombre);
            objconsul.BuscarServicios(detalle);
            txtid2.Text = codigo.ToString();
            txtnom2.Text = nombre.ToString();
            txtdesc2.Text = detalle.ToString();
            txtval2.Text = precio.ToString();
        }



        //guardar datos capturados hotel 2
        protected void btnadqui2_Click(object sender, EventArgs e)
        {
            this.alert.Visible = false;
            this.wel.Visible = false;

            string name = txtnom2.Text.Trim();
            int valor = Convert.ToInt32(txtval2.Text.Trim());
            string descp = txtdesc2.Text.Trim();
            int id = Convert.ToInt32(txtid2.Text.Trim());

            int stado = 1;



            LibAgenciaViaje objsave = new LibAgenciaViaje();

            objsave.Nameservi = name;
            objsave.Valorservi = valor;
            objsave.Descripcion = descp;
            objsave.Id_detalle = id;
            objsave.SetState = stado;
            if (name == "")
            {
                alert.Visible = true;
                this.alert.Text = "no existe nombre servicio";

                return;
            }
            if (valor == 0)
            {
                alert.Visible = true;
                this.alert.Text = "no hay valor";

                return;
            }
            if (descp == "")
            {
                alert.Visible = true;
                this.alert.Text = "no hay descripcion";

                return;
            }
            if (id == 0)
            {
                alert.Visible = true;
                this.alert.Text = "no hay id";

                return;
            }


            if (!objsave.savedetal())
            {
                this.alert.Visible = true;
                this.alert.Text = objsave.GetError;

            }
            else
            {
                this.wel.Visible = true;
                this.wel.Text = "Paqueteria adquerida, dirigiendose a venta...";
                Response.Redirect("~/Regist");
            }



            try
            {
            }
            catch (Exception ex)
            {
                this.alert.Visible = true;
                this.alert.Text = ex.Message;
            }

        }
    }
    }
