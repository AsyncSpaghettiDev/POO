using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Productos {
    partial class Inventario {
        void gen_P(object sender, EventArgs e) {
            try {
                var colm= this.fecha.Text.Split('/');
                MessageBox.Show(new ProductoPerecedero(this.departamento.Text,this.code.Text,this.descripcion.Text,
                    Convert.ToDouble(this.likes.Text), Convert.ToDouble(this.precio.Text),new DateTime(Convert.ToInt32(colm[2]), Convert.ToInt32(colm[1]), Convert.ToInt32(colm[0]) ) ).ToString());
            }
            catch(FormatException) {
                MessageBox.Show("Debes ingresar datos en todos los campos");
            }
            catch(Exception ex) {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.StackTrace));
            }
        }
        void gen_NP(object sender, EventArgs e) {
            
        }
        void activado_Decide(object sender, EventArgs e) {
            if (this.decide.Checked) {
                this.fecha.Enabled = false;
                this.fecha.Text = DateTime.Now.ToString("ddMMyyyy");
            }
            else {
                this.fecha.Enabled = true;
                this.fecha.Text = String.Empty;
            }
        }
        void error(object sender,TypeValidationEventArgs e) {
            if (!e.IsValidInput) {
                new ToolTip().Show("El formato debe ser el sig dd/mm/yyyy.", this.fecha, 5000);
                e.Cancel = true;
            }
        }
        void comprueba(object sender, CancelEventArgs e) {
            TextBoxBase caja = (sender as TextBoxBase);
            ToolTip mensaje= new ToolTip();
            mensaje.ToolTipTitle = "Valor no aceptado";

            if (caja.Text != String.Empty) {
                try {
                    if (caja.Name == this.likes.Name && Convert.ToDouble(caja.Text) > 100) {
                        mensaje.Show("La cantidad máxima de likes es 100", sender as IWin32Window, 3000);
                        e.Cancel = true;
                    }
                    if (caja.Name == this.precio.Name && Convert.ToDouble(caja.Text) > 1500) {
                        mensaje.Show("La cantidad máxima de likes es 100", sender as IWin32Window, 3000);
                        e.Cancel = true;
                    }
                    if (sender is RichTextBox)
                        caja.Text = caja.Text.Replace(' ', '_');
                }
                catch (FormatException) {
                    MessageBox.Show("Formato incorrecto en "+caja.Name);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        void cambiar(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) {
                this.departamento.Validating += comprueba;
                desactiva_ActivaComponentes(true);
            }
        }
    }
}