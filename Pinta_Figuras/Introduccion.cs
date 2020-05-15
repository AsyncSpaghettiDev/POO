using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
/// <summary>
/// Lista de instrucciones de como usar el programa
/// </summary>
class Introduccion : Form{
    Label top,left,right,middle;
    Button cambio;
    public Introduccion() {
        Funciones.Diseno(this, 400, 400, "Como dibujar", "logo2");
        instrucciones();
        Paint+= new PaintEventHandler(pintar);
    }
    /// <summary>
    /// Serie de texto donde se plasman las instrucciones
    /// </summary>
    void instrucciones() {
        this.top = new Label();
        this.top.AutoSize = true;
        this.top.Font = new Font("Arial", 10);
        this.top.Text = "La herramienta funciona de 2 maneras solo con el mouse o\nusando el menú superior.";
        this.Controls.Add(this.top);

        this.left = new Label();
        this.left.AutoSize = true;
        this.left.Font = new Font("Arial", 9);
        this.left.Location = new Point(5, 60);
        this.left.Text = "En modo mouse se dibujará un\ncirculo.\nEn modo menú se\ndibujará la figura seleccionada.";
        this.Controls.Add(this.left);

        this.right = new Label();
        this.right.AutoSize = true;
        this.right.Font = new Font("Arial", 9);
        this.right.Location = new Point(5, 160);
        this.right.Text = "En modo mouse se dibujará un\nrectangulo.\nEn modo menú se\ndibujará la figura seleccionada.";
        this.Controls.Add(this.right);

        this.middle = new Label();
        this.middle.AutoSize = true;
        this.middle.Font = new Font("Arial", 9);
        this.middle.Location = new Point(5, 260);
        this.middle.Text = "En modo mouse se cambiará el\ncolor de relleno de la figura.\nEn modo menú se\ndibujará la figura seleccionada.";
        this.Controls.Add(this.middle);

        this.cambio = new Button();
        this.cambio.Size = new Size(this.cambio.Size.Width, this.cambio.Size.Height*2);
        this.cambio.Location = new Point(300, 160);
        this.cambio.Text = "Vamos\nallá";
        this.Controls.Add(this.cambio);
        this.cambio.Click += new EventHandler(cambiar);
    }
    /// <summary>
    /// Impresion de las imagenes para ilustrar las instrucciones
    /// </summary>
    void pintar(object sender, PaintEventArgs e) {
        ComponentResourceManager manager = new ComponentResourceManager(typeof(Pinta_Figuras.recursos));

        CreateGraphics().DrawImage(manager.GetObject("left") as Bitmap, 200, 40, 100, 100);
        CreateGraphics().DrawImage(manager.GetObject("right") as Bitmap, 200, 140, 100, 100);
        CreateGraphics().DrawImage(manager.GetObject("middle") as Bitmap, 200, 240, 100, 100);
    }
    /// <summary>
    /// Inicia el pintor
    /// </summary>
    void cambiar(object sender, EventArgs e) {
        new Pintor().Show();
        Dispose(false);
    }
}
