using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Almacen;

namespace Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente{
    public partial class Persona{


        /// <summary>
        /// Atributos de la Clase
        /// </summary>
        private int idPersona;
        private string nombrePersona;
        private string apellidoPersona;
        private string direccionPersona;
        private string emailPersona;
        private string cedulaPersona;
        private string UsuarioPersona;
        private string contrasenaPersona;
        private string confirmContrasena;
        private long telefonoPersona;
        private int tipoPersona;


        /// <summary>
        /// Propiedades get y set de los atributos de la clase
        /// </summary>
        /// /////////////////////////////////////////////////
        [Display(Name = "Nombre")]
        public int p_idPersona
        {
            set { this.idPersona = value; }
            get { return this.idPersona; }
        }

        [Required(ErrorMessage = "!El Nombre es un campo requerido!")]
        [Display(Name = "Nombre")]
        public string p_nombrePersona
        {
            set { this.nombrePersona = value; }
            get { return this.nombrePersona; }
        }

        [Required(ErrorMessage="!El Apellido es un campo requerido!")]
        [Display(Name = "Apellido")]
        public string p_apellidoPersona
        {
            set { this.apellidoPersona = value; }
            get { return this.apellidoPersona; }
        }

        [Required(ErrorMessage = "!La Direccion es un campo requerido!")]
        [Display(Name = "Direccion")]
        public string p_direccion_Persona
        {
            set { this.direccionPersona = value; }
            get { return this.direccionPersona; }
        }

        [Required(ErrorMessage = "!El Email es un campo requerido!")]
        [Display(Name = "Email")]
        public string p_email_Persona
        {
            set { this.emailPersona = value; }
            get { return this.emailPersona; }
        }

        [Required(ErrorMessage = "!La Cedula es un campo requerido!")]
        [StringLength(11,ErrorMessage="El tamaño maximo de la cedula es 11!")]
        [Display(Name = "cedula")]
        public string p_cedula_Persona
        {
            set { this.cedulaPersona = value; }
            get { return this.cedulaPersona; }
        }

        [Required(ErrorMessage = "!El Nombre de Usuario es un campo requerido!")]
        [Display(Name = "Nombre de usuario")]
        public string p_nombreUsuario
        {
            set { this.UsuarioPersona = value; }
            get { return this.UsuarioPersona; }
        }

        [Required(ErrorMessage = "!La Contraseña es un campo requerido!")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string p_contrasenaPersona
        {
            set { this.contrasenaPersona = value; }
            get { return this.contrasenaPersona; }
        }

        [Required(ErrorMessage = "!Debe confirmar la contraseña!")]
        [DataType(DataType.Password)]
        [Compare("p_contrasenaPersona", ErrorMessage = "!Las contraseñas no coinciden!")]
        [Display(Name = "Confirmar Contraseña")]
        public string p_confirmContrasena
        {
            set { this.confirmContrasena = value; }
            get { return this.confirmContrasena; }
        }

        [Required]
        [Display(Name = "telefono")]
        public long p_telefonoPersona
        {
            set { this.telefonoPersona = value; }
            get { return this.telefonoPersona; }
        }

        [Required]
        [Display(Name = "tipoPersona")]
        public int p_tipoPersona
        {
            set { this.tipoPersona = value; }
            get { return this.tipoPersona; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Persona() {

        
        }

        /// <summary>
        /// Metodo que permite registrar un cliente
        /// </summary>
        /// <param name="nuevoCliente">Objeto que conti</param>
        /// <returns></returns>
        public string registrarPersona(Cliente nuevoCliente)
        {
            //if (String.IsNullOrEmpty(p_nombrePersona)) throw new ArgumentException("Value cannot be null or empty.", "p_nombrePersona");
            return SingletonDA.Intancia().registroPersona(nuevoCliente);

        }
        

    }
}
