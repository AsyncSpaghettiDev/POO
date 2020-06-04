using System;
namespace Productos {
    /// <summary>
    /// Definicion de mercancía que tiene una caducidad, que se echa a perder, y que se le debe dar la debida rotación antes de que se deteriore y se haga no apta para la venta, o bien, que se convierta en merma.
    /// </summary>
    class ProductoPerecedero : Producto {
        public ProductoPerecedero() { }
        /// <summary>
        /// Creacion de producto que requiere de rotacion para evitar merma.
        /// </summary>
        /// <param name="departamento">Departamento al que pertenece, consular tabla de departamentos</param>
        /// <param name="codigo">Codigo del Producto</param>
        /// <param name="descripcion">Descripcion del producto actual.</param>
        /// <param name="likes">Calificacion basada en el publico</param>
        /// <param name="precioBase">Precio de lanzamiento</param>
        /// <param name="tiempo">Fecha de salida a venta general.</param>
        public ProductoPerecedero(string departamento, string codigo, string descripcion, double likes, double precioBase, DateTime tiempo) :
            base(departamento,codigo,descripcion,likes) {

            this.precios= new PrecioFechaP(tiempo, precioBase,15);
            for (int i = 1; i < 3; i++)
                this.precios = new PrecioFechaP(this._precios[i - 1].f_Fin, this._precios[i - 1].precio * 0.85,i*15);
        }
    }
    /// <summary>
    /// Definicion de aquellos artículos que son clasificados como no básicos,
    /// </summary>
    class ProductoNoPerecedero : Producto {
        public ProductoNoPerecedero() { }
        /// <summary>
        /// Creacion de producto que no requiere de rotacion.
        /// </summary>
        /// <param name="departamento">Departamento al que pertenece, consular tabla de departamentos</param>
        /// <param name="codigo">Codigo del Producto</param>
        /// <param name="descripcion">Descripcion del producto actual.</param>
        /// <param name="likes">Calificacion basada en el publico</param>
        /// <param name="precioBase">Precio de lanzamiento</param>
        /// <param name="tiempo">Fecha de salida a venta general.</param>
        public ProductoNoPerecedero(string departamento, string codigo, string descripcion, double likes, double precioBase, DateTime tiempo) :
            base(departamento, codigo, descripcion, likes) {

            this.precios=new PrecioFechaNP(tiempo, precioBase,30);
            for (int i = 1; i < 3; i++)
                this.precios = new PrecioFechaNP(this._precios[i - 1].f_Fin, this._precios[i - 1].precio*0.90, i * 30);
        }
        
    }
}
