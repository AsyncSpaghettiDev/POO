using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Productos {
    partial class Consulta {
        /// <summary>
        /// Evento que activa cierto textBox de acorde al boton pulsado.
        /// </summary>
        void cambiar_Seleccion(object sender,EventArgs e) {
            if (this.S_Fecha.Checked)
                focus(0);
            if (this.S_Departamento.Checked)
                focus(1);
            if (this.S_Code.Checked)
                focus(2);
        }
        /// <summary>
        /// Activa y centra cierto control de acorde al número al número de este.
        /// Desactiva todos los demás controles.
        /// </summary>
        /// <param name="Casilla">Valor de 0-2 que indica el control de izq a derecha.</param>
        void focus(int Casilla) {
            switch (Casilla) {
                case 0:
                    this.B_Fecha.Enabled = true;
                    this.B_Fecha.Focus();
                    this.B_Departamento.Enabled = false;
                    this.B_Departamento.Clear();
                    this.B_Code.Enabled = false;
                    this.B_Code.Clear();
                    break;
                case 1:
                    this.B_Fecha.Enabled = false;
                    this.B_Fecha.Clear();
                    this.B_Departamento.Enabled = true;
                    this.B_Departamento.Focus();
                    this.B_Code.Enabled = false;
                    this.B_Code.Clear();
                    break;
                case 2:
                    this.B_Fecha.Enabled = false;
                    this.B_Fecha.Clear();
                    this.B_Departamento.Enabled = false;
                    this.B_Departamento.Clear();
                    this.B_Code.Enabled = true;
                    this.B_Code.Focus();
                    break;
            }
        }
        /// <summary>
        /// Ejecuta la consulta en la DB de acorde al botón seleccionado.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ResultadoNuloException"></exception>
        void busqueda(object sender, EventArgs e) {
            try {
                this.resultado.Items.Clear();
                List<Producto> resul=null;

                if (this.S_Fecha.Checked) {
                    int [] fecha=Array.ConvertAll(this.B_Fecha.Text.Split('/'),int.Parse);
                    InventarioDB.Consulta(new DateTime(fecha[2], fecha[1], fecha[0]),out resul);
                }
                if (this.S_Departamento.Checked)
                    InventarioDB.Consulta(this.B_Departamento.Text, out resul);
                if (this.S_Code.Checked)
                    InventarioDB.Consulta(this.B_Code.Text, out resul);

                this.resultado.Click += mostrar;
                foreach (Producto prod in resul) 
                    this.resultado.Items.Add(prod.ToString().Replace('_',' '));
            }
            catch (NullReferenceException) {
                MessageBox.Show("Ingresa datos en por lo menos un campo");
            }
            catch(FormatException) {
                MessageBox.Show("Ingresa datos en por lo menos un campo");
            }
            catch (ResultadoNuloException RE) {
                MessageBox.Show(RE.Message);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Despliega una ventana con toda la información del producto consultado.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        void mostrar(object sender, EventArgs e) {
            try {
                new ProductBox(this.resultado.SelectedItem.ToString()).Show();
                this.resultado.SelectedItem = null;
            }
            catch (NullReferenceException) {
                this.resultado.SelectedItem = 1;
            }
        }
    }
}