using System.Windows.Forms;

namespace Productos {
    partial class Inventario : Form {
        public Inventario() {
            initializeComponent();
            Funciones.Diseno(this,500,500,"Control de Inventarios","ILogo");
        }
        /// <summary>
        /// Desactiva a activa todos los objetos como botones o cajas de texto.
        /// </summary>
        /// <param name="decision">Activar o desactivar los controles</param>
        void desactiva_ActivaComponentes(bool decision) {
            foreach (Control bot in Controls)
                if (bot is Button)
                    bot.Enabled = decision;
        }
    }
}