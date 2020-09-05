using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace LibBasica
{
    public class clsGrid
    {
        #region "Atributos"
        private string strNomTabla;
        private string strSql;
        private string strError;
        private GridView gvGenerico;
        private DataGridView dgvGenerico;

        private clsConexBd objConBd;

        #endregion

        #region "Propiedades"
        public GridView gsGvGen
        {
            get { return gvGenerico; }
            set { gvGenerico = value; }
        }

        public DataGridView gsDgvGen
        {
            get { return dgvGenerico; }
            set { dgvGenerico = value; }
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

        public string gError
        {
            get { return strError; }
        }
        #endregion

        #region "Metodos Publicos"

        public clsGrid()
        {
            objConBd = new clsConexBd();

            //Instruccion Opcional, si desea cambiar la ruta del archivo de parametros
            //objConBd.gsRutaArcParCon = false;
        }

        public bool LlenarGridWeb()
        {

            if (ValidarDatosBasicosWeb())
            {

                objConBd.gsNomTabla = strNomTabla;
                objConBd.gsSql = strSql;

                if (objConBd.GetDataSet(false))
                {
                    gvGenerico.DataSource = objConBd.gDataSet.Tables[strNomTabla];
                    gvGenerico.DataBind();
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

        public bool LlenarGridWin()
        {

            if (ValidarDatosBasicosWin())
            {

                objConBd.gsNomTabla = strNomTabla;
                objConBd.gsSql = strSql;

                if (objConBd.GetDataSet(false))
                {
                    dgvGenerico.DataSource = objConBd.gDataSet.Tables[strNomTabla];
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
        private bool ValidarDatosBasicosWeb()
        {

            if (strNomTabla == "")
            {
                //Si no se definio nombre de tabla, se asigna un 
                //nombre por defecto el cual es "Tabla" para el DataTable del DataSet
                strNomTabla = "Tabla";
            }

            if (gvGenerico == null)
            {
                strError = "No ha definido el grid que se va a llenar";
                return false;
            }

            if (strSql == "")
            {
                strError = "Debe definir una instrucción Sql";
                return false;
            }

            return true;
        }

        private bool ValidarDatosBasicosWin()
        {

            if (strNomTabla == "")
            {
                //Si no se definio nombre de tabla, se asigna un 
                //nombre por defecto el cual es "Tabla" para el DataTable del DataSet
                strNomTabla = "Tabla";
            }

            if (dgvGenerico == null)
            {
                strError = "No ha definido el grid que se va a llenar";
                return false;
            }

            if (strSql == "")
            {
                strError = "Debe definir una instrucción Sql";
                return false;
            }

            return true;
        }
        #endregion
    }
}
