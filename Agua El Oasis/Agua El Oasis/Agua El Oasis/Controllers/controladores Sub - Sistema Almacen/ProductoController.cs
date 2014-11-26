using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Almacen;

namespace Agua_El_Oasis.Controllers.controladores_Sub___Sistema_Almacen
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/
        public ActionResult almacenPagina()
        {
            return View();
        }
        public ActionResult verProductosPagina()
        {
            Producto producto = new Producto();

            return View(producto.getProductos());
        }
        //Get
        public ActionResult nuevoProductoPagina()
        {
            return View();
        }
        [HttpPost]
        public ActionResult nuevoProductoPagina(Producto nuevoProducto)
        {
            Producto nuProducto = new Producto();

            nuProducto.registrarProducto(nuevoProducto);
            return View("verProductosPagina");
        }

        public ActionResult detalleProductoPagina(int proID)
        {
            Producto producto = new Producto();

            producto = producto.getProducto(proID);



            return View(producto);
        }
        //Get
        public ActionResult actualizarProductoPagina(int proID)
        {
            Producto producto = new Producto();
            producto = producto.getProducto(proID);

            return View(producto);
        }
        [HttpPost]
        [ActionName("actualizarProductoPagina")]
        public ActionResult actProductoPagina(int proID, Producto productoActualizado)
        {
            Producto producto = new Producto();
            producto.actualizarProducto(proID, productoActualizado);

            return RedirectToAction("verProductosPagina","Producto");
        }
        //Get
        public ActionResult eliminarProductoPagina(int proID)
        {
            Producto producto = new Producto();

            producto = producto.getProducto(proID);
            
            return View(producto);

        }
        [HttpPost]
        [ActionName("eliminarProductoPagina")]
        public ActionResult elimProductoPagina(int proID)
        {

            Producto producto = new Producto();
            producto.eliminarProducto(proID);

            return RedirectToAction("verProductosPagina","Producto");
        }
    }
}
