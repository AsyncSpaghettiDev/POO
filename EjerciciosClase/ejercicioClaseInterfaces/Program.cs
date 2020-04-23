using System;
using System.Collections.Generic;
interface ITrazo{
    int x{get;set;}
    int y{get;set;}
    String color{get;set;}
    void dibuja();
    void printColor();
}
class Circulo:ITrazo{
    private int _x;
    public int x{
        get=>_x;
        set=>_x=value;
    }
    private int _y;
    public int y{
        get=>_y;
        set=>_y=value;
    }
    private String _color;
    public String color{
        get=>_color;
        set=>_color=value;
    }
    public Circulo(int x,int y,string color){
        this.x=x;
        this.y=y;
        this.color=color;
    }
    public void dibuja(){
        Console.WriteLine("Se dibuja un circulo {0}",this.color);
    }
    public void printColor(){
        Console.WriteLine(this.color);
    }
}
class Rectangulo:ITrazo{
    private int _x;
    public int x{
        get=>_x;
        set=>_x=value;
    }
    private int _y;
    public int y{
        get=>_y;
        set=>_y=value;
    }
    private String _color;
    public String color{
        get=>_color;
        set=>_color=value;
    }
    public Rectangulo(int x,int y,string color){
        this.x=x;
        this.y=y;
        this.color=color;
    }
    public void dibuja(){
        Console.WriteLine("Se dibuja un rectangulo {0}",this.color);
    }
    public void printColor(){
        Console.WriteLine(this.color);
    }
}
class Program{
    static void Main(){
        var figuras = new List<ITrazo>();
        figuras.Add(new Circulo(12,13,"verde")) ;
        figuras.Add(new Rectangulo(12,13,"azul")) ;
        figuras.Add(new Rectangulo(12,13,"rojo")) ;
        figuras.Add(new Circulo(12,13,"rojo")) ;
        foreach(var figura in figuras){
            figura.dibuja();
        }
    }
}
