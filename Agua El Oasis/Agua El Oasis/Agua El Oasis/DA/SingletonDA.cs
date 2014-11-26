using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Almacen;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Orden;
using Agua_El_Oasis.DA;

namespace Agua_El_Oasis.Models
{
    public class SingletonDA
    {

        //atributo del tipo de la clase
        private static SingletonDA intancia = null;
        //private string url = @"data source=.\SQLEXPRESS;Integrated Security=true;AttachDBFilename=|DataDirectory|Agua_El_Oasis.mdf;User Instance=true";
        private SqlConnection conn = null;
        private SqlCommand comando = null;
        private SqlDataReader reader = null;

        //metodo de acceso para la clase para retornar una unica instancia de la clase
        public static SingletonDA Intancia()
        {

            if (intancia == null)
            {

                intancia = new SingletonDA();
            }
            return intancia;
        }//

        //contructor privado para asegurar que solo se creara una solo intancia
        private SingletonDA()
        {
        }

        public string conection()
        {

            String ConnString = System.Configuration.ConfigurationManager.
                ConnectionStrings["Agua_El_OasisContext"].ConnectionString;
            conn = new SqlConnection(ConnString);
            try
            {
                conn.Open();
                return "conexion exitosa...";
            }

            catch (Exception e)
            {

                return "Error en la conexion..." + e.ToString();
            }

        }//


        public string registroPersona(Persona pe)
        {

            conection();
            try
            {


                if (pe.p_apellidoPersona == "" && pe.p_cedula_Persona == "" && pe.p_direccion_Persona == "" && pe.p_nombreUsuario == "" && pe.p_contrasenaPersona == "" && pe.p_email_Persona == "")
                {
                    QueryResultSingleton.Intance.Success = false;
                    QueryResultSingleton.Intance.Message = "DEBE ESPECIFICAR campos vacios";
                    return "DEBE ESPECIFICAR campos vacios";
                }

                comando = new SqlCommand("EXEC registro '" + pe.p_nombreUsuario + "', '" + pe.p_email_Persona + "','" + pe.p_cedula_Persona + "' ", conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    QueryResultSingleton.Intance.Success = false;
                    QueryResultSingleton.Intance.Message = "usuario y email existen en la BD entre otro...";
                    return "usuario y email existen en la BD entre otro...";
                }
                reader.Close();
                comando = new SqlCommand("EXEC registrarPersona '" + pe.p_nombrePersona + "','" + pe.p_apellidoPersona + "','" + pe.p_cedula_Persona + "','" + pe.p_direccion_Persona + "','" + pe.p_nombreUsuario + "','" + pe.p_contrasenaPersona + "','" + pe.p_email_Persona + "' ", conn);
                comando.ExecuteNonQuery();
                comando.Dispose();
                QueryResultSingleton.Intance.Success = true;
                QueryResultSingleton.Intance.Message = "Usuario Registrado Exitosamente";

                conn.Close();
            }
            catch (Exception e) { e.ToString(); }

            return "registro exitoso";
        }//


        public List<Producto> listaProducto()
        {

            conection();
            List<Producto> productos = new List<Producto>();
            try
            {

                comando = new SqlCommand("EXEC listaProducto", conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Producto nuevoProducto = new Producto();

                    nuevoProducto.p_idProducto = reader.GetInt32(0);
                    nuevoProducto.p_nombreProducto = reader.GetString(1);
                    nuevoProducto.p_cantidad = reader.GetInt32(2);
                    nuevoProducto.p_precio = reader.GetDouble(3);
                    nuevoProducto.p_descripcion = reader.GetString(4);
                    nuevoProducto.p_imagen = reader.GetString(5);
                    productos.Add(nuevoProducto);

                }
                reader.Close();
                conn.Close();

            }
            catch (Exception e) { e.ToString(); }
            return productos;
        }//


