using System;
using System.Drawing;
using System.Windows.Forms;

namespace Productos {
    partial class Inventario {
        Label horaLocal,_departamento,_code,_descripcion,_likes,_precio,_fecha;
        MaskedTextBox departamento,code,fecha;
        TextBoxBase likes,precio,descripcion;
        Button agrega,actualiza;
        RadioButton decide,decide2;
        void initializeComponent() {
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
            this.departamento.Mask = "A-###";
            this.departamento.BeepOnError = true;
            this.departamento.Name = "la Caja de Texto de Departamento";
            this.departamento.Size = new Size(50, this.departamento.Size.Height);
            this.departamento.Location = new Point(this._departamento.Location.X+4, this._departamento.Location.Y + this._departamento.Size.Height + 10);
            Controls.Add(this.departamento);
            this.departamento.KeyUp += (sender, e) => limiteChar(sender,e,5,true);
            this.departamento.LostFocus += salida_Foco;

            //Label Codigo
            this._code = new Label();
            this._code.AutoSize = true;
            this._code.Text = "Codigo";
            this._code.Location = new Point(this._departamento.Location.X+this._departamento.Size.Width+10, this._departamento.Location.Y);
            Controls.Add(this._code);

            //Textbox Codigo
            this.code = new MaskedTextBox();
            this.code.Mask = "AAA-###";
            this.code.BeepOnError = true;
            this.code.Name = "la Caja de Texto de Codigo";
            this.code.Size = new Size(50, this.code.Size.Height);
            this.code.Location = new Point(this._code.Location.X+4, this._code.Location.Y + this._code.Size.Height + 10);
            Controls.Add(this.code);
            this.code.KeyUp += (sender, e) => limiteChar(sender, e, 7,true);
            this.code.LostFocus += salida_Foco;

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
            this.likes.KeyUp += (sender, e) => limiteChar(sender, e, 100);

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
            this.descripcion.KeyUp += (sender, e) => limiteChar(sender, e, 50,false);
            this.LostFocus += salida_Foco;

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
            this.precio.CausesValidation = true;
            this.precio.Validating += comprueba;
            //this.precio.KeyUp+= (sender, e) => limiteChar(sender, e, 1000);

            //Label Fecha
            this._fecha = new Label();
            this._fecha.AutoSize = true;
            this._fecha.Text = "Fecha de lanzamiento";
            this._fecha.Location = new Point(this._precio.Location.X + this._precio.Size.Width + 10, this._precio.Location.Y+(this._precio.Size.Height/2));
            Controls.Add(this._fecha);

            //Texbox Fecha
            this.fecha = new MaskedTextBox();
            this.fecha.Mask = "##/##/####";
            this.fecha.BeepOnError = true;
            this.fecha.Name = "la caja de Texto de Precio de Lanzamiento";
            this.fecha.Location = new Point(this._fecha.Location.X + 4, this._fecha.Location.Y + this._fecha.Size.Height + 10);
            Controls.Add(this.fecha);
            this.fecha.ValidatingType = typeof(DateTime);
            this.fecha.TypeValidationCompleted += error;

            //Boton para agregar un nuevo producto
            this.agrega = new Button();
            this.agrega.Text = "Agregar producto";
            this.agrega.Location = new Point(350, 150);
            this.agrega.AutoSize = true;
            this.agrega.Click += new EventHandler(gen_NP);
            Controls.Add(this.agrega);

            //Boton para actualizar los datos del producto
            this.actualiza = new Button();
            this.actualiza.Text = "Actualiza producto";
            this.actualiza.Location = new Point(this.agrega.Location.X, this.agrega.Location.Y + this.agrega.Size.Height + 20);
            this.actualiza.AutoSize = true;
            this.actualiza.Click +=gen_P;
            Controls.Add(this.actualiza);

            //Boton aceptar
            this.decide = new RadioButton();
            this.decide.AutoSize = true;
            this.decide.Text = "Si";
            this.decide.Location = new Point(this.horaLocal.Location.X+this.horaLocal.Size.Width+10, this.horaLocal.Location.Y-1);
            Controls.Add(this.decide);
            this.decide.CheckedChanged += new EventHandler(activado_Decide);

            //Boton cancelar
            this.decide2 = new RadioButton();
            this.decide2.AutoSize = true;
            this.decide2.Checked = true;
            this.decide2.Text = "No";
            this.decide2.Location = new Point(this.decide.Location.X+this.decide.Size.Width+10, this.decide.Location.Y);
            Controls.Add(this.decide2);
            this.decide2.CheckedChanged += new EventHandler(activado_Decide);
        }
    }
}
