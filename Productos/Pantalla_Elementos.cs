using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Productos {
    partial class Pantalla_Inicial {
        /// <summary>
        /// Imagen para redireccionar.
        /// </summary>
        PictureBox img_registro,img_consulta;
        /// <summary>
        /// TextBox con un path.
        /// </summary>
        TextBox p_Inv,p_Dep;
        /// <summary>
        /// Boton de carga o seleccion de path.
        /// </summary>
        Button c_Inv,c_Dep,carga_L;
        void iniciaComponentes() {
            //PictureBox rederecciona registro
            this.img_registro = new PictureBox();
            this.img_registro.Name = "LRegistro";
            this.img_registro.Image= Properties.Resources.Regi;
            this.img_registro.SizeMode = PictureBoxSizeMode.Zoom;
            this.img_registro.Size = new Size(250, 250);
            this.img_registro.Cursor = Cursors.Hand;
            this.img_registro.Location = new Point(20, -20);
            Controls.Add(this.img_registro);

            //PictureBox rederecciona registro
            this.img_consulta = new PictureBox();
            this.img_consulta.Name = "LConsulta";
            this.img_consulta.Image = Properties.Resources.Consul;
            this.img_consulta.SizeMode = PictureBoxSizeMode.Zoom;
            this.img_consulta.Size = new Size(250, 250);
            this.img_consulta.Cursor = Cursors.Hand;
            this.img_consulta.Location = 
                new Point(this.img_registro.Location.X+this.img_registro.Width+20, -20);
            Controls.Add(this.img_consulta);

            //TextBox con path de Departamentos
            this.p_Dep = new TextBox();
            this.p_Dep.Width = 400;
            this.p_Dep.Enabled = false;
            this.p_Dep.Text = Path.GetFullPath("./Departamentos.txt");
            this.p_Dep.BringToFront();
            this.p_Dep.Location = 
                new Point(this.img_registro.Location.X+20, this.img_registro.Location.Y + this.img_registro.Height + 40);
            Controls.Add(this.p_Dep);

            //Boton para cambiar el archivo de departamentos
            this.c_Dep = new Button();
            this.c_Dep.Text = "...";
            this.c_Dep.Width = 30;
            this.c_Dep.Name = "boton departamentos";
            this.c_Dep.Location = new Point(this.p_Dep.Location.X + this.p_Dep.Width + 5, this.p_Dep.Location.Y);
            Controls.Add(this.c_Dep);

            //TextBox con path de Inventario
            this.p_Inv = new TextBox();
            this.p_Inv.Width = 400;
            this.p_Inv.Enabled = false;
            this.p_Inv.Text = Path.GetFullPath("./Inventario.txt");
            this.p_Inv.BringToFront();
            this.p_Inv.Location =
                new Point(this.p_Dep.Location.X,this.p_Dep.Location.Y+this.p_Dep.Height+5);
            Controls.Add(this.p_Inv);

            //Boton para cambiar el archivo de Inventario
            this.c_Inv = new Button();
            this.c_Inv.Text = "...";
            this.c_Inv.Width = 30;
            this.c_Inv.Name = "boton inventario";
            this.c_Inv.Location = new Point(this.p_Inv.Location.X + this.p_Inv.Width + 5, this.p_Inv.Location.Y);
            Controls.Add(this.c_Inv);

            //Boton cargar nuevas listas
            this.carga_L = new Button();
            this.carga_L.Text = "Cargar\nListas";
            this.carga_L.Location = new Point(this.c_Dep.Location.X + this.c_Dep.Width + 5, this.c_Dep.Location.Y);
            this.carga_L.Height = this.c_Inv.Location.Y - this.p_Dep.Location.Y + this.c_Inv.Height;
            this.carga_L.Width = this.carga_L.Height;
            this.carga_L.Name = "Cargar listas";
            Controls.Add(this.carga_L);

            /*
             * A los controles PictureBox se le agregan los eventos mouse enter, mouse leave, y click
             * A los botones se les añade el evento click.
             */
            foreach (Control ctr in Controls)
                if (ctr is PictureBox) {
                    ctr.Click += entrar;
                    (ctr as PictureBox).MouseEnter += aumenta;
                    (ctr as PictureBox).MouseLeave += disminuye;
                }
                else if (ctr is Button)
                    (ctr as ButtonBase).Click += accionar;
        }
    }
}
