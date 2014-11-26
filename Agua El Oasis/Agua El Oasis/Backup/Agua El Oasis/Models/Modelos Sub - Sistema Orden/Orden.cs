using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Almacen;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Administracion;

namespace Agua_El_Oasis.Models.Modelos_Sub___Sistema_Orden
{
    public class Orden
    {

        private int ordenId;
        private DateTime fechaOrden;
        private DateTime fechaEntrega;
        private string statusOrden;
        private Double subTotal;
        private CarritoDeCompra r_Orden_Carrito;//Almacena Los Productos que pertenecen a la Orden
        private List<Empleado> r_Empleado_Orden;//Corregida Sirve para almacenar los 2 empleados encargado de la Orden "El encargado de verificar la Orden y el Delivery" esta lista debe ser de 2 solamente
        private Cliente r_cliente_Titular;//Corregida El estado del objeto almacena el cliente titular de la Orden


        public int p_idOrden
        {
            set { this.ordenId = value; }
            get { return this.ordenId; }
        }

        public DateTime p_fechaOrden
        {
            set { this.fechaOrden = value; }
            get { return this.fechaOrden; }
        }
        public DateTime p_fechaEntrega
        {
            set { this.fechaEntrega = value; }
            get { return this.fechaEntrega; }
        }
        public string p_statusOrden
        {
            set { this.statusOrden = value; }
            get { return this.statusOrden; }
        }
        public double p_subTotal
        {
            set { this.subTotal = value; }
            get { return this.subTotal; }
        }


        //propiedad de las clases relaciones


        public CarritoDeCompra p_r_Orden_Carrito
        {
            set { this.r_Orden_Carrito = value; }
            get { return this.r_Orden_Carrito; }
        }

        public List<Empleado> p_r_Empleados_Orden
        {
            set { this.r_Empleado_Orden = value; }
            get { return this.r_Empleado_Orden; }
        }

        public Cliente p_r_Cliente_Titular
        {
            set { this.r_cliente_Titular = value; }
            get { return this.r_cliente_Titular; }
        }////////////////////////////////////////////////





        public Orden()
        {
            this.p_fechaOrden = new DateTime();
            this.p_fechaOrden = DateTime.Today;
            
            this.p_fechaEntrega = new DateTime();
            this.p_fechaEntrega = DateTime.Today.AddDays(3d);
           
            this.p_statusOrden = "no confirmada";
            //Habilitando los contenedores Para que se le Puedan Insertar los Datos
            //Estos contenedores Son Producto de las Relaciones establecidas en el Domain Model class Diagram
            this.r_Orden_Carrito = new CarritoDeCompra();
            this.r_Empleado_Orden = new List<Empleado>();//Hay que Asignarle los Empleados Correspondientes

        }

        ~Orden()
        { }

        public void getFechaOrden() { }

        public Orden getOrden(int OrdId) {

            return SingletonDA.Intancia().unaOrden(OrdId);
        }

        public void getStatusOrden() { }

        public void verStatusOrden() { }

        public int registrarOrden(Orden nuevaOrden)
        {

           return SingletonDA.Intancia().registrarOrden(nuevaOrden);

        }



    }
}