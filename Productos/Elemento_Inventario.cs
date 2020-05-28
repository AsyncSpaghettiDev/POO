using System.Drawing;
using System.Windows.Forms;

namespace Productos {
    partial class Inventario {
        Button agrega,actualiza;
        void initializeComponent() {
            //Boton para agregar un nuevo producto
            this.agrega = new Button();
            this.agrega.Text = "Agregar producto";
            this.agrega.Location = new Point(350, 150);
            this.agrega.AutoSize = true;
            Controls.Add(this.agrega);

            //Boton para actualizar los datos del producto
            this.actualiza = new Button();
            this.actualiza.Text = "Actualiza producto";
            this.actualiza.Location = new Point(this.agrega.Location.X, this.agrega.Location.Y+this.agrega.Size.Height+20);
            this.actualiza.AutoSize = true;
            Controls.Add(this.actualiza);
        }
    }
}
