using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Productos {
    partial class Inventario {
        void gen_P(object sender, EventArgs e) {
            //ProductoPerecedero peren= new ProductoPerecedero("P-400","JPB-415","Jamon_de_Pavo_Marca_Bafar_venta_por_kg",87.5,103.56,DateTime.Now);
            var dats= this.fecha.Text.Split('/');
            MessageBox.Show(new DateTime(Convert.ToInt32(dats[2]),Convert.ToInt32(dats[1]), Convert.ToInt32(dats[0])).ToString("dd/MM/yyyy"));
        }
        void gen_NP(object sender, EventArgs e) {
            
        }
        void activado_Decide(object sender, EventArgs e) {
            if (this.decide.Checked) 
                desactiva_ActivaComponentes(false);
            else
                desactiva_ActivaComponentes(true);
        }
        void limiteChar(object sender,KeyEventArgs e,int lim,bool up) {
            if ((sender as TextBoxBase).TextLength > lim) {
                MessageBox.Show(new TooMuchCharactersException(sender as Control, lim).Message);
                (sender as TextBoxBase).Text = (sender as TextBoxBase).Text.Remove(lim);
                if (up)
                    (sender as TextBoxBase).Text = (sender as TextBoxBase).Text.ToUpper();
            }
            if(e.KeyCode==Keys.Enter||e.KeyCode==Keys.Tab)
                (sender as TextBoxBase).Text = (sender as TextBoxBase).Text.ToUpper();
        }
        void limiteChar(object sender, KeyEventArgs e, int lim) {
            Int32.TryParse((sender as TextBoxBase).Text, out int val);
            if (val > lim) {
                MessageBox.Show(new TooMuchCharactersException(sender as Control, lim).Message);
                (sender as TextBoxBase).Text = "0.00";
            }
        }
        void error(object sender,TypeValidationEventArgs e) {
            if (!e.IsValidInput) {
                /*ToolTip advertencia= new ToolTip();
                advertencia.ToolTipTitle = "Invalid Date Value";
                advertencia.Show("We're sorry, but the value you entered is not a valid date. Please change the value.", this.fecha, 5000);
                e.Cancel = true;*/
            }
        }
        void salida_Foco(object sender, EventArgs e) {
            if(sender is RichTextBox)
                (sender as RichTextBox).Text= (sender as RichTextBox).Text.Replace(' ', '_');
            (sender as RichTextBox).Text = (sender as RichTextBox).Text.ToUpper();
        }
        void comprueba(object sender, CancelEventArgs e) {
            //if((sender as Control).Name== this.precio.Name||)
        }
    }
}