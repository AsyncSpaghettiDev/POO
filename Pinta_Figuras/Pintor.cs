using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
/// <summary>
/// Ventana donde se encuentran todos los elementos necesario para dibujar
/// </summary>
class Pintor : Form {
    /*Lista de color que tiene el pintor*/
    readonly List<Color> relleno= new List<Color>(){
        Color.Black,
        Color.White,
        Color.Blue,
        Color.Red,
        Color.Transparent,
    };
    /*Lista de figuras que se pintan*/
    readonly List<Figura> figs;
    readonly Label color_actual;
    Color _Relleno;
    int i=0,x,y,tipo=-1;
    Figura pintura=null;
    /// <summary>
    /// Se inician todos los componentes del Pintor
    /// </summary>
    public Pintor() {
        this.color_actual = new Label();
        iniciaComponentes();
        this.figs = new List<Figura>();
        MouseDown += new MouseEventHandler(click_D);
        MouseUp += new MouseEventHandler(click_U);
        Paint += new PaintEventHandler(repintado);
    }
    void iniciaComponentes() {
        Funciones.Diseno(this, 600, 600, "Pintor","logo");
        new Menu_Control(this);
        this.color_actual.Text = "Color actual de relleno: "+this.relleno[this.i].ToString();
        this.color_actual.Size = new Size(220, this.color_actual.Height);
        this.color_actual.Location = new Point(325, 25);
        this.Controls.Add(this.color_actual);
    }
    /// <summary>
    /// Al presionar un boton del mouse dependiendo del modo en el que esté se dibujará una figura
    /// </summary>
    void click_D(object sender, MouseEventArgs e) {
        if (Menu_Control.modo_Mouse) {
            switch (e.Button) {
                case MouseButtons.Left:
                    this.tipo = 0;
                    break;
                case MouseButtons.Right:
                    this.tipo = 1;
                    break;
                case MouseButtons.Middle:
                    aumentaColor();
                    break;
            }
        }
        else if (Menu_Control.dibujando == Estado.circulo)
            this.tipo = 0;
        else if (Menu_Control.dibujando == Estado.rectangulo)
            this.tipo = 1;
        else
            aumentaColor();
        /*Se declaran puntos donde se ubicará el centro de la figura a dibujar de acuerdo a la posicion actual del puntero*/
        this.x = e.X;
        this.y = e.Y;
        this._Relleno = this.relleno[this.i];
    }
    /// <summary>
    /// Al levantar el boton pulsado del mouse se ejecuta la accion la accion de pintar y se añade a la lista de figuras pintadas
    /// </summary>
    void click_U(object sender, MouseEventArgs e) {
        if (this.tipo !=-1) {
            string tip=null;
            switch (this.tipo) {
                case 0:
                    tip = "Circulo";
                    this.pintura = new Circulo(this.x - 25, this.y - 25, 50, 50, this._Relleno);
                    break;
                case 1:
                    tip = "Rectangulo";
                    this.pintura = new Rectangulo(this.x - 25, this.y - 25, 50, 50, this._Relleno);
                    break;
            }
            Registro.registrar(tip, this._Relleno.ToString());
            this.figs.Add(this.pintura);
            this.pintura.dibuja(this);
        }
    }
    /// <summary>
    /// Aumenta el apuntador que selecciona el color de las figuras y en caso de llegar al limite se reinicia a 0
    /// </summary>
    void aumentaColor() {
        if (this.i < this.relleno.Count-1)
            this.i++;
        else
            this.i = 0;
        this.color_actual.Text = "Color actual de relleno: " + this.relleno[this.i].ToString();
        this.tipo = -1;
    }
    /// <summary>
    /// Cada vez que se ejecuta el método Paint se dibujarán las figuras coloreadas
    /// </summary>
    void repintado(object sender, PaintEventArgs e) {
        foreach (Figura n in this.figs)
            n.dibuja(this);
    }
}