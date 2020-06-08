using System;
using System.Drawing;
using System.Windows.Forms;

namespace Productos {
    partial class Pantalla_Inicial {
        void entrar(object sender, EventArgs e) {
            try {

                if ((sender as Control).Name == this.img_consulta.Name)
                    if (InventarioDB.inventario.Count < 1)
                        throw new ResultadoNuloException();
                    else
                        new Consulta().Show();
                else if ((sender as Control).Name == this.img_registro.Name)
                    new Inventario(this.p_Inv.Text).Show();
                Hide();
            }
            catch (ResultadoNuloException) {
                MessageBox.Show("Cargue una lista válida o presione botón de cargar lista");
            }
        }
        void aumenta(object sender, EventArgs e) {
            (sender as PictureBox).Size = new Size((sender as PictureBox).Width + 50, (sender as PictureBox).Height + 50);
            (sender as PictureBox).Location = new Point((sender as Control).Location.X - 25, (sender as Control).Location.Y - 25);
            (sender as Control).SendToBack();
        }
        void disminuye(object sender, EventArgs e) {
            (sender as PictureBox).Size = new Size((sender as PictureBox).Width - 50, (sender as PictureBox).Height - 50);

            (sender as PictureBox).Location = new Point((sender as Control).Location.X + 25, (sender as Control).Location.Y + 25);
        }
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
