using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ApliwebAgenviaje.localhost;
using ApliwebAgenviaje.com;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace ApliwebAgenviaje
{
    public partial class ConsultaFact : System.Web.UI.Page
    {

        private void Consultafacturas()
        {
            try {
                if (Session["NombreComple"].ToString() == "")
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {

                    txtced.Text = Session["cedula"].ToString();



                }





            }catch(Exception ex)
            {   }
            }


        protected void Page_Load(object sender, EventArgs e)
        {
            Consultafacturas();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            com.somee.agenciaviajeabjsanti.AgenciaViajeLAB_SCSJ objconsul = new com.somee.agenciaviajeabjsanti.AgenciaViajeLAB_SCSJ();
            DataSet TablaConsul;

            
                TablaConsul = objconsul.Consultar_Factura(Convert.ToInt32(txtced.Text));
            
            GridView1.DataSource = TablaConsul;
            GridView1.DataBind();


        }
    }
}