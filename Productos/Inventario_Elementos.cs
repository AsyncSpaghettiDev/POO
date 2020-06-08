using System;
using System.Drawing;
using System.Windows.Forms;

namespace Productos {
    partial class Inventario {
        Label horaLocal,_departamento,_code,_descripcion,_likes,_precio,_fecha;
        MaskedTextBox departamento,code,fecha;
        TextBoxBase likes,precio,descripcion;
        Button agrega,actualiza,men;
        RadioButton decide,decide2;
        void initializeComponent() {
            this.HelpButton = true;
            HelpButtonClicked +=ayuda;

            //Etiqueta seleccion
            this.horaLocal = new Label();
            this.horaLocal.AutoSize = true;
            this.horaLocal.Text = "¿Usar la hora local?";
            this.horaLocal.Location = new Point(10, 20);
            Controls.Add(this.horaLocal);

            //Label Departamento
            this._departamento = new Label();
            this._departamento.AutoSize = true;
            this._departamento.Text = "Departamento";
            this._departamento.Location = new Point(10, 50);
            Controls.Add(this._departamento);

            //Textbox Departamento
            this.departamento = new MaskedTextBox();
            this.departamento.Mask = ">L-#\\0\\0";
            this.departamento.BeepOnError = true;
            this.departamento.Name = "la Caja de Texto de Departamento";
            this.departamento.Size = new Size(50, this.departamento.Size.Height);
            this.departamento.Location = new Point(this._departamento.Location.X+4, this._departamento.Location.Y + this._departamento.Size.Height + 10);
            Controls.Add(this.departamento);
            this.departamento.Validating += comprueba;

            //Label Codigo
            this._code = new Label();
            this._code.AutoSize = true;
            this._code.Text = "Codigo";
            this._code.Location = new Point(this._departamento.Location.X+this._departamento.Size.Width+10, this._departamento.Location.Y);
            Controls.Add(this._code);

            //Textbox Codigo
            this.code = new MaskedTextBox();
            this.code.Mask = ">LLL-###";
            this.code.BeepOnError = true;
            this.code.Name = "la Caja de Texto de Codigo";
            this.code.Size = new Size(50, this.code.Size.Height);
            this.code.Location = new Point(this._code.Location.X+4, this._code.Location.Y + this._code.Size.Height + 10);
            Controls.Add(this.code);
            this.code.KeyPress += cambiar;

            //Label Likes
            this._likes = new Label();
            this._likes.AutoSize = true;
            this._likes.Text = "Valoración";
            this._likes.Location = new Point(this.code.Location.X+this.code.Size.Width+15,this._code.Location.Y);
            Controls.Add(this._likes);

            //TextBox Likes
            this.likes = new TextBox();
            this.likes.Name = "la Caja de Texto de Likes";
            this.likes.Size = this.departamento.Size;
            this.likes.Location = new Point(this._likes.Location.X+4, this._likes.Location.Y + this._likes.Size.Height + 10);
            Controls.Add(this.likes);
            this.likes.Validating += comprueba;

            //Label Descripcion
            this._descripcion = new Label();
            this._descripcion.AutoSize = true;
            this._descripcion.Text = "Descripcion del producto";
            this._descripcion.Location = new Point(this.departamento.Location.X, this.departamento.Location.Y + this.departamento.Size.Height+10);
            Controls.Add(this._descripcion);

            //RichTextBox Descripcion
            this.descripcion = new RichTextBox();
            this.descripcion.Name = "la caja de Texto de Descripcion";
            this.descripcion.Size = new Size(this._likes.Location.X + this._likes.Size.Width - this.departamento.Location.X,this.descripcion.Size.Height/2);
            this.descripcion.Location = new Point(this._descripcion.Location.X, this._descripcion.Location.Y + this._descripcion.Size.Height + 10);
            Controls.Add(this.descripcion);
            this.descripcion.Validating += comprueba;

            //Label de precioInicial
            this._precio = new Label();
            this._precio.AutoSize = true;
            this._precio.Text = "Precio de\nlanzamiento";
            this._precio.Location = new Point(this.descripcion.Location.X, this.descripcion.Location.Y + this.descripcion.Size.Height + 10);
            Controls.Add(this._precio);

            //Texbox de precioInicial
            this.precio = new TextBox();
            this.precio.Name = "la caja de Texto de Precio de Lanzamiento";
            this.precio.Size = this.likes.Size;
            this.precio.Location = new Point(this._precio.Location.X + 4, this._precio.Location.Y + this._precio.Size.Height + 10);
            Controls.Add(this.precio);
            this.precio.Validating += comprueba;

            //Label Fecha
            this._fecha = new Label();
            this._fecha.AutoSize = true;
            this._fecha.Text = "Fecha de lanzamiento";
            this._fecha.Location = new Point(this._precio.Location.X + this._precio.Size.Width + 10, this._precio.Location.Y+(this._precio.Size.Height/2));
            Controls.Add(this._fecha);

            //Texbox Fecha
            this.fecha = new MaskedTextBox();
            this.fecha.Size = new Size(65, this.fecha.Size.Height);
            this.fecha.Mask = "00/00/0000";
            this.fecha.BeepOnError = true;
            this.fecha.Name = "la caja de Texto de Fecha de Lanzamiento";
            this.fecha.Location = new Point(this._fecha.Location.X + 4, this._fecha.Location.Y + this._fecha.Size.Height + 10);
            Controls.Add(this.fecha);
            this.fecha.ValidatingType = typeof(DateTime);
            this.fecha.TypeValidationCompleted += error;

            //Boton para agregar un nuevo producto
            this.agrega = new Button();
            this.agrega.Text = "Agregar producto";
            this.agrega.Location = new Point(250, 80);
            this.agrega.AutoSize = true;
            this.agrega.Click += agregar;
            Controls.Add(this.agrega);

            //Boton para actualizar los datos del producto
            this.actualiza = new Button();
            this.actualiza.Text = "Actualiza producto";
            this.actualiza.Location = new Point(this.agrega.Location.X, this.agrega.Location.Y + this.agrega.Size.Height + 20);
            this.actualiza.AutoSize = true;
            this.actualiza.Click +=actualizar;
            Controls.Add(this.actualiza);

            //Boton vuelta al menú principal
            this.men = new Button();
            this.men.Text = "Volver al\nmenu principal.";
            this.men.Name = this.men.Text;
            this.men.Location = new Point(this.actualiza.Location.X, this.actualiza.Location.Y + this.actualiza.Height + 20);
            this.men.AutoSize = true;
            this.men.Width = this.actualiza.Width;
            this.men.Click += regresa;
            Controls.Add(this.men);

            //RadioBoton aceptar
            this.decide = new RadioButton();
            this.decide.AutoSize = true;
            this.decide.Text = "Si";
            this.decide.Location = new Point(this.horaLocal.Location.X+this.horaLocal.Size.Width+10, this.horaLocal.Location.Y-1);
            Controls.Add(this.decide);
            this.decide.CheckedChanged += activado_Decide;

            //RadioBoton cancelar
            this.decide2 = new RadioButton();
            this.decide2.AutoSize = true;
            this.decide2.Checked = true;
            this.decide2.Text = "No";
            this.decide2.Location = new Point(this.decide.Location.X+this.decide.Size.Width+10, this.decide.Location.Y);
            Controls.Add(this.decide2);
            this.decide2.CheckedChanged += activado_Decide;

            desactiva_ActivaComponentes(false);
        }
    }
}
