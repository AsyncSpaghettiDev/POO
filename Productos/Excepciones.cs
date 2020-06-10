using System;

namespace Productos {
    /// <summary>
    /// Excepcion que se produce cuando el departamento ingresado no existe en la DB departamentos.
    /// </summary>
    class InvalidDepartamentException : Exception {
        /// <summary>
        /// Inicia una instancia de la clase InvalidDepartamentException.
        /// </summary>
        public InvalidDepartamentException() : base("Departamento Inválido revisa la tabla de Departamentos") {
            this.HelpLink = "http://ito.mx/MBRr";
        }
    }
    /// <summary>
    /// Excepcion que se produce cuando la vida útil de un producto ha llegado a su fin.
    /// </summary>
    class ProductoSinVidaException : Exception {
        /// <summary>
        /// Inicia una instancia de la clase ProductoSinVidaException.
        /// </summary>
        public ProductoSinVidaException():base ("El producto se encuentra en estado de merma. ") { }
    }
    /// <summary>
    /// Excepcion que se produce cuando la busqueda no arroja ningún resultado.
    /// </summary>
    class ResultadoNuloException : Exception {
        /// <summary>
        /// Inicia una instancia de la clase ResultadoNuloException.
        /// </summary>
        public ResultadoNuloException() : base("Busqueda sin resultados, intenta ingresando otros datos") { }
    }
}
