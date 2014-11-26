using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Almacen;



namespace Agua_El_Oasis.Models.Modelos_Sub___Sistema_Orden
{
    public  class CarritoDeCompra
    {

        

        private List<Producto> mi_carrito;//Corregido Almacena los Productos seleccionados del Catalogo
        

        //Propiedades get y set de los atributos de la clase

        public List<Producto> p_mi_carrito {

            set { this.mi_carrito = value; }

            get { return this.mi_carrito; }
        
        }

        public CarritoDeCompra() {

            mi_carrito = new List<Producto>();

   
        }
        public void agregarProducto(Producto agreProducto)
        {

            mi_carrito.Add(agreProducto);
        }
        public  List<Producto> mostrarProducto() {

            return mi_carrito;
        
        }
        public void eliminarProductoCarrito(int proID) {


            for (int i = 0; i < p_mi_carrito.Count();i++ )
            {


                if (p_mi_carrito.ElementAt(i).p_idProducto == proID)
                {

                    p_mi_carrito.RemoveAt(i);

                }


            }
        
        }
        public void actualizarProductoCarrito(int proID,int cantidad) {



            for (int i = 0; i < p_mi_carrito.Count(); i++)
            {


                if (p_mi_carrito.ElementAt(i).p_idProducto == proID)
                {

                    p_mi_carrito.ElementAt(i).p_cantidad=cantidad;

                }


            }
        
        
        }
        public void total() { }
    }
}