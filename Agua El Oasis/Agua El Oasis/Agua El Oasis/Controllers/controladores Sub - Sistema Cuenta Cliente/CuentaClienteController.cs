
using System.Web.Mvc;
using System.Web.Security;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente;
using Agua_El_Oasis.DA;

namespace Agua_El_Oasis.Controllers.controladores_Sub___Sistema_Cuenta_Cliente
{
    public class CuentaClienteController : Controller
    {
        public static Cliente unCliente;

        public ActionResult cuentaClientePagina()
        {
            if (unCliente == null)
            {

                RedirectToAction("loginPagina","Login");
            }
            return View(unCliente);
        }

        //
        // GET: /CuentaCliente/
       
        public ActionResult registroClientePagina()
        {

                return View();
        }

        [HttpPost]
        public ActionResult registroClientePagina(Cliente nuevaPersona)
        {
            if (ModelState.IsValid)
            {

                Cliente cli = new Cliente();
                /// string ped = pe.registrarPersona(nuevaPersona);
                // ViewBag.error = pe.registrarPersona(nuevaPersona);
                cli.registrarPersona(nuevaPersona);
              //  LoginPagina(Login log, string returnUrl) debes llmar este metodo
                // y enviarle estos parametros para que el usuario quede logueado
                //automaticamente ahora solo te voy a enviar a la principal
                TempData["Message"] = QueryResultSingleton.Intance.Message;

                return RedirectToAction("catalogoPagina", "orden");
            }
            return View(nuevaPersona);
        }


        public ActionResult cambioContrasenaPagina()
        {
            return View();
        }



        public ActionResult actualizarDatosCliente()
        {
            return View();
        }


    }
}
