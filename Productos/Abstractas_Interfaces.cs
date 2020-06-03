using System;
using System.Collections.Generic;

namespace Productos {
    /// <summary>
    /// Devuelve un string con los headers de los atributos del producto.
    /// </summary>
    interface IHeader {
        /// <summary>
        /// Metodo que regresa los headers correspondientes al objeto.
        /// </summary>
        /// <returns>Headers en String</returns>
        string txt_Header();
    }
    /// <summary>
    /// Definicion de un precio con limite de tiempo
    /// </summary>
    abstract class PrecioFecha:IHeader {
        /// <summary>
        /// Obtiene o establece la fecha de inicio del costo del producto.
        /// </summary>
        public DateTime f_Inicio { get; set; }
        protected DateTime _f_Fin;
        /// <summary>
        /// Obtiene o establece la fecha de fin del costo del producto.
        /// </summary>
        public DateTime f_Fin {
            get => this._f_Fin;
        }
        /// <summary>
        /// Obtiene o establece el costo del producto.
        /// </summary>
        public double precio { get; set; } 
        public PrecioFecha(DateTime f_Inicio, double precio) {
            this.f_Inicio = f_Inicio;
            this.precio = precio;
        }
        /// <summary>
        /// Establece la fecha final aumentando en una cierta cantidad de dias la fecha inicial.
        /// </summary>
        /// <param name="dias">Dias que tiene el producto antes de pasar al siguiente estado.</param>
        protected void Aumenta(double dias) => this._f_Fin = f_Inicio.AddDays(dias);
        string IHeader.txt_Header() => String.Format("Fecha_Inicio|Fecha_Fin|Precio");
        
    }
    /// <summary>
    /// Definicion de producto, no se puede instanciar.
    /// </summary>
    abstract class Producto :IHeader{
        /// <summary>
        /// Obtiene o establece al departamento que pertenece el producto
        /// </summary>
        public string departamento { get; set; }
        /// <summary>
        /// Obtiene o establece el codigo el producto registrado
        /// </summary>
        public string codigo { get; set; }
        /// <summary>
        /// Obtiene o establece la descripcion del producto a registrado
        /// </summary>
        public string descripcion { get; set; }
        /// <summary>
        /// Lista de precios cambiantes al tiempo
        /// </summary>
        protected List<PrecioFecha> precios;
        /// <summary>
        /// Obtiene o establece la puntuacion dada del publico al producto
        /// </summary>
        public double likes { get; set; }
        protected double _precio;
        /// <summary>
        /// Obtiene el precio en el momento actual, establece el precio de lanzamiento.
        /// </summary>
        public double precio {
            set => this._precio = value;
            get {
                foreach (PrecioFecha precio in precios)
                    if (precio.f_Fin > DateTime.Now)
                        return precio.precio;
                return 0;
            }
        }
        /*Sobrecarga de constructor*/
        public Producto() { }
        /// <summary>
        /// Creacion de un producto generico
        /// </summary>
        /// <param name="departamento">Departamento al que pertence el producto</param>
        /// <param name="codigo">Codigo del producto</param>
        /// <param name="descripcion"></param>
        /// <param name="likes"></param>
        /// <param name="precioBase"></param>
        public Producto(string departamento, string codigo, string descripcion, double likes, double precioBase) {
            this.precios = new List<PrecioFecha>(3);
            this.departamento = departamento;
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.likes = likes;
            this.precio = precioBase;
        }
        public override string ToString() => String.Format("{0}|{1}|{2}|{3}", this.departamento,this.codigo, this.descripcion, this.likes,this.precios[0].f_Inicio,this.precios[0].precio);
        string IHeader.txt_Header() => String.Format("Departamento|Codigo|Descripcion|Likes|FechaLanzamiento|PrecioLanzamiento|FechaMadurez|PrecioMadurez|FechaMerma|PrecioMerma");
        
    }
}