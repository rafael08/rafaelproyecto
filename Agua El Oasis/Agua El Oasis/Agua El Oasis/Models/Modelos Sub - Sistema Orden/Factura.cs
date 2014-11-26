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
    public class Factura
    {
        private int idFactura;
        private DateTime fechaFactura;
        private double montoFactura;

        private Cliente r_ClienteFactura;//Corregida Almacena el estado del Cliente Titular de la Factura
        private List<Pago> r_PagosFactura;//Corregida Almacena el estado de los Obejo pago que saldaron la factura
        private Orden r_FacturaOrden;//Corregida Sirve para almacenar el estado del Objeto Orden que lo Genero




        public int p_idFactura
        {
            set { this.idFactura = value; }
            get { return this.idFactura; }
        }

        public DateTime p_fechaFactura
        {
            set { this.fechaFactura = value; }
            get { return this.fechaFactura; }
        }

        public double p_montoFactura
        {
            set { this.montoFactura = value; }
            get { return this.montoFactura; }
        }

        public Orden p_r_Orden_Factura
        {

            set { this.r_FacturaOrden = value; }
            get { return this.r_FacturaOrden; }

        }

        public Cliente p_r_Cliente_Factura
        {

            set { this.r_ClienteFactura = value; }
            get { return this.r_ClienteFactura; }
        }

        public List<Pago> p_r_Pagos_Factura
        {

            set { this.r_PagosFactura = value; }
            get { return this.r_PagosFactura; }

        }

        public Factura()
        {
            this.r_FacturaOrden = new Orden();
        
        
        }

        ~Factura()
        { }

        public void mostrarFactura() { }
        public void generaraFacturaDetalle() { }
        public double getMonto() {

            for (int i = 0; i < this.p_r_Orden_Factura.p_r_Orden_Carrito.p_mi_carrito.Count(); i++) {

                this.montoFactura += this.p_r_Orden_Factura.p_r_Orden_Carrito.p_mi_carrito[i].p_cantidad * this.p_r_Orden_Factura.p_r_Orden_Carrito.p_mi_carrito[i].p_precio;
            }
            return this.montoFactura;
        
        }

        public void registrarFactura()
        {
            SingletonDA.Intancia().factura(this);

        }
    }
}