        public string registoProducto(Producto pro)
        {
            conection();
            try
            {
                comando = new SqlCommand("INSERT INTO[producto] VALUES('" + pro.p_nombreProducto + "','" + pro.p_cantidad + "','" + pro.p_precio + "','" + pro.p_descripcion + "')", conn);
                comando.ExecuteNonQuery();
                comando.Dispose();
                conn.Close();
                return "registro exitoso";
            }
            catch (Exception e)
            {

                return "error" + e.ToString();
            }



        }//

        public bool autenticarUsuario(string nombre, string contraseña)
        {

            conection();
            try
            {
                comando = new SqlCommand("EXEC autenticarUsuario '" + nombre + "','" + contraseña + "'", conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    return true;

                }

            }
            catch (Exception e) { e.ToString(); }
            return false;

        }//

        public List<Producto> buscarProducto(string prod)
        {


            List<Producto> productos = new List<Producto>();
            try
            {
                conection();

                comando = new SqlCommand("EXEC buscarProducto'" + prod + "' ", conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Producto buscarProducto = new Producto();

                    buscarProducto.p_idProducto = reader.GetInt32(0);
                    buscarProducto.p_nombreProducto = reader.GetString(1);
                    buscarProducto.p_cantidad = reader.GetInt32(2);
                    buscarProducto.p_precio = reader.GetDouble(3);
                    buscarProducto.p_descripcion = reader.GetString(4);
                    buscarProducto.p_imagen = reader.GetString(5);
                    productos.Add(buscarProducto);

                }
                reader.Close();
                conn.Close();


            }
            catch (Exception e) { e.ToString(); }

            return productos;



        }//

