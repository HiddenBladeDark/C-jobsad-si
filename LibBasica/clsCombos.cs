using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace LibBasica
{
    public class clsCombos
    {
        #region "Atributos"
        private string strNomTabla;
        private string strSql;
        private string strError;
        private string strColTexto;
        private string strColValor;
        private ComboBox cmbGenerico;
        private DropDownList ddlGenerico;

        private clsConexBd objConBd;

        #endregion

        #region "Propiedades"
        public DropDownList gsDdlGen
        {
            get { return ddlGenerico; }
            set { ddlGenerico = value; }
        }

        public ComboBox gsCmbGen
        {
            get { return cmbGenerico; }
            set { cmbGenerico = value; }
        }

        public string gsNomTabla
        {
            get { return strNomTabla; }
            set { strNomTabla = value; }
        }

        public string gsSql
        {
            get { return strSql; }
            set { strSql = value; }
        }

        public string gsColTexto
        {
            get { return strColTexto; }
            set { strColTexto = value; }
        }

        public string gsColValor
        {
            get { return strColValor; }
            set { strColValor = value; }
        }

        public string gError
        {
            get { return strError; }
        }
        #endregion

        #region "Metodos"

        //Constructor
        public clsCombos()
        {
            objConBd = new clsConexBd();

            //Instruccion Opcional, si desea cambiar la ruta del archivo de parametros
            //objConBd.gsRutaArcParCon = false;
        }

        public bool LlenarDdl()
        {
            if (ValidarDatosBasicos())
            {
                if (ddlGenerico == null)
                {
                    strError = "No definió el combo";
                    return false;
                }

                //Nombre con el cual quiero nombrar el DataTable del DataSet
                objConBd.gsNomTabla = strNomTabla;

                //Instruccion Sql
                objConBd.gsSql = strSql;

                if (objConBd.GetDataSet(false))
                {
                    ddlGenerico.DataSource = objConBd.gDataSet.Tables[strNomTabla];
                    ddlGenerico.DataTextField = strColTexto;
                    ddlGenerico.DataValueField = strColValor;
                    ddlGenerico.DataBind();
                    objConBd.CerrarConexion();
                    objConBd = null;
                    return true;
                }
                else
                {
                    strError = objConBd.gError;

                    objConBd.CerrarConexion();
                    objConBd = null;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool LlenarCmb()
        {
            if (ValidarDatosBasicos())
            {

                objConBd.gsNomTabla = strNomTabla;
                objConBd.gsSql = strSql;
                if (objConBd.GetDataSet(false))
                {
                    cmbGenerico.DataSource = objConBd.gDataSet.Tables[strNomTabla];
                    cmbGenerico.DisplayMember = strColTexto;
                    cmbGenerico.ValueMember = strColValor;

                    objConBd.CerrarConexion();
                    objConBd = null;
                    return true;
                }
                else
                {
                    strError = objConBd.gError;

                    objConBd.CerrarConexion();
                    objConBd = null;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region "Metodos Privados"
        private bool ValidarDatosBasicos()
        {
            if (strSql == "")
            {
                strError = "No definio la instruccion Sql";
                return false;
            }
            if (strColTexto == "")
            {
                strError = "No definio el nombre de la columna para el texto del combobox";
                return false;
            }

            if (strColValor == "")
            {
                strError = "No definio el nombre de la columna para el valor del combobox";
                return false;
            }
            if (strNomTabla == "")
            {
                //Si no se definio nombre de tabla, se asigna un 
                //nombre por defecto el cual es "Tabla" para el DataTable del DataSet
                strNomTabla = "Tabla";
            }
            return true;
        }
        #endregion
    }
}
