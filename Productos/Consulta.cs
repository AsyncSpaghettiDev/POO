using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Productos {
    class Consulta:Form {
        MaskedTextBox B_Fecha,B_Departamento,B_Code;
        ListBox resultado;
        public Consulta() {
            iniciaComponentes();
        }
        void iniciaComponentes() {
            Funciones.Diseno(this, 420, 360, "Consulta de Inventario", "CLogo");

        }
    }
}
