using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Remoting.Contexts;
using System.Data.OleDb;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using Agua_El_Oasis.Controllers.controladores_Sub___Sistemas_Ordenes;
using Agua_El_Oasis.Controllers.controladores_Sub___Sistema_Cuenta_Cliente;
using System.Web.Mvc;

namespace Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente
{
    public class Login
    {

        //Atributos de la Clase
        private string nombreUsuario;
        private string contrasenaPersona;

        //Propiedades get y set de los Atributos de la Clase 
        [Required(ErrorMessage = "!El Nombre de Usuario es un campo requerido!")]
        [Display(Name = "Nombre de usuario")]
        public string p_nombreUsuario
        {
            set { this.nombreUsuario = value; }
            get { return this.nombreUsuario; }
        }

        [Required(ErrorMessage = "!La Contraseña es un campo requerido!")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string p_contrasenaPersona
        {
            set { this.contrasenaPersona = value; }
            get { return this.contrasenaPersona; }
        }

        //Metodos de la Clase
        ////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool autenticarUsuario()
        {

            
            return SingletonDA.Intancia().autenticarUsuario(this.nombreUsuario, this.contrasenaPersona);
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <param name="nombreUsuario"></param>
        /// <param name="contraseña"></param>
        /// <param name="establecerCookiesPersistentes"></param>

        public string[] inicioSession(string nombreUsuario, string contraseña, bool establecerCookiesPersistentes)
        {
           // if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            string [] usuario=new string[3];
           
             
            
            
           
            CuentaClienteController.unCliente = new Cliente();
            CuentaClienteController.unCliente=CuentaClienteController.unCliente.getCliente(nombreUsuario, contraseña);

            usuario[0] = CuentaClienteController.unCliente.p_idPersona.ToString();
            usuario[1] = CuentaClienteController.unCliente.p_tipoPersona.ToString();
            usuario[2] = CuentaClienteController.unCliente.p_nombreUsuario;


                if (OrdenController.r_ControladorOrden_CarritoDeCompras!=null)
                {
                    CuentaClienteController.unCliente.p_r_Cliente_CarritoDeCompras.p_mi_carrito = OrdenController.r_ControladorOrden_CarritoDeCompras.p_mi_carrito;

                    OrdenController.r_ControladorOrden_CarritoDeCompras = null;
                    OrdenController.r_ControladorOrden_catalogo = null;


                }
            
            
            return usuario;


        }

        /// <summary>
        /// 
        /// </summary>

        public static void salir()
        {
            CuentaClienteController.unCliente = null;
            FormsAuthentication.SignOut();
            
            
        }
       
     
    
    }
}