using System;
using System.Windows.Forms;

namespace Productos {
    partial class Inventario : Form {
        String path;
        public Inventario(String path) {
            Funciones.Diseno(this,400,300,"Control de Inventarios","ILogo");
            Load += inicia_Interfaz;
            this.path = path;
        }
        /// <summary>
        /// Desactiva a activa todos los objetos como botones o cajas de texto.
        /// </summary>
        /// <param name="decision">Activar o desactivar los controles</param>
        void desactiva_ActivaComponentes(bool decision) {
            foreach (Control ctr in Controls) 
                if (ctr is Label || ctr.Name == this.departamento.Name || ctr.Name == this.code.Name||ctr.Name==this.men.Name)
                    ctr.Enabled = true;
                else 
                    ctr.Enabled = decision;
        }
        void limpiar_Box() {
            foreach (Control bx in Controls)
                if(bx is TextBoxBase)
                    (bx as TextBoxBase).Clear();
        }
    }
}