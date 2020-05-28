using System;
namespace Productos {
    interface IHeader {
        string txt_Header();
    }
    /// <summary>
    /// Definicion de producto, no se puede instanciar.
    /// </summary>
    abstract class Producto :IHeader{
        public int departamento { get; set; }
        public string codigo {
            get => this.codigo;
            set {
                this.codigo = String.Format("{0}-{1}", this.departamento, value.Replace(' ', '-'));
            }
        }
        public string descripcion { get; set; }
        //List<PrecioFecha> precios;
        public int likes { get; set; }
        public int precio {
            set {
                this.precio = value;
            }
            /*get {
                this.precios.PrecioActual;
            }*/
        }
        /*Sobrecarga de constructor*/
        public Producto() { }
        public Producto(int departamento, string codigo, string descripcion, int likes, int precioBase) {
            this.departamento = departamento;
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.likes = likes;
            this.precio = precioBase;
        }
        string IHeader.txt_Header() {
            return String.Format("Departamento|Codigo|Descripcion|Likes|Precio|Fecha_Registro");
        }
    }
}
