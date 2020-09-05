using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LibBasica
{
    class clsParamConBd
    {
        #region Atributos
        private string strServer;
        private string strBaseDatos;
        private string strUser;
        private string strPwd;
        private string strCadCon;
        private bool blnSegInt;
        private string strError;
        private string strPathXml;
        private XmlDocument xdcParam;
        #endregion

        #region Propiedades Get y Set
        public string Servidor
        {
            get { return strServer; }
        }
        

        public string BaseDatos
        {
            get { return strBaseDatos; }
        }
        

        public string Usuario
        {
            get { return strUser; }
        }
        

        public string Clave
        {
            get { return strPwd; }
        }
        

        public string CadenaConex
        {
            get { return strCadCon; }
        }
        

        public bool SeguridadIntegrada
        {
            get { return blnSegInt; }
        }
        

        public string Error
        {
            get { return strError; }
        }
        

        public string RutaArchivoXml
        {
            get { return strPathXml; }
            set { strPathXml = value; }
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Constructor de la clase para la conformación de la cadena de conexión
        /// </summary>
        public clsParamConBd()
        {
            xdcParam = new XmlDocument();
            strError = String.Empty;
            strCadCon = String.Empty;
        }

        /// <summary>
        /// Metodo que obtiene la cadena de conexion del archivo Xml
        /// </summary>
        /// <param name="blnPath">
        /// Si es true se lee el archivo xml desde la unidad C, si es false se lee desde el proyecto
        /// </param>
        /// <returns>Retorna un valor boleano indicando si pudo ser construida la cadena de conexion</returns>
        public bool GetConnString(bool blnPath)
        {
            try
            {
                if (blnPath)
                {

                    strPathXml = "C:\\Params.xml";
                }
                else
                {
                    strPathXml = AppDomain.CurrentDomain.BaseDirectory + "Params.xml";
                }

            
                xdcParam.Load(strPathXml);

                XmlNode xnConex = xdcParam.DocumentElement;

                foreach (XmlNode xnParsCon in xnConex.ChildNodes)
                {
                    switch (xnParsCon.Name)
                    {
                        case "servidor":
                            strServer = xnParsCon.InnerText;
                            break;
                        case "basedatos":
                            strBaseDatos = xnParsCon.InnerText;
                            break;
                        case "seguridad":
                            blnSegInt = Convert.ToBoolean(xnParsCon.InnerText);
                            break;
                        case "usuario":
                            strUser = xnParsCon.InnerText;
                            break;
                        case "password":
                            strPwd = xnParsCon.InnerText;
                            break;
                    }
                }

                if (blnSegInt)
                {
                    strCadCon = "Data Source=" + strServer +
                                ";Initial Catalog=" + strBaseDatos +
                                ";Trusted_Connection=" + blnSegInt.ToString();
                }
                else
                {
                    strCadCon = "Data Source=" + strServer +
                                ";Initial Catalog=" + strBaseDatos +
                                ";User Id=" + strUser +
                                ";Password=" + strPwd;
                }

                xdcParam = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                xdcParam = null;
                return false;
            }


        }

        #endregion

    }
    
}
