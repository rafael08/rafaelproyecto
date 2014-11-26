using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Almacen;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente;



namespace Agua_El_Oasis.Models.Modelos_Sub___Sistema_Orden
{
    public class Catalogo
    {
        
        private Producto r_Catalogo_Producto=null;
        private List<Producto> listaProductoCatalogo=null;
       
      


        //Propiedades get y set de cada Atributo//Ojo verificar si es necesaria
        public List<Producto> p_listaProductoCatalogo {

            set { listaProductoCatalogo=value;}
            get { return listaProductoCatalogo; }
        
        
        }

        public Producto p_r_Catalogo_Producto
        {


            set { this.r_Catalogo_Producto = value; }
            get { return this.r_Catalogo_Producto;  }


        }
       
        

        public Catalogo()
        {
           
            this.r_Catalogo_Producto= new Producto();//Le asignamos Memoria al Objeto m_producto que fue definido dentro de la clase catalogo, el Cual salio de la relacion de las clases Catalogo-Producto
            this.p_listaProductoCatalogo = r_Catalogo_Producto.getProductos();//usamos el Objeto de tipo producto para acceder al metodo getProductos de la clase Producto y llenar la lista de Producto que hay en la clase catalogo la cual salio de la relacion entre las clases Catalogo-Producto
                
        }

        ~Catalogo()
        {}

        public void mostrarProducto() {
             
        }

        public void setCantidad() { }
    }
}