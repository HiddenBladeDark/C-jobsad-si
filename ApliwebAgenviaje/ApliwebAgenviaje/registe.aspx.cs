using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgencia;

namespace ApliwebAgenviaje
{
    public partial class registe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int cedulaclient = Convert.ToInt32(txtced.Text.Trim());
                String Nombreclient = this.txtnom.Text.Trim();
                String phone = this.txttel.Text.Trim();
                String email = this.txtema.Text.Trim();
                int estado = 1;

                if (cedulaclient <= 0)
                {
                    alertaerror.Visible = true;
                    this.alertaerror.Text = "No se ingrego Cedula";
                    this.txtced.Focus();
                    return;
                }
                if (Nombreclient == "")
                {
                    alertaerror.Visible = true;
                    this.alertaerror.Text= "No se ingreso Nombre";
                    this.txtnom.Focus();
                    return;
                }
                if (phone == "")
                {
                    alertaerror.Visible = true;
                    this.alertaerror.Text = "No se ingreso telefono";
                    this.txttel.Focus();
                    return;
                }
                if (email == "")
                {
                    alertaerror.Visible = true;
                    this.alertaerror.Text = "No se ingreso email";
                    this.txtema.Focus();
                    return;
                }


                LibAgenciaViaje objGuardarclien = new LibAgenciaViaje();
                objGuardarclien.SetCedula = cedulaclient;
                objGuardarclien.SetName = Nombreclient;
                objGuardarclien.SetPhone = phone;
                objGuardarclien.SetEmail = email;
                objGuardarclien.SetState = estado;
                if (!objGuardarclien.SaveClient())
                {
                    alertaerror.Visible = true;
                    this.alerts.Text = objGuardarclien.GetError;
                    this.txtced.Focus();
                    return;

                }
                else
                {
                    alertaerror.Visible = false;
                    alerts.Visible = true;
                    this.alerts.Text = "Registro exitoso!!!";
                    return;
                }
            }
            catch (Exception ex)
            {
                
                alerts.Text = ex.Message;
            }
        }
    }
}