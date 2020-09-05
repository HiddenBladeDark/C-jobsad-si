using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//agreados
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using LibConexionBD;
using LibLlenarGrids;
using LibLlenarCombos;


namespace LibAgencia
{
    public class LibAgenciaViaje
    {
        #region atributos
        SqlDataReader objReader;
        int request;
        int cedula;
        string name;
        string surname;
        string phone;
        string email;
        int state;
        string sql;
        string error;
        string nameservi;
        int valorservi;
        string descripcion;

        int id_cliente;
        int id_empleado;
        int id_detalle;
        int subtotal;
        double iva = 0.19;
        int total;
        double porcentaje = 1.40;

        int factura_id ;
        int detalle_id;


        ClsLLenarGrids objgrid;
        ClsLlenarCombos objcomb;
        ClsConexion objconex;

        #endregion


        #region propiedades
        public int SetCedula
        {
            set { cedula = value; }
        }
        public int GetCedula
        {
            get { return cedula; }
        }
        public string SetName   
        {
            set { name = value; }
        }
        public string Getname
        {
            get { return name; }
        }


        public string SetSurname
        {
            set { surname = value; }
        }
        public string SetPhone
        {
            set { phone = value; }
        }
        public string SetEmail
        {
            set { email = value; }
        }
        public int SetState
        {
            set { state = value; }
        }
        public int GetRespuesta
        {
            get { return request; }
        }
        public string SetError
        {
            set { error = value; }
        }
        public string GetError
        {
            get { return error; }
        }

