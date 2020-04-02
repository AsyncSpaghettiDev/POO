using System;
using System.Collections.Generic;
/*Creación de clase abstracta con atributos y, x, color, se declaran como protected porque
van a ser heredados a otras clases */
abstract class Figura{
    protected int x;
    protected int y;
    protected string color;
    /*Creacion del constructor usando sobrecarga de parametros*/
    public Figura(int x, int y, string color){
        this.x=x;
        this.y=y;
        this.color=color;
    }
    /*Creacion de método abstracto, obligatorio estar sin cuerpo*/
    public abstract void dibuja();
    /*Creacion de método virtual para poder ser redefinido en las clases heredadas*/
    public virtual void printColor(){
        Console.WriteLine(this.color);
    }
}
/*Creacion de clase circulo heredando de figura*/
class Circulo:Figura{
    /*Creacion del constructor referenciando al constructor de la clase base*/
    public Circulo(int x,int y,string color):base(x,y,color){}
    /*Redefinicion del método dibuja, obligatorio refedinirlo dado que es un
    método abstracto.*/
    public override void dibuja(){
        Console.WriteLine("Se dibuja un círculo color {0}",this.color);
    }
    /*Debido que el método printColor es virtual no es necesario redefinirlo a 
    diferencia del método dibuja que es un método abstract*/
}
class Rectangulo:Figura{
    /*Creacion del constructor referenciando al constructor de la clase base*/
    public Rectangulo(int x,int y,string color):base(x,y,color){}
    /*Redefinicion del método dibuja, obligatorio refedinirlo dado que es un
    método abstracto.*/
    public override void dibuja(){
        Console.WriteLine("Se dibuja un rectángulo color {0}",this.color);
    }
    /*Debido que el método printColor es virtual no es necesario redefinirlo a 
    diferencia del método dibuja que es un método abstract*/
}
class Program{
    static void Main(){
        /*Creacion de una lista de objetos de tipo Figura*/
        List<Figura> figuras = new List<Figura>();
        /*Al ser Circulo y Rectangulo clases heredadas de figura se pueden
        agregar a la lista de Figura*/
        figuras.Add(new Circulo(12,13,"Rojo"));
        figuras.Add(new Rectangulo(12,13,"Azul"));
        figuras.Add(new Rectangulo(12,13,"Rojo"));
        figuras.Add(new Circulo(12,13,"Azul"));
        figuras.Add(new Circulo(10,10,"Rojo"));

        /*Uso del foreach para invocar el método dibuja de todos los 
        elementos de la lista figuras*/
        foreach (Figura obj in figuras){
            obj.dibuja();
        }
    }
}