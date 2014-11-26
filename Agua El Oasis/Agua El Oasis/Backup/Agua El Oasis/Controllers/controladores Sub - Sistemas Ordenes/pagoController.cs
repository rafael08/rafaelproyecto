using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Orden;
using Agua_El_Oasis.Controllers.controladores_Sub___Sistema_Cuenta_Cliente;

namespace Agua_El_Oasis.Controllers.controladores_Sub___Sistemas_Ordenes
{
    public class pagoController : Controller
    {
       
        
        //
        // GET: /pago/
         
        public ActionResult transaccionPagina( int OrdId)
        {
            Factura nuevaFactura = new Factura();
            nuevaFactura.p_r_Orden_Factura = new Orden();
            nuevaFactura.p_r_Orden_Factura = nuevaFactura.p_r_Orden_Factura.getOrden(OrdId);
            nuevaFactura.p_fechaFactura = new DateTime();
            nuevaFactura.p_fechaFactura = DateTime.Today;
            nuevaFactura.p_montoFactura = nuevaFactura.p_r_Orden_Factura.p_subTotal;
            

            Pago pago = new Pago();

            pago.p_fechaPago = new DateTime();
            pago.p_fechaPago = DateTime.Today;

            pago.p_r_Pago_Factura = nuevaFactura;
            pago.p_r_Pago_Cliente = CuentaClienteController.unCliente;
            return View(pago);
        }

    }
}
