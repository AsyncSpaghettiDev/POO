using System;
using System.Collections.Generic;

namespace Productos {
    /// <summary>
    /// Definicion de producto, no se puede instanciar.
    /// </summary>
    abstract class Producto {
        public int departamento { get; set; }
        public string codigo {
            get => this.codigo;
            set {
                this.codigo = String.Format("{0}-{1}",this.departamento,value.Replace(' ','-'));
            }
        }
        public string descripcion { get; set; }
        //List<PrecioFecha> precios;
        public int likes { get; set; }
        /*Sobrecarga de constructor*/
        public Producto() { }
        public Producto(int departamento, string codigo,string descripcion,int likes) {
            this.departamento = departamento;
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.likes = likes;
        }
    }
    /// <summary>
    /// Definicion de mercancía que tiene una caducidad, que se echa a perder, y que se le debe dar la debida rotación antes de que se deteriore y se haga no apta para la venta, o bien, que se convierta en merma.
    /// </summary>
    class ProductoPerecedero : Producto {
        public ProductoPerecedero(int departamento, string codigo, string descripcion, int likes) : base(departamento,codigo,descripcion,likes) { }
    }
    class ProductoNoPerecedero : Producto {
        public ProductoNoPerecedero(int departamento, string codigo, string descripcion, int likes) : base(departamento, codigo, descripcion, likes) { }
    }
}
