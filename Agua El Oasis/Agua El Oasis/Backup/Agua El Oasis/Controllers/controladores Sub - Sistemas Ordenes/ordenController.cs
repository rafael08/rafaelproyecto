using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Orden;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Almacen;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente;
using Agua_El_Oasis.Models;
using Agua_El_Oasis.Controllers.controladores_Sub___Sistema_Cuenta_Cliente;


namespace Agua_El_Oasis.Controllers.controladores_Sub___Sistemas_Ordenes
{
    public class OrdenController : Controller
    {
        public static Catalogo r_ControladorOrden_catalogo=null;
        public static CarritoDeCompra r_ControladorOrden_CarritoDeCompras = null;
       
        

        //
        // GET: /orden/
       
        public ActionResult catalogoPagina()
        {
            if (CuentaClienteController.unCliente == null)
            {
                if (r_ControladorOrden_catalogo == null)
                {

                    r_ControladorOrden_catalogo = new Catalogo();
                    r_ControladorOrden_CarritoDeCompras = new CarritoDeCompra();
                    return View(r_ControladorOrden_catalogo.p_listaProductoCatalogo);
                }

                ViewBag.CantidadProductosCarrito = r_ControladorOrden_CarritoDeCompras.p_mi_carrito.Count();
                return View(r_ControladorOrden_catalogo.p_listaProductoCatalogo);
            }
            else 
            {
                ViewBag.CantidadProductosCarrito = CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito.Count();

               return View (CuentaClienteController.unCliente.p_r_Cliente_Catalogo.p_listaProductoCatalogo);
            
            }

        }


        [HttpPost]
        public ActionResult catalogoPagina(string buscar)
        {
            ////////OOOOOOOOOOOOOOJJJJJJJJJJJJJJJJJoooooooooooooooooooooooooooooo           

            return View(SingletonDA.Intancia().buscarProducto(buscar));
        }
/// <summary>
/// //Metodo Controlador que controla los productos que se agregan al carrito
/// </summary>
/// <param name="cantidad">Indica la cantidad del Producto que se agregrega</param>
/// <param name="proID">Indica el producto que se va a agregar</param>
/// <returns></returns>
        
        [HttpPost]
        public ActionResult agregarCarrito( int cantidad, int proID)
        {
            Producto agregarProd = new Producto();
            bool proEnCarrito = false;

            if (CuentaClienteController.unCliente == null)
            {
                for (int i = 0; i < r_ControladorOrden_CarritoDeCompras.p_mi_carrito.Count(); i++)
                {

                    if (r_ControladorOrden_CarritoDeCompras.p_mi_carrito.ElementAt(i).p_idProducto == proID)
                    {

                        r_ControladorOrden_CarritoDeCompras.p_mi_carrito.ElementAt(i).p_cantidad += cantidad;
                        proEnCarrito = true;

                    }

                }

                if (proEnCarrito == false)
                {

                    for (int i = 0; i < r_ControladorOrden_catalogo.p_listaProductoCatalogo.Count(); i++)
                    {


                        if (r_ControladorOrden_catalogo.p_listaProductoCatalogo.ElementAt(i).p_idProducto == proID)
                        {

                            agregarProd = r_ControladorOrden_catalogo.p_listaProductoCatalogo.ElementAt(i);
                            agregarProd.p_cantidad = cantidad;
                            r_ControladorOrden_CarritoDeCompras.agregarProducto(agregarProd);
                        }

                    }

                }

            }
            else
            {
                for (int i = 0; i < CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito.Count(); i++)
                {

                    if (CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito.ElementAt(i).p_idProducto == proID)
                    {

                        CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito.ElementAt(i).p_cantidad += cantidad;
                        proEnCarrito = true;

                       

                    }

                }

                if (proEnCarrito == false)
                {

                    for (int i = 0; i < CuentaClienteController.unCliente.p_r_Cliente_Catalogo.p_listaProductoCatalogo.Count(); i++)
                    {
                          

                        if (CuentaClienteController.unCliente.p_r_Cliente_Catalogo.p_listaProductoCatalogo.ElementAt(i).p_idProducto == proID)
                        {

                            agregarProd = CuentaClienteController.unCliente.p_r_Cliente_Catalogo.p_listaProductoCatalogo.ElementAt(i);
                            agregarProd.p_cantidad = cantidad;
                            CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.agregarProducto(agregarProd);
                        }

                       

                    }

                }
            }
            return RedirectToAction("catalogoPagina");
        }
/// <summary>
/// 
/// </summary>
/// <param name="proID"></param>
/// <returns></returns>
        public ActionResult eliminarProductoCarrito(int proID){


            if (CuentaClienteController.unCliente == null)
            {
                r_ControladorOrden_CarritoDeCompras.eliminarProductoCarrito(proID);
            }
            else 
            {

                CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.eliminarProductoCarrito(proID);
            
            
            }

            return RedirectToAction("carritoDeCompraPagina");
        }
/// <summary>
/// 
/// </summary>
/// <param name="proID"></param>
/// <param name="cantidad"></param>
/// <returns></returns>
       public ActionResult actualizarProductoCarrito(int proID,int cantidad){

           if (CuentaClienteController.unCliente == null)
           {
               r_ControladorOrden_CarritoDeCompras.actualizarProductoCarrito(proID, cantidad);
           }
           else
           {
               CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.actualizarProductoCarrito(proID, cantidad);
           }

           return RedirectToAction("carritoDeCompraPagina");
        }
/// <summary>
/// 
/// </summary>
/// <returns></returns>

