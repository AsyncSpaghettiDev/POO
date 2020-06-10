using System;
using System.Windows.Forms;

namespace Productos {
    /// <summary>
    /// Agregacion o actualizacion de Productos.
    /// </summary>
    partial class Inventario : Form {
        /// <summary>
        /// Ubicación de la DB Inventarios.
        /// </summary>
        readonly String path;
        public Inventario(String path) {
            Funciones.Diseno(this,400,300,"Control de Inventarios","ILogo");
            initializeComponent();
            this.path = path;
        }
        /// <summary>
        /// Desactiva a activa todos los objetos como botones o cajas de texto.
        /// </summary>
        /// <param name="decision">Activar o desactivar los controles</param>
        void desactiva_ActivaComponentes(bool decision) {
            foreach (Control ctr in Controls) 
                if (ctr is Label || 
                    ctr.Name == this.departamento.Name || 
                    ctr.Name == this.code.Name||
                    ctr.Name==this.men.Name)
                    ctr.Enabled = true;
                else 
                    ctr.Enabled = decision;
        }
        /// <summary>
        /// Limpia todas las textBox dentro de la ventana.
        /// Además desactiva todos los demás controles.
        /// </summary>
        void limpiar_Box() {
            foreach (Control bx in Controls)
                if(bx is TextBoxBase)
                    (bx as TextBoxBase).Clear();
            desactiva_ActivaComponentes(false);
        }
    }
}