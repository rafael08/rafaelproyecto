using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente;


namespace Agua_El_Oasis.Models.Modelos_Sub___Sistema_Orden
{
    public class Pago
    {
        
        private int idPago;
        private long numTargeta;
        private int pin;
        private DateTime fecha;
        private Factura r_Pago_Factura;//Corregida Almacena el estado de la Factura a la que se le va a realizar el pago
        private Cliente r_Pago_Cliente;//Corregida Almacena el estado del Cliente Que realiza el pago para que la clase pago conosca del Cliente que hace el pago




        [Required]
        [Display(Name = "Id pago")]
        public int p_idPago
        {
            set { this.idPago = value; }
            get { return this.idPago; }
        }



        [Required]
        [Display(Name = "Numero de Tarjeta")]
        public long p_numTargeta
        {
            set { this.numTargeta = value; }
            get { return this.numTargeta; }
        }

        [Required]
        [Display(Name = "Pin Tarjeta")]
        public int p_pin
        {
            set { this.pin= value; }
            get { return this.pin; }
        }

        [Required]
        [Display(Name = "Fecha Pago")]
        public DateTime p_fechaPago
        {
            set { this.fecha = value; }
            get { return this.fecha; }
        }

        public Factura p_r_Pago_Factura
        {
            set { this.r_Pago_Factura = value; }
            get { return this.r_Pago_Factura; }
        }

        public Cliente p_r_Pago_Cliente
        {
            set { this.r_Pago_Cliente = value; }
            get { return this.r_Pago_Cliente; }
        }



	public Pago(){}

	~Pago(){}
        
        public void calcularTotal() { }

        public void getTipoPago( ){}

        public void realizarCargo(){}


    }
}