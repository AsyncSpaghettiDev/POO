using System.Drawing;
using System.Windows.Forms;

namespace Productos {
    class Consulta:Form {
        MaskedTextBox B_Fecha,B_Departamento,B_Code;
        RadioButton S_Fecha,S_Departamento,S_Code;
        ListBox resultado;
        public Consulta() {
            iniciaComponentes();
        }
        void iniciaComponentes() {
            Funciones.Diseno(this, 420, 360, "Consulta de Inventario", "CLogo");
            //Seleccionar busqueda por fecha
            this.S_Fecha = new RadioButton();
            this.S_Fecha.Text = "Busqueda por\nFecha";
            this.S_Fecha.AutoSize = true;
            this.S_Fecha.Location = new Point(10, 10);
            Controls.Add(this.S_Fecha);

            //Buscar por fecha
            this.B_Fecha = new MaskedTextBox();
            this.B_Fecha.Enabled = false;
            this.B_Fecha.Mask= "00/00/0000";
            this.B_Fecha.Size = new Size(65, this.B_Fecha.Size.Height);
            this.B_Fecha.Location = new Point(this.S_Fecha.Location.X + (this.S_Fecha.Size.Width/4), this.S_Fecha.Location.Y + this.S_Fecha.Size.Height + 10);
            Controls.Add(this.B_Fecha);

            //Seleccionar busqueda por Departamento
            this.S_Departamento = new RadioButton();
            this.S_Departamento.Text = "Busqueda por\nDepartamento";
            this.S_Departamento.AutoSize = true;
            this.S_Departamento.Location = new Point(this.S_Fecha.Location.X+this.S_Fecha.Size.Width+10, this.S_Fecha.Location.Y);
            Controls.Add(this.S_Departamento);

            //Buscar por Departamento
            this.B_Departamento = new MaskedTextBox();
            this.B_Departamento.Enabled = false;
            this.B_Departamento.Mask = "L-0\\0\\0";
            this.B_Departamento.Size = new Size(65, this.B_Departamento.Size.Height);
            this.B_Departamento.Location = new Point(this.S_Departamento.Location.X + (this.S_Departamento.Size.Width/4), this.S_Departamento.Location.Y + this.S_Departamento.Size.Height + 10);
            Controls.Add(this.B_Departamento);

            //Seleccionar busqueda por Code
            this.S_Code = new RadioButton();
            this.S_Code.Text = "Busqueda por\nC";
            this.S_Code.AutoSize = true;
            this.S_Code.Location = new Point(this.S_Departamento.Location.X + this.S_Departamento.Size.Width + 10, this.S_Departamento.Location.Y);
            Controls.Add(this.S_Code);

            //Buscar por Code
            this.B_Code = new MaskedTextBox();
            this.B_Code.Enabled = false;
            this.B_Code.Mask = "LLL-000";
            this.B_Code.Size = new Size(65, this.B_Code.Size.Height);
            this.B_Code.Location = new Point(this.S_Code.Location.X + (this.S_Code.Size.Width / 4), this.S_Code.Location.Y + this.S_Code.Size.Height + 10);
            Controls.Add(this.B_Code);
        }
    }
}
