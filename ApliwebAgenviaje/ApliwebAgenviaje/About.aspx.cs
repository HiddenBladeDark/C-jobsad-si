using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApliwebAgenviaje
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreComple"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {

            }

        }
    }
}