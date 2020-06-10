using System;
using System.Drawing;
using System.Windows.Forms;

namespace Productos {
    partial class Pantalla_Inicial {
        /// <summary>
        /// Evento que redirecciona a un módulo
        /// </summary>
        /// <exception cref="ResultadoNuloException"></exception>
        void entrar(object sender, EventArgs e) {
            try {
                // En caso que las listas internas estén vacias se arroja una excepción 
                if (InventarioDB.inventario.Count < 1||InventarioDB.departamentos.Count<1)
                    throw new ResultadoNuloException();
                // Se redirecciona a la Pantalla correspondiente y se cierra la actual.
                if ((sender as Control).Name == this.img_consulta.Name) 
                    new Consulta().Show();
                else if ((sender as Control).Name == this.img_registro.Name)
                    new Inventario(this.p_Inv.Text).Show();
                Hide();
            }
            catch (ResultadoNuloException) {
                MessageBox.Show("Cargue una lista válida o presione botón de cargar lista");
            }
        }
        /// <summary>
        /// Evento que al entrar el mouse aumenta el tamaño de la imagen simulando un Zoom
        /// </summary>
        void aumenta(object sender, EventArgs e) {
            (sender as PictureBox).Size = new Size((sender as PictureBox).Width + 50, (sender as PictureBox).Height + 50);
            (sender as PictureBox).Location = new Point((sender as Control).Location.X - 25, (sender as Control).Location.Y - 25);
            // Para evitar sobreponerse sobre otros controles se manda al fondo.
            (sender as Control).SendToBack();
        }
        /// <summary>
        /// Evento que al salir el mouse disminuye el tamaño de la imagen simulando el quitar el Zoom.
        /// </summary>
        void disminuye(object sender, EventArgs e) {
            (sender as PictureBox).Size = new Size((sender as PictureBox).Width - 50, (sender as PictureBox).Height - 50);
            (sender as PictureBox).Location = new Point((sender as Control).Location.X + 25, (sender as Control).Location.Y + 25);
        }
        /// <summary>
        /// Evento que ejecuta cierta accion dependiendo del boton pulsado.
        /// </summary>
        void accionar(object sender, EventArgs e) {
            if ((sender as Control).Name == this.c_Dep.Name)
                InventarioDB.DeployFD(0);
            if ((sender as Control).Name == this.c_Inv.Name)
                InventarioDB.DeployFD(1);
            if ((sender as Control).Name == this.carga_L.Name)
                cargaList();
        }
    }
}
