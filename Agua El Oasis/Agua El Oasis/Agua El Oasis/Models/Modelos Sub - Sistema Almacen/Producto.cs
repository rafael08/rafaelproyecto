using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace Agua_El_Oasis.Models.Modelos_Sub___Sistema_Almacen
{
    public class Producto
    {
        private int idProducto;
        private string nombreProducto;
        private double precio;
        private int cantidad;
        private string descripcion;
        private string imagen;

       [Required]
       [Display(Name = "idProducto")]
        public int p_idProducto
        {
            set { this.idProducto = value; }
            get { return this.idProducto; }
        }

       [Required]
       [Display(Name = "nombre Producto")]
       public string p_nombreProducto
       {
           set { this.nombreProducto = value; }
           get { return this.nombreProducto; }
       }
       
       [Required]
       [Display(Name = "Precio")]
       public double p_precio
       {
           set { this.precio = value; }
           get { return this.precio; }
       }
       
        [Required]
       [Display(Name = "Cantidad")]
       public int p_cantidad
       {
           set { this.cantidad = value; }
           get { return this.cantidad; }
       }
           
       [Required]
       [Display(Name = "Descripcion")]
        public string p_descripcion
        {
            set { this.descripcion = value; }
            get { return this.descripcion; }
        }


       [Required]
       [Display(Name = "Imagen")]
       public string p_imagen
       {
           set { this.imagen = value; }
           get { return this.imagen; }
       }

       public Producto()
       {}

       ~Producto()
       {}



       public List<Producto> getProductos()
       {

           return SingletonDA.Intancia().listaProducto();
       }

       public Producto getProducto(int idProducto)
       {

           return SingletonDA.Intancia().getProducto(idProducto);
       }
       

       public void registrarProducto(Producto nProducto)
       {


           SingletonDA.Intancia().registoProducto(nProducto);
       }
       public String eliminarProducto(int idProducto)
       {

           return SingletonDA.Intancia().eliminarProducto(idProducto);
       }
       public String actualizarProducto(int idProducto,Producto productoActualizado)
       {

           return SingletonDA.Intancia().actualizarProducto(idProducto,productoActualizado);
       }

    }
}