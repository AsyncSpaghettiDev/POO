using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Productos {
    partial class Consulta {
        /// <summary>
        /// TextBox para ingresar información de consulta.
        /// </summary>
        MaskedTextBox B_Fecha,B_Departamento,B_Code;
        /// <summary>
        /// Botón para cambio de tipo de busqueda.
        /// </summary>
        RadioButton S_Fecha,S_Departamento,S_Code;
        /// <summary>
        /// Pantalla donde se despliegan los datos.
        /// </summary>
        ListBox resultado;
        /// <summary>
        /// Boton de vuelta al menu.
        /// </summary>
        Button menu;
        /// <summary>
        /// Boton que ejecuta la consulta
        /// </summary>
        Button buscar;
        /// <summary>
        /// Despliega correctamente todos los controles en la ventana.
        /// </summary>
        void iniciaComponentes() {
            //Diseño de la ventana
            Funciones.Diseno(this, 420, 360, "Consulta de Inventario", "CLogo");

            //Seleccionar busqueda por fecha
            this.S_Fecha = new RadioButton();
            this.S_Fecha.Text = "Busqueda por\nFecha";
            this.S_Fecha.AutoSize = true;
            this.S_Fecha.Location = new Point(30, 10);
            Controls.Add(this.S_Fecha);

            //Buscar por fecha
            this.B_Fecha = new MaskedTextBox();
            this.B_Fecha.Enabled = false;
            this.B_Fecha.Mask = "00/00/0000";
            this.B_Fecha.Size = new Size(65, this.B_Fecha.Size.Height);
            this.B_Fecha.Location = new Point(this.S_Fecha.Location.X + (this.S_Fecha.Size.Width / 4), this.S_Fecha.Location.Y + this.S_Fecha.Size.Height + 10);
            this.B_Fecha.ValidatingType = typeof(DateTime);
            Controls.Add(this.B_Fecha);
            this.B_Fecha.TypeValidationCompleted += Funciones.Error;

            //Seleccionar busqueda por Departamento
            this.S_Departamento = new RadioButton();
            this.S_Departamento.Text = "Busqueda por\nDepartamento";
            this.S_Departamento.AutoSize = true;
            this.S_Departamento.Location = new Point(this.S_Fecha.Location.X + this.S_Fecha.Size.Width + 31, this.S_Fecha.Location.Y);
            Controls.Add(this.S_Departamento);

            //Buscar por Departamento
            this.B_Departamento = new MaskedTextBox();
            this.B_Departamento.Enabled = false;
            this.B_Departamento.Mask = ">L-0\\0\\0";
            this.B_Departamento.Size = new Size(40, this.B_Departamento.Size.Height);
            this.B_Departamento.Location = new Point(this.S_Departamento.Location.X + (this.S_Departamento.Size.Width / 4), this.S_Departamento.Location.Y + this.S_Departamento.Size.Height + 10);
            Controls.Add(this.B_Departamento);

            //Seleccionar busqueda por Code
            this.S_Code = new RadioButton();
            this.S_Code.Text = "Busqueda por\nCódigo";
            this.S_Code.AutoSize = true;
            this.S_Code.Location = new Point(this.S_Departamento.Location.X + this.S_Departamento.Size.Width + 31, this.S_Departamento.Location.Y);
            Controls.Add(this.S_Code);

            //Buscar por Code
            this.B_Code = new MaskedTextBox();
            this.B_Code.Enabled = false;
            this.B_Code.Mask = ">LLL-000";
            this.B_Code.Size = new Size(50, this.B_Code.Size.Height);
            this.B_Code.Location = new Point(this.S_Code.Location.X + (this.S_Code.Size.Width / 4), this.S_Code.Location.Y + this.S_Code.Size.Height + 10);
            Controls.Add(this.B_Code);

            //Lista de Resultados.
            this.resultado = new ListBox();
            this.resultado.Location = new Point(this.B_Fecha.Location.X, this.B_Fecha.Location.Y + this.B_Fecha.Size.Height + 10);
            this.resultado.Size = new Size(this.B_Code.Location.X + this.B_Code.Size.Width - this.B_Fecha.Location.X, 200);
            Controls.Add(this.resultado);

            //Boton ejecuta busqueda
            this.buscar = new Button();
            this.buscar.Location = new Point(this.resultado.Location.X-15, this.resultado.Size.Height + this.resultado.Location.Y + 5);
            this.buscar.Text = "Buscar";
            Controls.Add(this.buscar);
            this.buscar.Click += busqueda;

            //Boton Vuelta al menu
            this.menu = new Button();
            this.menu.Text = "Volver al menu";
            this.menu.AutoSize = true;
            this.menu.Location = new Point(this.resultado.Location.X+this.resultado.Size.Width-this.buscar.Size.Width, this.buscar.Location.Y);
            Controls.Add(this.menu);
            this.menu.Click += Funciones.Regresa;

            //Agregar eventos a RadioButtons
            foreach (Control ctr in Controls)
                if (ctr is RadioButton)
                    (ctr as RadioButton).Click += cambiar_Seleccion;
        }
    }
}
