using System;
using System.Collections.Generic;

namespace Productos {
    /// <summary>
    /// Definicion de mercancía que tiene una caducidad, que se echa a perder, y que se le debe dar la debida rotación antes de que se deteriore y se haga no apta para la venta, o bien, que se convierta en merma.
    /// </summary>
    class ProductoPerecedero : Producto {
        public ProductoPerecedero(int departamento, string codigo, string descripcion, int likes, int precioBase) : base(departamento,codigo,descripcion,likes, precioBase) { }
    }
    /// <summary>
    /// Definicion de aquellos artículos que son clasificados como no básicos,
    /// </summary>
    class ProductoNoPerecedero : Producto {
        public ProductoNoPerecedero(int departamento, string codigo, string descripcion, int likes, int precioBase) : base(departamento, codigo, descripcion, likes, precioBase) { }
    }
}