        public int Id_empleado { get => id_empleado; set => id_empleado = value; }
        public int Id_detalle { get => id_detalle; set => id_detalle = value; }
        public int Subtotal { get => subtotal; set => subtotal = value; }
        public double Iva { get => iva; set => iva = value; }
        public int Total { get => total; set => total = value; }
        public int Factura_id { get => factura_id; set => factura_id = value; }
        public int Detalle_id { get => detalle_id; set => detalle_id = value; }
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nameservi { get => nameservi; set => nameservi = value; }
        public int Valorservi { get => valorservi; set => valorservi = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public SqlDataReader GetReader
        {
            get { return objReader; }
        }

        public double Porcentaje { get => porcentaje; set => porcentaje = value; }

        #endregion


        #region Metodos Publico



        //Metodo guardar empleado

        public bool SaveEmple()
        {
            objconex = new ClsConexion();
            int codEmp = 0;

            
            //parametro sql
            objconex.AgregarParametro(ParameterDirection.InputOutput, "@idestaemple",
                SqlDbType.Int, 1, codEmp);
            objconex.AgregarParametro(ParameterDirection.Input, "@cedula",
                SqlDbType.Int, 14, cedula);
            objconex.AgregarParametro(ParameterDirection.Input, "@NombreComple",
                SqlDbType.VarChar, 60, name);
            objconex.AgregarParametro(ParameterDirection.Input, "@telefono",
                SqlDbType.VarChar, 20, phone);
            objconex.AgregarParametro(ParameterDirection.Input, "@email",
               SqlDbType.VarChar, 60, email);
            objconex.AgregarParametro(ParameterDirection.Input, "@estado",
              SqlDbType.Int, 1, state);


            //consulta y guardado
            sql = "USP_Insertar_Empleado";

            if(!objconex.Consultar(sql,true))
            {
                error = objconex.Error;
                return false;
            }
            else
            {

                SqlDataReader objReader = objconex.Reader;
                if (objReader.HasRows)
                {
                    objReader.Read();
                    request = objReader.GetInt32(0);
                    objReader.Close();
                    if (request == 0)
                    {
                        error = "No se pudo guardar el empleado";
                        return false;
                    }
                    else if (request == -1)
                    {
                        error = "Ya existe el empleado OJO: " + name;
                        return false;
                    }
                    else return true;
                }
                else return false;
            }
        }


        //Metodo guardar cliente
        public bool SaveClient()
        {
            objconex = new ClsConexion();
            


            //parametro sql
            objconex.AgregarParametro(ParameterDirection.Input, "@cedula",
                SqlDbType.Int, 1, cedula);
            objconex.AgregarParametro(ParameterDirection.Input, "@nombre",
                SqlDbType.VarChar, 60, name);
            objconex.AgregarParametro(ParameterDirection.Input, "@tel",
                SqlDbType.VarChar, 20, phone);
            objconex.AgregarParametro(ParameterDirection.Input, "@mail",
                SqlDbType.VarChar, 60, email);
            objconex.AgregarParametro(ParameterDirection.Input, "@estado",
              SqlDbType.Int, 1, state);


            //consulta y guardado
            sql = "USP_Insertar_Cliente";

            if (!objconex.EjecutarSentencia(sql, true))
            {
                error = objconex.Error;
                return false;
            }
            else
            {

                error = "Usuario guardado correctamente";
                return true;
            }
        }






        //Llenar dropdownlisto empleado
        public bool LlenarCombEmple(DropDownList DespleEmple)
        {
            objcomb = new ClsLlenarCombos();
            objcomb.NombreTabla = "Emple";
            objcomb.SQL = "USP_Consult_Emple";
            objcomb.ColumnaValor = "idemple";
            objcomb.ColumnaTexto = "SelectEmple";

            if (!objcomb.LlenarComboWeb(DespleEmple))
            {
                error = objcomb.Error;
                return false;
            }
            else return true;
        }

        //Llenar DropDownList  Detalle 
        public bool Llenarcombodeta(DropDownList DespleDeta)
        {
            objcomb = new ClsLlenarCombos();
            objcomb.NombreTabla = "deta";
            objcomb.SQL = "USP_SelectDetalleUlti";
            objcomb.ColumnaValor = "id_deta";
            objcomb.ColumnaTexto = "NombreDeta";

            if (!objcomb.LlenarComboWeb(DespleDeta))
            {
                error = objcomb.Error;
                return false;
            }
            else return true;
        }
        public bool llenarcomboprecio(DropDownList PrecioDeta)
        {
            objcomb = new ClsLlenarCombos();
            objcomb.NombreTabla = "valordeta";
            objcomb.SQL = "USP_SelectDetalleUlti";
            objcomb.ColumnaValor = "id_deta";
            objcomb.ColumnaTexto = "valorservi";

            if (!objcomb.LlenarComboWeb(PrecioDeta))
            {
                error = objcomb.Error;
                return false;
            }
            else return true;
        }



        //Llenar DropDownList ConsultaFactura
        public bool consultafactura(DropDownList desplefactu)
        {
            objcomb = new ClsLlenarCombos();
            
            objcomb.NombreTabla = "factu";
            objcomb.SQL = "USP_Consult_factu";
            objcomb.ColumnaValor = "idfactu";
            objcomb.ColumnaTexto = "idfactu";

            if (!objcomb.LlenarComboWeb(desplefactu))
            {
                error = objcomb.Error;
                return false;
            }
            else return true;
        }

        //ultima factura ingreso
        public bool facturaulti(DropDownList desplefacturas)
        {
            objcomb = new ClsLlenarCombos();

            objcomb.NombreTabla = "factura";
            objcomb.SQL = "USP_ultifac";
            objcomb.ColumnaValor = "idfac";
            objcomb.ColumnaTexto = "idfac";

            if (!objcomb.LlenarComboWeb(desplefacturas))
            {
                error = objcomb.Error;
                return false;
            }
            else return true;
        }




        //Guardar Facturacion
        public bool facturacion()
        {



            int totales = Convert.ToInt32(subtotal * porcentaje);
            int ivainclu = Convert.ToInt32(totales * iva);
            int totalpagar = totales+ivainclu;
            

            

            objconex = new ClsConexion();

            int ivagob = 19;

            //parametro sql
            objconex.AgregarParametro(ParameterDirection.Input, "@cedula_cliente",
                SqlDbType.Int, 254, cedula);
            objconex.AgregarParametro(ParameterDirection.Input, "@id_empleado",
                SqlDbType.Int, 254, Id_empleado);
            objconex.AgregarParametro(ParameterDirection.Input, "@id_detalle",
                SqlDbType.Int, 254, Id_detalle);
            objconex.AgregarParametro(ParameterDirection.Input, "@subtotal",
                 SqlDbType.Int, 254, subtotal);
            objconex.AgregarParametro(ParameterDirection.Input, "@iva",
                SqlDbType.Int, 254, ivagob);
            objconex.AgregarParametro(ParameterDirection.Input, "@total",
                SqlDbType.Int, 254, totalpagar);

            




            sql = "USP_ingresofactura";

           

            if (!objconex.EjecutarSentencia(sql, true))
            {
                error = objconex.Error;
                return false;
            }
            else
            {
                savemov();
                error = "factura guardado correctamente";
                return true;
            }
            
        }

        public bool savemov()
        {

            objconex = new ClsConexion();

            sql = "USP_movisave";


            objconex.AgregarParametro(ParameterDirection.Input, "@factura_id",
                SqlDbType.Int, 1, Factura_id);
            objconex.AgregarParametro(ParameterDirection.Input, "@detalle_id",
                SqlDbType.Int, 1, Id_detalle);


            if (!objconex.EjecutarSentencia(sql, true))
            {
                error = objconex.Error;
                return false;
            }
            else
            {

                error = "factura guardado correctamente";
                return true;
            }

        }



       

        //Guardar Detalle WebService
        public bool savedetal()
        {
            objconex = new ClsConexion();


            sql = "USP_InsertDetalles";

            //parametro sql
            objconex.AgregarParametro(ParameterDirection.Input, "@NombreServi",
                SqlDbType.VarChar, 254, nameservi);
            objconex.AgregarParametro(ParameterDirection.Input, "@valorservi",
                SqlDbType.Int, 254, valorservi);
            objconex.AgregarParametro(ParameterDirection.Input, "@estado",
                SqlDbType.Bit, 1, state);
            objconex.AgregarParametro(ParameterDirection.Input, "@descripcion",
                SqlDbType.VarChar, 60, descripcion);
            objconex.AgregarParametro(ParameterDirection.Input, "@id_servi",
                SqlDbType.Int, 255, id_detalle);

            if (!objconex.EjecutarSentencia(sql, true))
            {
                error = objconex.Error;
                return false;
            }
            else
            {

                error = "detalle guardado correctamente";
                return true;
            }



        }



        //ConsultaFactura
        public bool ultifactu()
        {
            ClsConexion objconsulfac = new ClsConexion();

           

            sql = "USP_ingresofactura";

            if (!objconsulfac.Consultar(sql,true))
            {
                error = objconex.Error;
                return false;
            }
            else
            {

                error = "Consultado";
                return true;
            }

        }


        public bool UltiIngresadoFactura()
        {

            ClsConexion objcon = new ClsConexion();

            if (!objcon.Consultar(sql, true))
            {
                error = objconex.Error;
                return false;

            }
            else
            {
                return true;
            }

        }





        //iniciar sesion
        public bool consultar()
        {
            ClsConexion obj_conexion = new ClsConexion();

            string strSQL = "usp_clienteiniciosession " + cedula + ",'" + name + "'";
           

            if (obj_conexion.Consultar(strSQL, false))
            {
                objReader = obj_conexion.Reader;
                obj_conexion = null;
                return true;
            }
            else
            {
                error = obj_conexion.Error;
                obj_conexion = null;
                return false;
            }
        }



        #endregion
    }
}
