using System;
using System.Collections.Generic;
abstract class Figura{
    protected int x;
    protected int y;
    protected string color;
    public Figura(int x, int y, string color){
        this.x=x;
        this.y=y;
        this.color=color;
    }
    public abstract void dibuja();
    public virtual void printColor(){
        Console.WriteLine(this.color);
    }
}
class Circulo:Figura{
    public Circulo(int x,int y,string color):base(x,y,color){}
    public override void dibuja(){
        Console.WriteLine("Se dibuja un círculo color {0}",this.color);
    }
}
class Rectangulo:Figura{
    public Rectangulo(int x,int y,string color):base(x,y,color){}
    public override void dibuja(){
        Console.WriteLine("Se dibuja un rectángulo color {0}",this.color);
    }
}
class Program{
    static void Main(){
        List<Figura> figuras = new List<Figura>();
        figuras.Add(new Circulo(12,13,"Rojo"));
        figuras.Add(new Rectangulo(12,13,"Azul"));
        figuras.Add(new Rectangulo(12,13,"Rojo"));
        figuras.Add(new Circulo(12,13,"Azul"));
        figuras.Add(new Circulo(10,10,"Rojo"));
        
        foreach (Figura obj in figuras){
            obj.dibuja();
        }
    }
}