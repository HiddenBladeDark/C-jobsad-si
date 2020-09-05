using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgencia;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace ApliwebAgenviaje
{
    public partial class Regist : System.Web.UI.Page
    {
        
       




        //metodo desplegable empleado
        private void LlenarComboEmple()
        {
            this.alerts.Text = "";
            LibAgenciaViaje objdespleemple = new LibAgenciaViaje();
            if (!objdespleemple.LlenarCombEmple(empledesple))
            {
                this.alerts.Text = objdespleemple.GetError;
                return;
            }
        }

        //metodo desplegable factura ultima 
        private void facturaultima()
        {
            this.alerts.Text = "";
            LibAgenciaViaje objultifac = new LibAgenciaViaje();

            if(!objultifac.facturaulti(factura))
            {
                this.alerts.Text = objultifac.GetError;
                return;
            }
            factura.SelectedIndex = factura.Items.Count - 1;
        }




        //metodo desplegable factura
        private void facturaver()
        {
            this.alerts.Text = "";
            LibAgenciaViaje objfac = new LibAgenciaViaje();
            if (!objfac.consultafactura(factura))
            {
                this.alerts.Text = objfac.GetError;
                return;
            }
            factura.SelectedIndex = factura.Items.Count - 1;
        }


        //metodo desplegable detalle ultimo
        private void detallever()
        {
            this.alerts.Text = "";
            LibAgenciaViaje objdeta = new LibAgenciaViaje();
            if (!objdeta.Llenarcombodeta(paquetede))
            {
                this.alerts.Text = objdeta.GetError;
                return;
            }

            paquetede.SelectedIndex = paquetede.Items.Count - 1;
        }



        //ver ultimo detalle ingresado
        private void detalleverprecio()
        {
            this.alerts.Text = "";
            LibAgenciaViaje objdetase = new LibAgenciaViaje();
            if(!objdetase.llenarcomboprecio(precioulti))
            {
                this.alerts.Text = objdetase.GetError;
                return;
            }
            precioulti.SelectedIndex = precioulti.Items.Count - 1;
            txtvalpa.Text = precioulti.SelectedItem.ToString();
        }


        // cargamos la session iniciada
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["NombreComple"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {

                    txtcedclient.Text = Session["cedula"].ToString();



                }
            }catch(Exception ex)
            {
                alerts.Text = "Lo que estas haciendo es ilegal papu";
            }
                if (!IsPostBack)
            {
                    



                LlenarComboEmple();
                facturaultima();

                detallever();
                detalleverprecio();


            }
        }





        //propiedad desplegable empleado
        protected void empledesple_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelfac.Visible = false;
            this.panelregis.Visible = false;
            int Id_emp = Convert.ToInt32(empledesple.SelectedValue); //Selecion ID Orden Numerico que esta oculto en LN
           
            if (Id_emp >= 9999)
            {
                

                this.panelregis.Visible = true;
                
                this.txtced.Text = "";
                
                this.txttel.Text = "";
                this.txtemail.Text = "";
                this.txtced.Focus();    


            }
            else if (Id_emp > 0 && Id_emp < 99999)
            {
                facturaultima();
                detallever();

                panelfac.Visible = true;
                this.txtcod.Text = Id_emp.ToString();
                this.txtcedclient.Text = Session["cedula"].ToString();
                
                return;
            }
        }




        //guardar empleado
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int CedulaEmple = Convert.ToInt32(txtced.Text.Trim());
                String NombreEmpl = this.txtnom.Text.Trim();
                String phone = this.txttel.Text.Trim();
                String email = this.txtemail.Text.Trim();
                int estado = 1;

                if (CedulaEmple <= 0)
                {
                    this.alerts.Text = "No se ingrego Cedula";
                    this.txtced.Focus();
                    return;
                }
                if (NombreEmpl == "")
                {
                    this.alerts.Text = "No se ingreso Nombre ";
                    this.txtnom.Focus();
                    return;
                }
                if (phone == "")
                {
                    this.alerts.Text = "No se ingreso Nombre";
                    this.txttel.Focus();
                    return;
                }
                if (email == "")
                {
                    this.alerts.Text = "No se ingreso Nombre";
                    this.txtemail.Focus();
                    return;
                }


                LibAgenciaViaje objGuardarEm = new LibAgenciaViaje();
                objGuardarEm.SetCedula = CedulaEmple;
                objGuardarEm.SetName = NombreEmpl;
                objGuardarEm.SetPhone = phone;
                objGuardarEm.SetEmail = email;
                objGuardarEm.SetState = estado;
                if (!objGuardarEm.SaveEmple())
                {
                    this.alerts.Text = objGuardarEm.GetError;
                    this.txtced.Focus();
                    return;

                }


                LlenarComboEmple();
                this.panelregis.Visible = false;
                LlenarComboEmple();
                //LlenarTabla();

                this.empledesple.Items.FindByValue(Convert.ToString(objGuardarEm.GetRespuesta)).Selected = true;

            }
            catch (Exception ex)
            {
                alerts.Text = ex.Message;
            }
        }

        


        //redireccionar
        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultaFact");
        }


        //guardar factura
        protected void Button2_Click2(object sender, EventArgs e)
        {
            

            LibAgenciaViaje objfactu = new LibAgenciaViaje();
            
            objfactu.SetCedula = Convert.ToInt32(txtcedclient.Text);
            objfactu.Id_empleado = Convert.ToInt32(txtcod.Text);
            objfactu.Id_detalle = Convert.ToInt32(paquetede.SelectedValue);
            objfactu.Subtotal = Convert.ToInt32(txtvalpa.Text);
            objfactu.Factura_id = Convert.ToInt32(factura.SelectedValue);


           


            if (!objfactu.facturacion() && !objfactu.savemov())
          
                {
                    this.alerts.Text = objfactu.GetError;
                    this.txtced.Focus();
                    return;

                }
            else
            {

                Response.Redirect("~/ConsultaFact");

            }

        }

        protected void paquetede_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
       
    }
