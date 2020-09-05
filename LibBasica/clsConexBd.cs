using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LibBasica
{
    public class clsConexBd
    {
        //ATRIBUTOS
        #region "Atributos"

        private string strSql;
        private string strCadConex;
        private SqlCommand scmCommand;
        private SqlConnection scnConnnection;
        private SqlDataReader sdrReader;
        private object oScalar;
        private string strServidor;
        private string strBaseDatos;
        private string strUsuario;
        private string strClave;
        private string strError;
        private bool blnStatusCon;
        private string strNomTabla;
        private SqlDataAdapter sdaAdapter;
        private DataSet dsDataSet;
        private SqlParameter spmParam;
        private clsParamConBd objParamConex;
        private bool blnRutaArcParConex;

        #endregion

        //PROPIEDADES
        #region "Propiedades"

        public string gsNomTabla
        {
            get { return strNomTabla; }
            set { strNomTabla = value; }
        }

        public SqlCommand gCommand
        {
            get { return scmCommand; }
        }

        public DataSet gDataSet
        {
            get { return dsDataSet; }
        }

        public string gsSql
        {
            get { return strSql; }
            set { strSql = value; }
        }
        public string gsCadConex
        {
            get { return strCadConex; }
            set { strCadConex = value; }
        }
        public SqlDataReader gDataReader
        {
            get { return sdrReader; }
        }

        public object gScalar
        {
            get { return oScalar; }
        }

        public string gServidor
        {
            get { return strServidor; }
        }
        public string gBaseDatos
        {
            get { return strBaseDatos; }
        }
        public string gUsuario
        {
            get { return strUsuario; }
        }
        public string gClave
        {
            get { return strClave; }
        }
        public SqlParameter gParam
        {
            get { return (spmParam); }
        }
        public string gError
        {
            get { return strError; }
        }

        public bool gsRutaArcParCon
        {
            get { return blnRutaArcParConex; }
            set { blnRutaArcParConex = value; }
        }

        #endregion


        #region "Constructor y Destructor"

        /// <summary>
        /// Constructor de la clase para la Gestión Conexion a BD Sql Server
        /// </summary>
        public clsConexBd()
        {
            scmCommand = new SqlCommand();
            scnConnnection = new SqlConnection();
            dsDataSet = new DataSet();
            spmParam = new SqlParameter();
            sdaAdapter = new SqlDataAdapter();

            objParamConex = new clsParamConBd();
            gsRutaArcParCon = true;
        }

        /// <summary>
        /// Destructor de la clase para la Gestión Conexion a BD Sql Server
        /// </summary>
        ~clsConexBd()
        {
            CerrarConexion();
        }

        #endregion

        #region "Metodos Privados"

        /// <summary>
        /// Metodo que obtiene la cadena de conexion del archivo Xml
        /// </summary>
        /// <returns>Retorna un valor boleano indicando si pudo obtenida la cadena de conexion</returns>
        private bool ObtenerCadConex()
        {
            //Si se envia true, leerá el archivo params.xml de la raiz de la Unidad C
            //Sino se leera de la carpeta por defecto del proyecto
            if (objParamConex.GetConnString(gsRutaArcParCon))
            {
                strCadConex = objParamConex.CadenaConex;
                strServidor = objParamConex.Servidor;
                strBaseDatos = objParamConex.BaseDatos;
                strUsuario = objParamConex.Usuario;
                strClave = objParamConex.Clave;
                objParamConex = null;
                return true;
            }
            else
            {
                strError = objParamConex.Error;
                objParamConex = null;
                return false;
            }
        }

        /// <summary>
        /// Metodo que abre la conexión a la BD Sql Server
        /// </summary>
        /// <returns>Retorna un valor boleano indicando si la conexión fue exitosa o no</returns>
        private bool AbrirConexion()
        {
            if (ObtenerCadConex())
            {
                scnConnnection.ConnectionString = strCadConex;
                try
                {
                    scnConnnection.Open();
                    blnStatusCon = true;
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    blnStatusCon = false;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "Metodos Publicos"

        /// <summary>
        /// Metodo que adiciona un parametro al objeto command que se inyectará a la BD Sql Server
        /// </summary>
        /// <param name="pDireccion">
        /// Direccion del parametro (IN / OUT)
        /// </param>
        /// <param name="pNombre">
        /// Nombre del parametro
        /// </param>
        /// <param name="pTipoDato">
        /// Tipo de dato del parametro
        /// </param>
        /// <param name="pTamano">
        /// Tamaño segun el tipo de dato del parametro
        /// </param>
        /// <param name="pValor">
        /// Valor que se almacenará en el parametro
        /// </param>
        /// <returns>Retorna un valor boleano indicando si pudo ser agregado el parametro al objeto command</returns>
        public bool AdicionarParametro(ParameterDirection pDireccion, string pNombre, SqlDbType pTipoDato, Int16 pTamano, object pValor)
        {
            try
            {
                spmParam.Direction = pDireccion;
                spmParam.ParameterName = pNombre;
                spmParam.SqlDbType = pTipoDato;
                spmParam.Size = pTamano;
                spmParam.Value = pValor;

                scmCommand.Parameters.Add(spmParam);
                spmParam = new SqlParameter();

                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Metodo que ejecuta una instruccion o un procedimiento almacenado el cual afecta
        /// los registros
        /// </summary>
        /// <param name="blnTipo">
        /// Si es true se ejecuta un procedimiento almacenado, si es false se ejecuta una sentencia sql
        /// </param>
        /// <returns>Retorna un valor boleano indicando si pudo ejecutarse correctamente</returns>
        public bool ExecSql(bool blnTipo)
        {
            //Validamos si el atributo strSql esta vacio, en dicho caso
            //termina la ejecucion de este metodo
            if (strSql == "")
            {
                strError = "No definio la instrucción Sql";
                return false;
            }
            //Validamos antes de intentar conectarnos, que NO estemos conectados actualmente
            if (blnStatusCon == false)
            {
                //Validamos que si la apertura de la conexion fallo, en dicho caso
                //termina la ejecucion de este metodo
                if (AbrirConexion() == false)
                {
                    return false;
                }
            }

            //Le decimos al SqlCommand cual conexion puente debe trabajar
            scmCommand.Connection = scnConnnection;

            //Define el tipo de parámetro a ejecutar, instruccion Sql (Si blnParametros = false)
            //o Stored Procedure (Si blnParametros = true)
            if (blnTipo)
            {
                scmCommand.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                scmCommand.CommandType = CommandType.Text;
            }

            //Se entrega al SqlCommand la instruccion Sql o el nombre del procedimiento almacenado
            scmCommand.CommandText = strSql;

            //Intentar inyectar la instruccion Sql o Ejecutar el Procedimiento Almacenado
            try
            {
                scmCommand.ExecuteNonQuery();
                //CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                //CerrarConexion();
                return false;
            }
        }

        

        /// <summary>
        /// Metodo que Cierra la conexión a la BD Sql Server
        /// </summary>
        /// <returns>Retorna un valor boleano indicando si se pudo ser cerrada la conexión</returns>
        public bool CerrarConexion()
        {
            #region instrucciones para cerrar la conexion
            try
            {
                scnConnnection.Close();
            }
            catch (Exception ex)
            {
                strError = "No cerró la conexion" + ex.Message;
                return false;
            }
            #endregion

            #region instrucciones para liberar el Objeto de Tipo SqlConnection
            try
            {
                scnConnnection = null;
            }
            catch (Exception ex1)
            {
                strError = "No liberó la conexion" + ex1.Message;
            }
            #endregion

            return true;
        }

        /// <summary>
        /// Metodo que ejecuta una instruccion o un procedimiento almacenado el cual obtiene un
        /// conjunto de registros y los retorna en un DataSet (Modelo Desconectado)
        /// </summary>
        /// <param name="blnTipo">
        /// Si es true se ejecuta un procedimiento almacenado, si es false se ejecuta una sentencia sql
        /// </param>
        /// <returns>Retorna un valor boleano indicando si pudo ejecutarse correctamente</returns>
        public bool GetDataSet(bool blnTipo)
        {
            //Si no se entrego instruccion Sql a inyectar se termina
            //la ejecucion de este metodo
            if (strSql == "")
            {
                strError = "No definio la instrucción Sql";
                return false;
            }

            //Si no se entrego instruccion Sql a inyectar se termina
            //la ejecucion de este metodo
            if (strNomTabla == "")
            {
                strError = "No definio el nombre de la tabla";
                return false;
            }

            //Validamos antes de intentar conectarnos, que NO estemos conectados actualmente
            if (blnStatusCon == false)
            {

                //Validamos que si la apertura de la conexion fallo, en dicho caso
                //termina la ejecucion de este metodo
                if (AbrirConexion() == false)
                {
                    return false;
                }
            }

            //Define el tipo de parámetro a ejecutar, instruccion Sql (Si blnParametros = false)
            //o Stored Procedure (Si blnParametros = true)
            if (blnTipo)
            {
                scmCommand.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                scmCommand.CommandType = CommandType.Text;
            }

            //Le decimos al SqlCommand cual conexion puente debe trabajar
            scmCommand.Connection = scnConnnection;

            //Se entrega al SqlCommand la instruccion Sql o el nombre del procedimiento almacenado
            scmCommand.CommandText = strSql;

            try
            {
                sdaAdapter.SelectCommand = scmCommand;
                sdaAdapter.Fill(dsDataSet, strNomTabla);
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Metodo que ejecuta una instruccion o un procedimiento almacenado el cual obtiene un
        /// conjunto de registros y los retorna en un SqlDataReader (Modelo Conectado)
        /// </summary>
        /// <param name="blnTipo">
        /// Si es true se ejecuta un procedimiento almacenado, si es false se ejecuta una sentencia sql
        /// </param>
        /// <returns>Retorna un valor boleano indicando si pudo ejecutarse correctamente</returns>
        public bool GetDataReader(bool blnTipo)
        {
            //Si no se entrego instruccion Sql a inyectar se termina
            //la ejecucion de este metodo
            if (strSql == "")
            {
                strError = "No definio la instrucción Sql";
                return false;
            }

            //Validamos antes de intentar conectarnos, que NO estemos conectados actualmente
            if (blnStatusCon == false)
            {
                //Validamos que si la apertura de la conexion fallo, en dicho caso
                //termina la ejecucion de este metodo
                if (AbrirConexion() == false)
                {
                    return false;
                }
            }

            //Define el tipo de parámetro a ejecutar, instruccion Sql (Si blnParametros = false)
            //o Stored Procedure (Si blnParametros = true)
            if (blnTipo)
            {
                scmCommand.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                scmCommand.CommandType = CommandType.Text;
            }

            //Le decimos al SqlCommand cual conexion puente debe trabajar
            scmCommand.Connection = scnConnnection;

            //Se entrega al SqlCommand la instruccion Sql o el nombre del procedimiento almacenado
            scmCommand.CommandText = strSql;


            try
            {
                sdrReader = scmCommand.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Metodo que ejecuta una instruccion o un procedimiento almacenado el cual obtiene la
        /// primera columna de la primera fila del conjunto de registros obtenidos
        /// </summary>
        /// <param name="blnTipo">
        /// Si es true se ejecuta un procedimiento almacenado, si es false se ejecuta una sentencia sql
        /// </param>
        /// <returns>Retorna un valor boleano indicando si pudo ejecutarse correctamente</returns>
        public bool GetScalar(bool blnTipo)
        {
            //Si no se entrego instruccion Sql a inyectar se termina
            //la ejecucion de este metodo
            if (strSql == "")
            {
                strError = "No definio la instrucción Sql";
                return false;
            }

            //Validamos antes de intentar conectarnos, que NO estemos conectados actualmente
            if (blnStatusCon == false)
            {
                //Validamos que si la apertura de la conexion fallo, en dicho caso
                //termina la ejecucion de este metodo
                if (AbrirConexion() == false)
                {
                    return false;
                }
            }

            //Define el tipo de parámetro a ejecutar, instruccion Sql (Si blnParametros = false)
            //o Stored Procedure (Si blnParametros = true)
            if (blnTipo)
            {
                scmCommand.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                scmCommand.CommandType = CommandType.Text;
            }

            //Le decimos al SqlCommand cual conexion puente debe trabajar
            scmCommand.Connection = scnConnnection;

            //Se entrega al SqlCommand la instruccion Sql o el nombre del procedimiento almacenado
            scmCommand.CommandText = strSql;


            try
            {
                oScalar = scmCommand.ExecuteScalar();
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


        #endregion
    }
}