        public ActionResult ordenDetallePagina()
        {
            if (CuentaClienteController.unCliente == null)
            {
                return RedirectToAction("loginPagina", "Login");
            }
            else
            {
                if (CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito.Count() != 0)
                {
                    CuentaClienteController.unCliente.p_r_Cliente_Orden = new Orden();
                    CuentaClienteController.unCliente.p_r_Cliente_Orden.p_r_Orden_Carrito.p_mi_carrito = CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito;
                    CuentaClienteController.unCliente.p_r_Cliente_Orden.p_r_Cliente_Titular = CuentaClienteController.unCliente;
                    return View(CuentaClienteController.unCliente.p_r_Cliente_Orden);
                }

                return RedirectToAction("catalogoPagina", "Orden");
                
            }

            
        }
/// <summary>
/// 
/// </summary>
/// <returns></returns>

        public ActionResult confirmarOrden() {

            if (CuentaClienteController.unCliente.p_r_Cliente_Orden != null)
            {

                int OrdId = 0;
                OrdId= CuentaClienteController.unCliente.p_r_Cliente_Orden.registrarOrden(CuentaClienteController.unCliente.p_r_Cliente_Orden);
                CuentaClienteController.unCliente.p_r_Cliente_Orden = null;
                CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito.Clear();


                return RedirectToAction("transaccionPagina", "pago", new { OrdId = OrdId });
            }
            else { 
                
             return RedirectToAction("", ""); 
            }

          
        
        }





/// <summary>
/// 
/// </summary>
/// <returns></returns>
        
        public ActionResult carritoDeCompraPagina()
        {


            if (CuentaClienteController.unCliente == null)
            {
               
                if (r_ControladorOrden_CarritoDeCompras.p_mi_carrito.Count!=0)
                {
                    ViewBag.CantidadProductosCarrito = r_ControladorOrden_CarritoDeCompras.p_mi_carrito.Count();
                    return View(r_ControladorOrden_CarritoDeCompras.mostrarProducto());
                }
                else
                {
                    return RedirectToAction("catalogoPagina");
                }
            }
            else
            {
                if (CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito.Count != 0)
                {
                    ViewBag.CantidadProductosCarrito = CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito.Count();
                    return View(CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.mostrarProducto());
                }
                else
                {
                    return RedirectToAction("catalogoPagina");
                }
            }

           
            
 
        }




    }
}
