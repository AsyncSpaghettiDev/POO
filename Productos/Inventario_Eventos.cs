using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;

namespace Productos {
    partial class Inventario {
        void inicia_Interfaz(object sender, EventArgs e) {
            initializeComponent();
            InventarioDB.Cargar_Listas(0);
            if (InventarioDB.departamentos.Count==0)
                Application.Exit();
        }
        void gen_P(object sender, EventArgs e) {
            try {
                var colm= this.fecha.Text.Split('/');
                var PE=new ProductoPerecedero(this.departamento.Text, this.code.Text, this.descripcion.Text,
                    Convert.ToDouble(this.likes.Text), Convert.ToDouble(this.precio.Text),
                    new DateTime(Convert.ToInt32(colm[2]), Convert.ToInt32(colm[1]), Convert.ToInt32(colm[0])));
                MessageBox.Show(PE.ToString());
                MessageBox.Show(String.Format("{0}|{1}|{2}",PE.precios.f_Inicio.ToString("dd/MM/yyyy"), PE.precios.precio, PE.precios.f_Fin.ToString("dd/MM/yyyy")));
            }
            catch(FormatException) {
                MessageBox.Show("Debes ingresar datos en todos los campos");
            }
            catch (ProductoSinVidaException pex) {
                MessageBox.Show(pex.Message);
            }
            catch(Exception ex) {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.StackTrace));
            }
        }
        void gen_NP(object sender, EventArgs e) {
            
        }
        /// <summary>
        /// Cambia el textBox de fecha con la fecha actual en caso de desearlo así.
        /// </summary>
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
        /// <summary>
        /// Valida que la fecha ingresada sea correcta.
        /// </summary>
        void error(object sender,TypeValidationEventArgs e) {
            if (!e.IsValidInput) {
                new ToolTip().Show("El formato debe ser el sig dd/mm/yyyy.", this.fecha, 5000);
                e.Cancel = true;
            }
                
        }
        /// <summary>
        /// Metodo "generico" que valida cada campo de acorde a lo necesario.
        /// </summary>
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
                    if (caja.Name == this.departamento.Name) {
                        InventarioDB.Contains(caja.Text);
                    }
                    if (sender is RichTextBox)
                        caja.Text = caja.Text.Replace(' ', '_');
                }
                /*En caso que se presente un error en el formato se muestra un messageBox indicando el campo.*/
                catch (FormatException) {
                    MessageBox.Show("Formato incorrecto en "+caja.Name);
                }
                catch (InvalidDepartamentException IE) {
                    MessageBox.Show(IE.Message + "\n" + IE.HelpLink);
                    e.Cancel = true;
                }
                /*En caso que se presente una excepcion se muestra una messageBox con el error para su correccion*/
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        void ayuda(object sender, CancelEventArgs e) {
            Process.Start("http://ito.mx/MBRr");
        }
        /// <summary>
        /// Proximamente: Al momento de dar enter se valida el departamento y en caso de no existir se atrapa la excepcion
        /// Activa todos los campos de texto.
        /// </summary>
        void cambiar(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                Producto ped =InventarioDB.Contain(this.code.Text);
                desactiva_ActivaComponentes(true);
                if (ped != null) {
                    this.likes.Text = ped.likes.ToString();
                    this.descripcion.Text = ped.descripcion;
                    this.agrega.Enabled = false;
                }
                else {
                    this.actualiza.Enabled = false;
                }
            }
        }
    }
}