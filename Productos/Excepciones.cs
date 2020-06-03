using System;
using System.Windows.Forms;

namespace Productos {
    class InvalidDepartamentException : Exception {
        public InvalidDepartamentException() : base("Departamento Inválido revisa la tabla de Departamentos") { }
    }
}
