using System;
class Alumno{
    protected string nombre;
    protected int matricula;
    public Alumno(string nombre,int matricula){
        this.nombre=nombre;
        this.matricula=matricula;
    }
    public virtual void imprimeGrado(){
        Console.WriteLine("Mi nombre es {}");
    }
}
class Program{
    static void Main(){
        Console.WriteLine("Hello World!");
    }
}