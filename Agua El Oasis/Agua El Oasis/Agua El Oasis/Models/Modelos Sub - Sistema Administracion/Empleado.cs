using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Orden;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Almacen;
using Agua_El_Oasis.Models.Modelos_Sub___Sistema_Cuenta_Cliente;


namespace Agua_El_Oasis.Models.Modelos_Sub___Sistema_Administracion
{
    public partial class Empleado:Persona
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private string cargoEmpleado;
        private double salario;

        /// <summary>
        /// Objetos generados a partir de cada una de las relaciones que fueron establecidas
        /// con las clases correspondientes
        /// </summary>
        private Catalogo r_Empleado_Catalogo;//Permite al Empleado Ver el Catalogo
        private Producto r_Empleado_Producto;//Permite al Empleado acceder a la clase Producto para Registrar, Actualizar y Eliminar un Producto
        private Orden    r_Empleado_Orden;//Permite al Empleado Cambiar el estatus de la Orden
        private List<Orden> r_Ordenes_Empleado;//Permite al Empleado Conocer sus Ordenes Asignadas

        /// <summary>
        /// Propiedades get y set de los atributos de la clase
        /// </summary>
        [Required]
        [Display(Name = "Cargo Empleado")]
        public string p_cargoEmpleado
        {
            set { this.cargoEmpleado = value; }
            get { return this.cargoEmpleado; }
        }
       
        [Required]
        [Display(Name = "Salario Empleado")]
        public double p_salario
        {
            set { this.salario = value; }
            get { return this.salario; }
        }

        /// <summary>
        /// Propiedades get y set de las relaciones de la clase
        /// </summary>

        public Catalogo p_r_Empleado_Catalogo 
        {
            set { this.r_Empleado_Catalogo = value; } 
            get { return this.r_Empleado_Catalogo;  } 
        }

        public Producto p_r_Empleado_Producto 
        {
            set { this.r_Empleado_Producto = value; }
            get { return this.r_Empleado_Producto;  } 
        
        }

        public Orden p_r_Empleado_Orden 
        {
            set { this.r_Empleado_Orden = value; }
            get { return this.r_Empleado_Orden;  }
        }

        public List<Orden> p_r_Ordenes_Empleado 
        {
            set { this.r_Ordenes_Empleado = value; }
            get { return this.r_Ordenes_Empleado; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Empleado()
        {
            this.r_Empleado_Catalogo = new Catalogo();
            this.r_Empleado_Orden = new Orden();
            this.r_Empleado_Producto = new Producto();
        
        
        }

        ~Empleado()
        {

        }
        /// <summary>
        /// Metodos de la clase
        /// </summary>
        public void getEmpleado()
        {  }



    }
}