using System;

namespace Productos {
    class InvalidDepartamentException : Exception {
        public InvalidDepartamentException() : base("Departamento Inválido revisa la tabla de Departamentos") {
            this.HelpLink = "http://ito.mx/MBRr";
        }
    }
    class ProductoSinVidaException : Exception {
        public ProductoSinVidaException():base ("El producto se encuentra en estado de merma. ") { }
    }
    class ProductoNoPerecederoException : Exception {
        public ProductoNoPerecederoException() : base("El producto no tiene fecha definida de muerte.") { }
    }
}
