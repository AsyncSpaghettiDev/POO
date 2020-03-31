using System;
using System.Collections.Generic;
class Musico{
    protected string nombre;
    public Musico(string nombre){
        this.nombre=nombre;
    }
    public virtual void afina(){
        Console.WriteLine("Estoy afinando my instrumento.",nombre);
    }
    public virtual void saluda(){
        Console.WriteLine("Que tal! Soy {0}.",nombre);
    }
    public virtual void toca(){
        Console.WriteLine("¡Hora de tocar!");
    }
}
class Baterista:Musico{
    private string marca_bateria;
    private string marca_platillos;
    private string marca_baquetas;
    public Baterista(string nombre,string marca_bateria,string marca_platillos,string marca_baquetas):base(nombre){
        this.marca_bateria=marca_bateria;
        this.marca_platillos=marca_platillos;
        this.marca_baquetas=marca_baquetas;
    }
    public override void afina(){
        Console.WriteLine("Estoy afinando los tambores de mi bateria {0}.",this.marca_bateria);
    }
    public override void saluda(){
        Console.WriteLine("Hola amigos, soy {0} el baterista, uso mi bateria {1} con los platillos {2} y mis baquetas {3}.",this.nombre,this.marca_bateria,this.marca_platillos,this.marca_baquetas);
    }
    public override void toca(){
        Console.WriteLine("Hora de Rockear!!");
    }
}
class Bajista:Musico{
    private string marca_bajo;
    private string marca_strap;
    public Bajista(string nombre,string marca_bajo,string marca_strap):base(nombre){
        this.marca_bajo=marca_bajo;
        this.marca_strap=marca_strap;
    }
    public override void afina(){
        Console.WriteLine("Estoy afinando mi bajo marca {0}.",this.marca_bajo);
    }
    public override void saluda(){
        Console.WriteLine("Hola que tal soy {0} toco el bajo {1} para la banda con mi strap marca {2}",this.nombre,this.marca_bajo,this.marca_strap);
    }
    public override void toca(){
        Console.WriteLine("Demosle!!");
    }
}
class Guitarrista:Musico{
    private string marca_guitarra;
    private string marca_strap;
    private string marca_plumilla;
    private double tamaño_plumilla;
    public Guitarrista(string nombre,string marca_guitarra,string marca_strap,string marca_plumilla,double tamaño_plumilla):base(nombre){
        this.marca_guitarra=marca_guitarra;
        this.marca_strap=marca_strap;
        this.marca_plumilla=marca_plumilla;
        this.tamaño_plumilla=tamaño_plumilla;
    }
    public override void afina(){
        Console.WriteLine("Estoy afinando mi guitarra marca {0}",this.marca_guitarra);
    }
    public override void saluda(){
        Console.WriteLine("Muy buena gente soy {0}, me gusta usar mi guitarra {1} con el strap marca {2}.\nSiempre toco usando mis plumillas {3} {4}mm.",this.nombre,this.marca_guitarra,this.marca_strap,this.marca_plumilla,this.tamaño_plumilla);
    }
    public override void toca(){
        Console.WriteLine("Hora de tocar!!");
    }
}
class Program{
    static void Main(){
        List<Musico> banda = new List<Musico>();

        banda.Add(new Musico("Roberto Gutierrez"));
        banda.Add(new Baterista("Ringo Star","Pearl","Zildjian","Vic Firt"));
        banda.Add(new Bajista("John Paul","Ken Smith Custom","P&P"));
        banda.Add(new Guitarrista("Carlos Santana","Paul Reed Smith","Fender","Alice",0.71));

        foreach (Musico integrante in banda){
            integrante.saluda();
            integrante.afina();
            integrante.toca();
            Console.WriteLine();
        }
    }
}