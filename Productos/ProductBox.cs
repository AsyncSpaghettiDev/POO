using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Productos {
    class ProductBox:Form {
        readonly Label CodigoDepartamento,Departamento,Codigo,Descripcion,Likes,FechaLanzamiento,PrecioLanzamiento,FechaMadurez,PrecioMadurez,FechaMerma,PrecioMerma,FechaMuerte;
        readonly TextBox _CodigoDepartamento,_Departamento,_Codigo,_Descripcion,_Likes,_FechaLanzamiento,_PrecioLanzamiento,_FechaMadurez,_PrecioMadurez,_FechaMerma,_PrecioMerma,_FechaMuerte;
        readonly Button cerrar;
        public ProductBox(String prod) {
            String[] datos=prod.Split('|');
            String[] names= new String[] { 
                "CodigoDepartamento",
                "Departamento",
                "Codigo",
                "Descripcion",
                "Likes",
                "FechaLanzamiento",
                "PrecioLanzamiento",
                "FechaMadurez",
                "PrecioMadurez",
                "FechaMerma",
                "PrecioMerma",
                "FechaMuerte" 
            };
            diseno(270, 350, "Descripción Producto", "Prod");

            this.CodigoDepartamento=  new Label();
            this.CodigoDepartamento.Name = "ctr1";
            Controls.Add(this.CodigoDepartamento);

            this._CodigoDepartamento = new TextBox();
            Controls.Add(this._CodigoDepartamento);

            this.Departamento= new Label();
            Controls.Add(this.Departamento);

            this._Departamento = new TextBox();
            Controls.Add(this._Departamento);

            this.Codigo= new Label();
            Controls.Add(this.Codigo);

            this._Codigo = new TextBox();
            Controls.Add(this._Codigo);

            this.Descripcion= new Label();
            Controls.Add(this.Descripcion);

            this._Descripcion = new TextBox();
            Controls.Add(this._Descripcion);

            this.Likes= new Label();
            Controls.Add(this.Likes);

            this._Likes = new TextBox();
            Controls.Add(this._Likes);

            this.FechaLanzamiento= new Label();
            Controls.Add(this.FechaLanzamiento);

            this._FechaLanzamiento = new TextBox();
            Controls.Add(this._FechaLanzamiento);

            this.PrecioLanzamiento= new Label();
            Controls.Add(this.PrecioLanzamiento);

            this._PrecioLanzamiento = new TextBox();
            Controls.Add(this._PrecioLanzamiento);

            this.FechaMadurez= new Label();
            Controls.Add(this.FechaMadurez);

            this._FechaMadurez = new TextBox();
            Controls.Add(this._FechaMadurez);

            this.PrecioMadurez= new Label();
            Controls.Add(this.PrecioMadurez);

            this._PrecioMadurez = new TextBox();
            Controls.Add(this._PrecioMadurez);

            this.FechaMerma= new Label();
            Controls.Add(this.FechaMerma);

            this._FechaMerma = new TextBox();
            Controls.Add(this._FechaMerma);

            this.PrecioMerma= new Label();
            Controls.Add(this.PrecioMerma);

            this._PrecioMerma = new TextBox();
            Controls.Add(this._PrecioMerma);

            this.FechaMuerte= new Label();
            Controls.Add(this.FechaMuerte);

            this._FechaMuerte = new TextBox();
            Controls.Add(this._FechaMuerte);

            int i=0;
            int j=0;
            int k=0;
            foreach(Control ctr in Controls) {

                if (ctr is TextBox) {
                    (ctr as TextBox).ReadOnly = true;
                    ctr.Text = datos[i];
                    i++;
                }
                if(ctr is Label) {
                    (ctr as Label).AutoSize = true;
                    ctr.Text = names[j];
                    j++;
                }
                if (ctr.Name == this.CodigoDepartamento.Name)
                    ctr.Location = new Point(10, 10);
                else if(k<12)
                    ctr.Location = new Point(10, Controls[k - 1].Location.Y + Controls[k - 1].Height + 5);
                else
                    ctr.Location = new Point(125, Controls[k -12 ].Location.Y);
                k++;
            }

            this.cerrar = new Button();
            this.cerrar.Location = new Point((Size.Width / 2) - (this.cerrar.Width / 2), this._FechaMuerte.Location.Y + this._FechaMuerte.Height + 10);
            this.cerrar.Text = "Listo";
            Controls.Add(this.cerrar);
            this.cerrar.Click += ocultar;
        }
        void ocultar(object sender, EventArgs e) => Hide();
        void diseno(int x, int y, String Titulo, String nombre) {
            Size = new Size(x, y);
            ComponentResourceManager imgs = new ComponentResourceManager(typeof(Properties.Resources));
            Icon = imgs.GetObject(nombre) as Icon;
            Text = Titulo;

            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;

            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
