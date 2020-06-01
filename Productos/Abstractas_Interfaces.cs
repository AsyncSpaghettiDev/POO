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
        public string departamento { get; set; }
        protected string _codigo;
        public string codigo {
            get => this._codigo;
            set => this._codigo = String.Format("{0}-{1}", this.departamento, value.Replace(' ', '-'));
        }
        public string descripcion { get; set; }
        protected List<PrecioFecha> precios;
        protected double _likes;
        public double likes { 
            get=>this._likes;
            set{
                if (value <= 100)
                    this._likes = value;
                /*else
                    throw new TooMuchCharactersException();*/
            }
        }
        protected double _precio;
        public double precio {
            set => this._precio = value;
            
            /*get {
                return this.precios[0].precio;
            }*/
        }
        /*Sobrecarga de constructor*/
        public Producto() { }
        public Producto(string departamento, string codigo, string descripcion, double likes, double precioBase) {
            this.precios = new List<PrecioFecha>(3);
            this.departamento = departamento;
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.likes = likes;
            this.precio = precioBase;
        }
        public override string ToString() => String.Format("{0}|{1}|{2}|{3}\n|{4}", this.codigo, this.descripcion, this.likes, this.precios[0].precio, this.precios[0].f_Fin.ToString("dd-MM-yyyy:HH"));
        string IHeader.txt_Header() => String.Format("Departamento|Codigo|Descripcion|Likes|Precio|Fecha_Registro");
        
    }
}