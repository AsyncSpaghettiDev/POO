using System;
using System.Windows.Forms;

namespace Productos {
    class InvalidDepartamentException : Exception {
        public InvalidDepartamentException() : base("Departamento Inválido revisa la tabla de Departamentos") { }
    }
    class TooMuchCharactersException : Exception {

        public TooMuchCharactersException(Control origen,int limite) : 
            base(String.Format("Demasiados caracteres ingresados en {0}\nCantidad máxima de caracteres: {1} ",origen.Name,limite)) { }
    }
}
