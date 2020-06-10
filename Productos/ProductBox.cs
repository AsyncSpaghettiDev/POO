using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Productos {
    /// <summary>
    /// Despliegue de Datos en formatos
    /// </summary>
    class ProductBox:Form {
        /// <summary>
        /// Instanciar form personalizada para desplegar datos de producto.
        /// </summary>
        /// <param name="prod">Información del producto en forma de string.</param>
        public ProductBox(String prod) {
            // Lista con toda la información del producto a seleccionar.
            String[] datos=prod.Split('|');
            // Texto que tendrán las etiquetas.
            String[] names= new String[] { 
                "Codigo Departamento",
                "Departamento",
                "Codigo",
                "Descripcion",
                "Likes",
                "Fecha Lanzamiento",
                "Precio Lanzamiento",
                "Fecha Madurez",
                "Precio Madurez",
                "Fecha Merma",
                "Precio Merma",
                "Fecha Muerte",
                "Listo"
            };
            // Diseño de la form.
            Size = new Size(295, 350);
            ComponentResourceManager imgs = new ComponentResourceManager(typeof(Properties.Resources));
            Icon = imgs.GetObject("Prod") as Icon;
            Text = "Descripción Producto";

            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;

            StartPosition = FormStartPosition.CenterScreen;

            // Rellenar la lista de Controles con etiquetas y textBox.
            int j=0;
            int k=0;

            for (int i=0 ; i < 25 ;i++) {
                // En caso que el contador sea 24 se crea un botón que será el cerrará.
                if (i == 24) {
                    Controls.Add(new Button());
                    (Controls[i] as Button).Width = 50;
                    (Controls[i] as Button).Location = new Point(112, 275);
                    (Controls[i] as Button).Text = names[12];
                    (Controls[i] as Button).Click += ocultar;
                }
                // En caso de que el resultado del residuo de 1/2 sea 0 se creará una etiqueta y se le asignará el nombre de la lista names
                else if (i % 2 == 0) {
                    Controls.Add(new Label());
                    Controls[i].AutoSize = true;
                    Controls[i].Text = names[j];
                    j++;
                }
                // En caso que no sea ni 24 ni su modulo sea 0 se creará un textBox
                else {
                    Controls.Add(new TextBox());
                    (Controls[i] as TextBox).ReadOnly = true;
                    Controls[i].Text = datos[k];
                    k++;
                }
                // Para el primer control se le asignará la posicion de 25,10
                if (i == 0)
                    Controls[i].Location = new Point(25, 10);
                // Para todos aquellos en el que el contador sea menor de 12 estarán en la primer columna.
                else if (i < 12)
                    Controls[i].Location = new Point(Controls[i - 1].Location.X, Controls[i - 1].Location.Y + Controls[i - 1].Height + 5);
                // Los siguientes, menos el 24, estarán en la segunda columna.
                else if (i < 24)
                    Controls[i].Location = new Point(150, Controls[i - 12].Location.Y);
            }
        }
        /// <summary>
        /// Cierra la ventana actual para mostrar el menú de Consulta.
        /// </summary>
        void ocultar(object sender, EventArgs e) => Hide();
    }
}
