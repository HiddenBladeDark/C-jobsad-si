using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApliwebAgenviaje
{
    public partial class SiteMaster : MasterPage
    {
        


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["NombreComple"].ToString() == "")
                {
                    Response.Redirect("login.aspx");
                }
                else
                {




                    
                    nombre.InnerText = Session["NombreComple"].ToString();
                    registrocerrar.InnerText = "Cerrar sesion";

                    nombre.Visible = true;
                    registrocerrar.Visible = true;


                    registro.Visible = false;
                    iniciar.Visible = false;


                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}