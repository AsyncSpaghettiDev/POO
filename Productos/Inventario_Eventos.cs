using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;

namespace Productos {
    partial class Inventario {
        /// <summary>
        /// Producto a actualizar.
        /// </summary>
        Producto ped;
        /// <summary>
        /// Agrega un nuevo producto con los datos de las TextBox
        /// </summary>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ProductoSinVidaException"></exception>
        void agregar(object sender, EventArgs e) {
            try {
                /*
                 * Se crea un producto local que se instanciará después.
                 * Se separa los datos del texbox de Fecha por el char '/'
                 */
                Producto Prod;
                var colm= this.fecha.Text.Split('/');
                /*
                 * Si el textBox departamento contiene una letra P significa que es un producto Perecedero y
                 * el producto declarado de manera local se inicializa con un producto perecedero, de no ser así
                 * se inicializa con un producto no perecedero.
                 */
                if (this.departamento.Text.Contains("P")){
                    Prod = new ProductoPerecedero(this.departamento.Text, this.code.Text, this.descripcion.Text,
                    Convert.ToDouble(this.likes.Text), Convert.ToDouble(this.precio.Text),
                    new DateTime(Convert.ToInt32(colm[2]), Convert.ToInt32(colm[1]), Convert.ToInt32(colm[0])));
                }
                else {
                    Prod = new ProductoNoPerecedero(this.departamento.Text, this.code.Text, this.descripcion.Text,
                    Convert.ToDouble(this.likes.Text), Convert.ToDouble(this.precio.Text),
                    new DateTime(Convert.ToInt32(colm[2]), Convert.ToInt32(colm[1]), Convert.ToInt32(colm[0])));
                }
                /*
                 * Se agrega el producto local al lista interna, se guarda la lista de inventario a la DB Inventario
                 * Se muestra un MessageBox con un mensaje que indica el registro exitoso.
                 * Finalmente se limpían los componentes.
                 */
                InventarioDB.inventario.Add(Prod);
                InventarioDB.Guardar_Listas(this.path);
                MessageBox.Show("Registro Exitoso");
                limpiar_Box();
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
        /// <summary>
        /// Actualiza el producto existente en una lista
        /// </summary>
        /// <exception cref="FormatException"></exception>
        void actualizar(object sender, EventArgs e) {
            try {
                /*
                 * Al producto que se habia declarado en la clase se le actualizan sus
                 * datos con los proporcionados por el usuario.
                 */
                this.ped.codigo = this.code.Text;
                this.ped.likes = Convert.ToDouble(this.likes.Text);
                this.ped.descripcion = this.descripcion.Text;
                var colm= this.fecha.Text.Split('/');
                /*
                 * En caso que el textBox departamento contenga una P el precio se actualiza con un precioFecha perecedero.
                 * En caso contrario se inicializa con precio no perecedero.
                 */
                if(this.departamento.Text.Contains("P"))
                    this.ped.precios = new PrecioFechaP(new DateTime(Convert.ToInt32(colm[2]), Convert.ToInt32(colm[1]), Convert.ToInt32(colm[0])), Convert.ToDouble(this.precio.Text));
                else
                    this.ped.precios = new PrecioFechaNP(new DateTime(Convert.ToInt32(colm[2]), Convert.ToInt32(colm[1]), Convert.ToInt32(colm[0])), Convert.ToDouble(this.precio.Text));
                /*
                 * Se guarda la lista de inventario a la DB Inventario
                 * Se muestra un MessageBox con un mensaje que indica la actualización exitosa.
                 * Finalmente se limpían los componentes.
                 */
                InventarioDB.Guardar_Listas(this.path);
                MessageBox.Show("Actualizacion Exitoso");
                limpiar_Box();
            }
            catch (FormatException) {
                MessageBox.Show("Debes ingresar datos en todos los campos");
            }
            catch (Exception ex) {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.StackTrace));
            }
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
        /// Metodo "generico" que valida cada campo de acorde a lo necesario.
        /// </summary>
        void comprueba(object sender, CancelEventArgs e) {
            TextBoxBase caja = (sender as TextBoxBase);
            ToolTip mensaje= new ToolTip();
            mensaje.ToolTipTitle = "Valor no aceptado";

            if (caja.Text != String.Empty) {
                try {
                    // Para la textBox likes debe tener una valor menor a 100
                    if (caja.Name == this.likes.Name && Convert.ToDouble(caja.Text) > 100) {
                        mensaje.Show("La cantidad máxima de likes es 100", sender as IWin32Window, 3000);
                        e.Cancel = true;
                    }
                    // Para la textBox precio debe tener un valor menor a 1500
                    if (caja.Name == this.precio.Name && Convert.ToDouble(caja.Text) > 1500) {
                        mensaje.Show("La cantidad máxima de likes es 100", sender as IWin32Window, 3000);
                        e.Cancel = true;
                    }
                    // Para la textBox departamento el valor de este debe ser un departamento válido en la DB departamentos.
                    if (caja.Name == this.departamento.Name) {
                        InventarioDB.Contains(caja.Text);
                    }
                    // Para la textBox descripción se sustituyen los espacios por un guion.
                    if (sender is RichTextBox)
                        caja.Text = caja.Text.Replace(' ', '_');
                }
                // En caso que se presente un error en el formato se muestra un messageBox indicando el campo.
                catch (FormatException) {
                    MessageBox.Show("Formato incorrecto en "+caja.Name);
                }
                catch (InvalidDepartamentException IE) {
                    MessageBox.Show(IE.Message + "\n" + IE.HelpLink);
                    e.Cancel = true;
                }
                // En caso que se presente una excepcion se muestra una messageBox con el error para su correccion.
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        /// <summary>
        /// Redirecciona al usuario a la lista de departamentos genéricos.
        /// </summary>
        void ayuda(object sender, CancelEventArgs e) {
            Process.Start("http://ito.mx/MBRr");
        }
        /// <summary>
        /// Al momento de dar enter se valida el código y en caso de no existir se creará
        /// un nuevo producto con la información que el usuario ingrese.
        /// Activa todos los campos de texto.
        /// </summary>
        void cambiar(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter && this.descripcion.Enabled == false){
                /*
                * Se incializa el valor de la clase buscando si existe en la lista interna inventario.
                * En caso de ser así se desactiva el botón de agregar y se rellenan los textBox con
                * la información del archivo existente.
                * En caso de ser un valor nulo solo se desactiva el botón actualiza.
                */
                this.ped = InventarioDB.Contain(this.code.Text,this.departamento.Text);

                desactiva_ActivaComponentes(true);

                if (this.ped != null) {
                    this.likes.Text = this.ped.likes.ToString();
                    this.descripcion.Text = this.ped.descripcion;
                    this.precio.Text = this.ped.precioLanzado.precio.ToString();
                    this.fecha.Text = this.ped.precioLanzado.f_Inicio.ToString("ddMMyyyy");
                    this.agrega.Enabled = false;
                }
                else 
                    this.actualiza.Enabled = false;
            }
        }
    }
}