using System.Windows.Forms;

namespace Productos {
    partial class Inventario : Form {
        public Inventario() {
            initializeComponent();
            Funciones.Diseno(this,400,300,"Control de Inventarios","ILogo");
            InventarioDB.Cargar_Listas(0);
        }
        /// <summary>
        /// Desactiva a activa todos los objetos como botones o cajas de texto.
        /// </summary>
        /// <param name="decision">Activar o desactivar los controles</param>
        void desactiva_ActivaComponentes(bool decision) {
            foreach (Control ctr in Controls)
                if (ctr is Label || ctr.Name == this.departamento.Name)
                    ctr.Enabled = true;
                else
                    ctr.Enabled = decision;
        }
    }
}