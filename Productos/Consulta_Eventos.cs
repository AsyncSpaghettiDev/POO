using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Productos {
    partial class Consulta {
        void cambiar_Seleccion(object sender,EventArgs e) {
            if (this.S_Fecha.Checked)
                focus(0);
            if (this.S_Departamento.Checked)
                focus(1);
            if (this.S_Code.Checked)
                focus(2);
        }
        void focus(int casilla) {
            switch (casilla) {
                case 0:
                    this.B_Fecha.Enabled = true;
                    this.B_Departamento.Enabled = false;
                    this.B_Departamento.Clear();
                    this.B_Code.Enabled = false;
                    this.B_Code.Clear();
                    break;
                case 1:
                    this.B_Fecha.Enabled = false;
                    this.B_Fecha.Clear();
                    this.B_Departamento.Enabled = true;
                    this.B_Code.Clear();
                    break;
                case 2:
                    this.B_Fecha.Enabled = false;
                    this.B_Fecha.Clear();
                    this.B_Departamento.Enabled = false;
                    this.B_Departamento.Clear();
                    this.B_Code.Enabled = true;
                    break;
            }
        }
        void error(object sender, TypeValidationEventArgs e) {
            if (!e.IsValidInput) {
                new ToolTip().Show("El formato debe ser el sig dd/mm/yyyy.", this.S_Fecha, 5000);
                e.Cancel = true;
            }
        }
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

                foreach (Producto prod in resul)
                    this.resultado.Items.Add(prod);
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
        void regreso(object sender, EventArgs e) {
            Hide();
            new Pantalla_Inicial().Show();
        }
    }
}