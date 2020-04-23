using System;
using System.Collections.Generic;
interface ITrazo:IComparable{
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

    public int CompareTo(object obj){
       return this.color.CompareTo((obj as ITrazo).color);
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
    public int CompareTo(object obj){
        var name=this.GetType().ToString()+" "+this.color;
        Console.WriteLine(name);
        Console.WriteLine(obj.GetType().ToString()+(obj as ITrazo).color);
       return name.CompareTo(obj.GetType().ToString()+" "+(obj as ITrazo).color);
    }
}
class Program{
    static void Main(){
        var figuras = new List<ITrazo>();
        figuras.Add(new Circulo(12,13,"verde")) ;
        figuras.Add(new Rectangulo(12,13,"azul")) ;
        figuras.Add(new Rectangulo(12,13,"rojo")) ;
        figuras.Add(new Circulo(12,13,"rojo"));
        
        figuras.Sort();
        foreach(var figura in figuras){
            figura.dibuja();
        }
    }
}
