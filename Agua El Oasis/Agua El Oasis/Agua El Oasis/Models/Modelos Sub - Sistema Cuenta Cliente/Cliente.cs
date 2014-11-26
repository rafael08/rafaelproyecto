using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Orden;

namespace Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente{

    public class Cliente:Persona{

        
        //Relaciones que nos permiten acceder desde la clase Cliente a sus clases relacionadas
        // Los cuales salieron de las relaciones desarrolladas en el modelo del dominio
        //////////////////////////////////////////////////////////////////////////////////////
        private Catalogo  r_Cliente_Catalogo; //Corregida Permite al Cliente Ver el Catalogo y agregar productos al Carrito de Compras
        private Orden r_Cliente_Orden;
        private Factura r_Cliente_Factura;
        private CarritoDeCompra r_Cliente_CarritoDeCompras;
        private Pago r_Cliente_Pago;//Permite al Cliente acceder al la clase Pago para realizar el pago de la Orden
        // private CarritoDeCompra m_CarritoDeCompras; //Corregida Permite al Cliente ver su Carro de Compras

        //Relaciones que implican varios objetos de varias Clases asociados a la clase Cliente
        ///////////////////////////////////////////////////////////////////////////////////////
        private List<Orden> r_Ordenes_Cliente; //Corregida Se utiliza para contener las Ordenes que el Cliente ha realizado
        private List<Factura> r_Facturas_Cliente;//Corregida Se utiliza para contener las Facturas que pertenecen al Cliente
        private List<Pago> r_Pagos_Cliente; //Corregida Se utiliza para contener los Pagos que el Cliente ha realizado
       
        //Propiedades set y get
        public Catalogo p_r_Cliente_Catalogo{

            set { this.r_Cliente_Catalogo = value; }
            get { return this.r_Cliente_Catalogo;  }
        }
        public Orden p_r_Cliente_Orden
        {

            set { this.r_Cliente_Orden = value; }
            get { return this.r_Cliente_Orden;  }
        }
        public Factura p_r_Cliente_Factura
        {

            set { this.r_Cliente_Factura = value; }
            get { return this.r_Cliente_Factura;  }
        }
        public CarritoDeCompra p_r_Cliente_CarritoDeCompras
        {


            set { r_Cliente_CarritoDeCompras = value; }
            get { return r_Cliente_CarritoDeCompras; }


        }
        public Pago p_r_Cliente_Pago
        {

            set { this.r_Cliente_Pago = value; }
            get { return this.r_Cliente_Pago;  }
        }

        public Cliente() {

            this.r_Cliente_Catalogo = new Catalogo();
            //Verificar Cuales de estos Objetos es necesacio que se inicializen con la creacion de un Objeto Cliente es decir en el constuctor
            // y cuales no para Crearles sus propios metodos

            // Asignando memoria a los Objetos que nos permiten acceder desde la clase Cliente a sus clases relacionadas
            // Los cuales salieron de las relaciones desarrolladas en el modelo del dominio
            //////////////////////////////////////////////////////////////////////////////////////
           //Etatico para verificar this.r_Cliente_Catalogo = new Catalogo();

            this.r_Cliente_CarritoDeCompras = new CarritoDeCompra();//Le asignamos Memoria al Objeto m_carritoDeCompras que fue definido dentro de la clase catalogo, el Cual salio de la relacion de las clases Catalogo-CarritoDeCompra

            //Llenando los contenedores con los Objetos asociados a la Clase Cliente a traves de las Relaciones entre ambas Clases            
            ///////////////////////////////////////////////////////////////////////////////////////
            this.r_Ordenes_Cliente = new List<Orden>();//Hacer un metodo que devuelva una lista de todas las Ordenes que estan asociadas al Cliente Actual(va dentro de la clase Orden y se accedera a el desde la clase Cliente
            //this.r_Ordenenes_Cliente=r_Cliente_Orden.getOrdenes(idCliente); Isaac Medina
            this.r_Facturas_Cliente = new List<Factura>();//Hacer un metodo que  devuelva una lista de todas las Facturas que estan asociadas al Cliente Actual
            //this.r_Facturas_Cliente=r_Cliente_Factura.getFacturas(idCliente); Isaac Medina
            this.r_Pagos_Cliente = new List<Pago>();//Hacer un metodo que devuelva una Lista de todos los pagos que estan asociados al Cliente Actual
        }

        ~Cliente()
        {

        }


        public Cliente getCliente(string usuario, string contraseña) {


            return SingletonDA.Intancia().dataCliente(usuario, contraseña);
        }
        public void modificarData(){}









    }
}