        public Producto getProducto(int idProducto)
        {
            conection();
            Producto unProducto = new Producto();

            try
            {

                comando = new SqlCommand("EXEC getProd '" + idProducto + "' ", conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {



                    unProducto.p_idProducto = reader.GetInt32(0);
                    unProducto.p_nombreProducto = reader.GetString(1);
                    unProducto.p_cantidad = reader.GetInt32(2);
                    unProducto.p_precio = reader.GetDouble(3);
                    unProducto.p_descripcion = reader.GetString(4);
                    unProducto.p_imagen = reader.GetString(5);

                }


            }
            catch
            {
            }

            return unProducto;
        }// 

        public string eliminarProducto(int idProducto)
        {

            try
            {
                conection();
                comando = new SqlCommand("EXEC eliminarProd '" + idProducto + "' ", conn);


                if (comando.ExecuteNonQuery() == 1)
                {

                    return "eliminado";

                }
                else
                {
                    conn.Close();
                    return "no se encontro";
                }


            }
            catch (Exception e)
            {
                return "error" + e.ToString();
            }
        }//

        public string actualizarProducto(int idProducto, Producto productoActualizado)
        {

            try
            {
                conection();

                comando = new SqlCommand("UPDATE [producto] SET producto_nombre='" + productoActualizado.p_nombreProducto + "',producto_cantidad=" + productoActualizado.p_cantidad + ",producto_precio=" + productoActualizado.p_precio + ",producto_descripcion='" + productoActualizado.p_descripcion + "'  WHERE producto_id=" + idProducto, conn);

                if (comando.ExecuteNonQuery() == 1)
                {

                    return "producto actualizado...";

                }
                else
                {
                    conn.Close();
                    return "no existe el producto especificado...";
                }


            }
            catch (Exception e)
            {
                throw (e);
            }



        }//


        public Cliente dataCliente(string usuario, string contraseña)
        {


            Cliente dataCli = new Cliente();


            try
            {

                conection();
                comando = new SqlCommand("SELECT * FROM [persona] WHERE persona_usuario='" + usuario + "' AND persona_password='" + contraseña + "' ", conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    dataCli.p_idPersona = reader.GetInt32(0);
                    dataCli.p_tipoPersona = reader.GetInt32(1);
                    dataCli.p_nombrePersona = reader.GetString(2);
                    dataCli.p_apellidoPersona = reader.GetString(3);
                    dataCli.p_cedula_Persona = reader.GetString(4);
                    dataCli.p_direccion_Persona = reader.GetString(5);
                    dataCli.p_nombreUsuario = reader.GetString(6);

                }
                reader.Close();
                conn.Close();

            }
            catch (Exception e) { e.ToString(); }

            return dataCli;

        }//


        public int registrarOrden(Orden orden)
        {

            try
            {

                int OrdId = 0;
                conection();
                //orden
                comando = new SqlCommand("INSERT INTO[orden] VALUES('" + Convert.ToDateTime(orden.p_fechaOrden).ToString("yyyy-MM-dd") + "','" + orden.p_r_Cliente_Titular.p_idPersona + "','" + Convert.ToDateTime(orden.p_fechaEntrega).ToString("yyyy-MM-dd") + "','" + 1 + "')", conn);
                comando.ExecuteNonQuery();
                comando.Dispose();


                //orden_producto
                for (int i = 0; i < orden.p_r_Orden_Carrito.p_mi_carrito.Count; i++)
                {
                    int proID = orden.p_r_Orden_Carrito.p_mi_carrito.ElementAt(i).p_idProducto;
                    int cantidad = orden.p_r_Orden_Carrito.p_mi_carrito.ElementAt(i).p_cantidad;
                    double subTotal = cantidad * orden.p_r_Orden_Carrito.p_mi_carrito.ElementAt(i).p_precio;

                    comando = new SqlCommand("INSERT INTO orden_producto VALUES((SELECT MAX(orden_id) FROM orden),'" + proID + "','" + cantidad + "','" + subTotal + "')", conn);
                    comando.ExecuteNonQuery();
                    comando.Dispose();
                }

                //orden_empleado
                comando = new SqlCommand(" SELECT persona_id FROM persona WHERE (role_persona_id = 3)", conn);
                reader = comando.ExecuteReader();
                comando.Dispose();
                List<int> listId = new List<int>();
                int codEmple = 0;
                int cantOrd = 0;

                while (reader.Read())
                {
                    listId.Add(reader.GetInt32(0));
                }
                reader.Close();

                for (int i = 0; i < listId.Count; i++)
                {
                    comando = new SqlCommand(" SELECT COUNT(*) AS numOrdenes FROM orden_empleado INNER JOIN orden ON orden_empleado.orden_id = orden.orden_id WHERE (orden_empleado.empleado_id ='" + listId[i] + "' ) AND (orden.status_orden_id <> 4)", conn);

                    reader = comando.ExecuteReader();

                    reader.Read();



                    if (cantOrd == 0 && codEmple == 0)
                    {

                        cantOrd = reader.GetInt32(0);

                    }

                    if (reader.GetInt32(0) <= cantOrd)
                    {


                        codEmple = listId[i];
                        cantOrd = reader.GetInt32(0);

                    }


                    reader.Close();

                }

                comando = new SqlCommand("INSERT INTO[orden_empleado] VALUES((SELECT MAX(orden_id) FROM orden),'" + codEmple + "')", conn);
                comando.ExecuteNonQuery();
                comando.Dispose();
                comando = new SqlCommand("SELECT MAX(orden_id) FROM orden", conn);
                reader = comando.ExecuteReader();
                reader.Read();

                OrdId = reader.GetInt32(0);

                comando.Dispose();
                reader.Close();
                return OrdId;

            }
            catch (Exception e)
            {
                throw (e);
            }


        }//


        public List<Orden> listaOrdenes(int clieID)
        {

            List<Orden> ordenes = new List<Orden>();

            try
            {

                conection();
                comando = new SqlCommand("SELECT orden.orden_id,orden.orden_fecha,orden.persona_id,orden_producto.orden_producto_cantidad,producto.producto_nombre,producto.producto_precio,producto.producto_precio*orden_producto.orden_producto_cantidad AS total FROM [orden] INNER JOIN [orden_producto] ON orden.orden_id = orden_producto.orden_id INNER JOIN producto ON orden_producto.producto_id=producto.producto_id WHERE persona_id=" + clieID, conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Orden or = new Orden();
                    or.p_idOrden = reader.GetInt32(0);
                    or.p_fechaOrden = reader.GetDateTime(1);
                    or.p_r_Cliente_Titular.p_idPersona = reader.GetInt32(2);

                    for (int k = 0; k < or.p_r_Orden_Carrito.p_mi_carrito.Count; k++)
                    {

                        or.p_r_Orden_Carrito.p_mi_carrito.ElementAt(k).p_cantidad = reader.GetInt32(3);
                        or.p_r_Orden_Carrito.p_mi_carrito.ElementAt(k).p_nombreProducto = reader.GetString(4);
                        or.p_r_Orden_Carrito.p_mi_carrito.ElementAt(k).p_precio = reader.GetDouble(5);
                    }
                    ordenes.Add(or);
                }
                reader.Close();
                conn.Close();

            }
            catch (Exception e) { e.ToString(); }

            return ordenes;
        }//

        public Orden unaOrden(int ordID)
        {

            Orden or = new Orden();
            or.p_r_Cliente_Titular = new Cliente();
            
            
            try
            {
                conection();

                comando = new SqlCommand("SELECT  orden.orden_id, orden.orden_fecha, orden.persona_id, orden.orden_fecha_entrega,  status_orden.status_orden_descripcion FROM orden inner join status_orden on orden.status_orden_id=status_orden.status_orden_id where orden_id="+ordID, conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    or.p_idOrden = reader.GetInt32(0);
                    or.p_fechaOrden = reader.GetDateTime(1);
                    or.p_r_Cliente_Titular.p_idPersona = reader.GetInt32(2);
                    or.p_fechaEntrega = reader.GetDateTime(3);
                    or.p_statusOrden = reader.GetString(4);
                    

                }
                reader.Close();
                
                
                comando = new SqlCommand("SELECT SUM(orden_producto_subtotal) FROM [orden_producto] WHERE orden_id="+ordID,conn);
                reader = comando.ExecuteReader();


                while (reader.Read()) {

                    or.p_subTotal = reader.GetDouble(0);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e) { e.ToString(); }

            return or;




        }

        public void factura(Factura fa)
        {

            try
            {

                conection();
                comando = new SqlCommand("INSERT INTO[factura] VALUES('" + fa.p_fechaFactura + "','" + fa.p_montoFactura + "','" + fa.p_r_Orden_Factura.p_idOrden + "')", conn);
                comando.ExecuteNonQuery();
                comando.Dispose();
                conn.Close();


            }
            catch (Exception e) { e.ToString(); }

        }//

        public List<Factura> listaFacturas(int orID)
        {

            List<Factura> faturas = new List<Factura>();
            try
            {

                conection();
                comando = new SqlCommand("EXEC listaFac '" + orID + "' ", conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Factura fa = new Factura();
                    fa.p_idFactura = reader.GetInt32(0);
                    fa.p_fechaFactura = reader.GetDateTime(1);
                    fa.p_montoFactura = reader.GetDouble(2);
                    fa.p_r_Orden_Factura.p_idOrden = reader.GetInt32(3);

                    faturas.Add(fa);
                }


            }
            catch (Exception e) { e.ToString(); }

            return faturas;

        }//

        public void realizarPago(Pago pa)
        {


            try
            {

                conection();
                comando = new SqlCommand("EXEC realizarPago '" + pa.p_fechaPago + "' ", conn);
                comando.ExecuteNonQuery();
                comando.Dispose();
                conn.Close();


            }
            catch (Exception e) { e.ToString(); }

        }//..
    }//



}//

