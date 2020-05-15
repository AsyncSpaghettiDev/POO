using System.Drawing;
using System.Windows.Forms;
/*Creación de clase abstracta con atributos y, x, color, se declaran como protected porque
van a ser heredados a otras clases */
abstract class Figura{
    protected int x,y;
    protected int ancho,largo;
    protected Graphics figura;
    protected Pen borde;
    public SolidBrush relleno { get; set; }
    /*Creacion del constructor usando sobrecarga de parametros*/
    public Figura(int x, int y,int ancho,int largo, Color color){
        this.x=x;
        this.y=y;
        this.ancho=ancho;
        this.largo = largo;
        this.borde= new Pen(Color.Black);
        this.relleno = new SolidBrush(color);
        
    }
    /*Creacion de método abstracto, obligatorio estar sin cuerpo*/
    public abstract Graphics dibuja(Form Lienzo);
    /*Creacion de método virtual para poder ser redefinido en las clases heredadas*/
    public virtual string printColor => this.relleno.Color.ToString();
}
/*Creacion de clase circulo heredando de figura*/
class Circulo:Figura{
    /*Creacion del constructor referenciando al constructor de la clase base*/
    public Circulo(int x, int y, int ancho, int largo, Color color) :base(x,y,ancho,largo,color){}
    /*Redefinicion del método dibuja, obligatorio refedinirlo dado que es un
    método abstracto.*/
    public override Graphics dibuja(Form Lienzo) {
        this.figura = Lienzo.CreateGraphics();
        this.figura.FillEllipse(this.relleno, this.x, this.y, this.ancho, this.largo);
        this.figura.DrawEllipse(this.borde,this.x,this.y,this.ancho,this.largo);
        return this.figura;
    }
    /*Debido que el método printColor es virtual no es necesario redefinirlo a 
    diferencia del método dibuja que es un método abstract*/
}
class Rectangulo:Figura{
    /*Creacion del constructor referenciando al constructor de la clase base*/
    public Rectangulo(int x, int y, int ancho, int largo, Color color) : base(x, y, ancho, largo, color) { }
    /*Redefinicion del método dibuja, obligatorio refedinirlo dado que es un
    método abstracto.*/
    public override Graphics dibuja(Form Lienzo) {
        this.figura = Lienzo.CreateGraphics();
        this.figura.FillRectangle(this.relleno, this.x, this.y, this.ancho, this.largo);
        this.figura.DrawRectangle(this.borde, this.x, this.y, this.ancho, this.largo);
        return this.figura;
    }
    /*Debido que el método printColor es virtual no es necesario redefinirlo a 
    diferencia del método dibuja que es un método abstract*/
}
