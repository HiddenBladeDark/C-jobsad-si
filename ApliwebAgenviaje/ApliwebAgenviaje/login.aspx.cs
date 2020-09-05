using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibAgencia;
using System.Data.SqlClient;

namespace ApliwebAgenviaje
{
    public partial class login : System.Web.UI.Page
    {

        


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                LibAgenciaViaje objln = new LibAgenciaViaje();
                string us;
                int ced;
                us = txtnom.Text; 
                ced = Convert.ToInt32(txtced.Text);
                
                objln.SetName = us;
                objln.SetCedula = ced;

                 if (!objln.consultar())
                {
                    alertaerror.Visible = true;
                    alertaerror.Text = "error usuario incorrecto " + objln.GetError;
                }
                SqlDataReader datosuser;
                datosuser = objln.GetReader;
                if (datosuser.HasRows)
                {
                    datosuser.Read();
                    Session["NombreComple"] = objln.Getname;
                      Session["cedula"] = objln.GetCedula;
                    datosuser.Close();
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    alertaerror.Visible = true;
                    this.alertaerror.Text = "El usuario o contraseña no existe favor verificar";

                    return;
                }
            
            }
            catch (Exception ex)
            {
                alertaerror.Visible = true;
                alertaerror.Text = ex.Message;
            }

            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/registe");
        }
    }
}