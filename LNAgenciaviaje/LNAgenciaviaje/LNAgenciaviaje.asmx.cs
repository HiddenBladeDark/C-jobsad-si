using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LibBasica;
using System.Data;

namespace LNAgenciaviaje
{
    /// <summary>
    /// Descripción breve de LNAgenciaviaje
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class LNAgenciaviaje : System.Web.Services.WebService
    {

        #region Atributos 

        private string strNomTabla;  // nombre  de la table para la consulta

        private string strSql;       // nombre del procedimiento almacenado 

        private clsConexBd objConBd;   // objeto conexión (se debe referenciar y  usar la librería básica con  la que han estado trabajando actualmente  


        #endregion


        #region metodo_publico
        public LNAgenciaviaje()
        {
            strNomTabla = "Cliente";

        }

        //Listar los clientes
        [WebMethod(Description = "Ver los clientes registrados")]
        public DataTable ListarClientes()
        {
            objConBd = new clsConexBd();

            strSql = "SELECT * FROM cliente";

            objConBd.gsNomTabla = strNomTabla;
            objConBd.gsSql = strSql;

            if (objConBd.GetDataSet(true))
            {
                DataTable dtCli;

                dtCli = objConBd.gDataSet.Tables[strNomTabla];

                objConBd.CerrarConexion(); objConBd = null;

                return dtCli;
            }
            else
            {
                objConBd = null;
                return null;
            }
        }




        //Consultar cliente por medio del nit
        [WebMethod(Description = "Imprimir factura")]
        public DataTable ObtonerFactura(string p_strNit)    
        {
            if (String.IsNullOrEmpty(p_strNit))
            {
                return null;
            }


            objConBd = new clsConexBd();

            strSql = "USP_Mostrar_Factura";

            objConBd.gsNomTabla = strNomTabla;
            objConBd.gsSql = strSql;


            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@cedula_cliente", SqlDbType.Int, 20, p_strNit))
            {
                objConBd = null; return null;
            }

            if (objConBd.GetDataSet(true))
            {
                DataTable dtCli;

                dtCli = objConBd.gDataSet.Tables[strNomTabla];

                objConBd.CerrarConexion(); objConBd = null;

                return dtCli;
            }
            else { objConBd = null; return null; }
        }



        //Consultar cliente por medio del nit
        [WebMethod(Description = "Consulta cliente")]
        public DataTable ConsultaCliente(string p_strNit)
        {
            if (String.IsNullOrEmpty(p_strNit))
            {
                return null;
            }


            objConBd = new clsConexBd();

            strSql = "USP_ConsultarCliente";

            objConBd.gsNomTabla = strNomTabla;
            objConBd.gsSql = strSql;


            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@cedula", SqlDbType.Int, 20, p_strNit))
            {
                objConBd = null; return null;
            }

            if (objConBd.GetDataSet(true))
            {
                DataTable dtCli;

                dtCli = objConBd.gDataSet.Tables[strNomTabla];

                objConBd.CerrarConexion(); objConBd = null;

                return dtCli;
            }
            else { objConBd = null; return null; }
        }





        

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
    #endregion
}
