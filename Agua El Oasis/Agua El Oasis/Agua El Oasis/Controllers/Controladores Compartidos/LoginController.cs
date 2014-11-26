
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente;

namespace Agua_El_Oasis.Controllers.controladores_Compartidos
{
    public class LoginController : Controller
    {

        //Get
        public ActionResult LoginPagina(string returnUrl)
        {
            if (Request.Cookies["Usuario"] == null)
            {
                return View();
            }
            else
            {

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("catalogoPagina", "Orden");
                }

            }

        }

        [HttpPost]
        public ActionResult LoginPagina(Login log, string returnUrl)
        {
            if (ModelState.IsValid)
            {



                if (log.autenticarUsuario())
                {
                    Login obj = new Login();
                    string[] usuarioActual = new string[3];
                    HttpCookie usuarioCookies = new HttpCookie("Usuario");

                    usuarioActual = obj.inicioSession(log.p_nombreUsuario, log.p_contrasenaPersona, false);

                    usuarioCookies["id"] = usuarioActual[0];
                    usuarioCookies["Role"] = usuarioActual[1];
                    usuarioCookies["nomUsuario"] = usuarioActual[2];


                    Response.Cookies.Add(usuarioCookies);


                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("catalogoPagina", "Orden");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error de Usuario o Contraseña.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(log);
        }
        public ActionResult salir()
        {

            Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(-1d);
            Login.salir();

            return RedirectToAction("catalogoPagina", "Orden");
        }
    }
}
